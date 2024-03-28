using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion


namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        #region setup of the context connecton variable and class constructor
        private readonly WestWindContext _context;

        //this constructor is obtaining the instance to the WestWindContext class
        //  that was added in the WestWindExtension class via the registrant of my context clas
        //  in the WestWindExtensionServices method
        internal ProductServices(WestWindContext syscontext)
        {
            _context = syscontext;
        }
        #endregion

        //Services
        #region Queries

        public List<Product> Product_GetByCategoryID(int categoryid)
        {
            IEnumerable<Product> info = _context.Products
                                        .Where(p => p.CategoryID == categoryid)
                                        .OrderBy(p => p.ProductName);
            return info.ToList(); //converts IEnumerable datatype to List<T> datatype
        }
        public List<Product> Product_GetByName(string partialproductname)
        {
            IEnumerable<Product> info = _context.Products
                                        .Where(p => p.ProductName.Contains(partialproductname))
                                        .OrderBy(p => p.ProductName);
            return info.ToList(); //converts IEnumerable datatype to List<T> datatype
        }

        // the cRud
        // a query to obtain the current information for the supplied primary key
        //      value of a product record
        //input: productid
        //output: the instance from the database that matches the incoming value
        public Product? Product_GetByID(int productid)
        {
            //using a methods from List<T>
            //this methods searches a collection by a given key: primary key
            //return _context.Products.Find(productid);

            //using a Linq method
            //this methods searches a collection by a predicate specifying the
            //  search criteria
            //it is NOT limited to the primary key
            //Normally, a search of a collection is expected to return x records
            //IF, you expect to return a single record, you will need to
            //  indicate such to Linq
            //we expect to return only a single record
            //the method to use is .FirstOrDefault()
            // using FirstOrDefault WITHOUT the predicate will return the
            //      first record of the collection
            // using FirstOrDefault WITH the predicate allows one to specify
            //      the search criteria within the method itself
            return _context.Products.FirstOrDefault(p => p.ProductID == productid);
        }
        #endregion

        #region Maintenance Commands Add, Update, Delete
        //ADD : Crud
        //Adding a record to your database MAY require you to
        //  verify that the data does not already exists on the database
        //  verify that the incoming data is valid (do not trust the front end)

        //these actions are referred to as Business Logic (Business Rules)

        //always check if you have data actually coming into your method

        //What type of pkey does the table have? Identity or User supplied
        //if user supplied, consider checking that the pkey is not on the database

        //Do whatever other validation (Business Rules) for the action
        //
        //Example: Assume that the product cannot be from the same supplier
        //          with the same name for the same unit size

        //if all validation is passed then you can actually add the data to
        //  the database.
        public int Product_AddProduct(Product item)
        {
           
            bool exists = false;
            if(item == null)
            {
                throw new ArgumentNullException("You must supply the product information");
            }

            //example of our "maded-up" Business rule
            //.Any(predicate) returns a true or false depending on collection existing
            exists = _context.Products
                        .Any(p => p.SupplierID == item.SupplierID
                               && p.ProductName == item.ProductName
                               && p.QuantityPerUnit == item.QuantityPerUnit);
            if (exists)
            {
                throw new ArgumentException("Product already on file");
            }

            //there are two steps to maintaining the database
            //Staging: create the database action in local memory
            //Commit: have the database apply the action in memory

            //Staging
            // staging is the act of placing your data into local memory
            //      for eventual processing on the database
            // a) DbSet
            // b) know the act
            // c) indicate the data involved

            //IMPORTANT:  the data is in LOCAL MEMORY
            //            the data has NOT!!!!! yet been sent to the database
            //THERFORE: at this time, there is NO!!!!  IDENTITY primary key value
            //          on this instance (except for the default of the datatype)
            //UNLESS: You have placed a value in the NON_IDENTITY key field

            _context.Products.Add(item);

            //COMMIT sends the LOCAL Staged data to the database for processing

            //ANY validation in the entity model defintion will be applied at
            //      this point.
            //the validation annotation that exists in your entity model definitions
            //  were placed there during your reverse engineering

            _context.SaveChanges();

            //AFTER the successful commit to the database, your new product id
            //      will be inserted into your local instance of the data
            //NOW you have access to your NEW primary key value
            
            return item.ProductID;
        }
        #endregion
    }
}

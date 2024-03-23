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
        #endregion
    }
}

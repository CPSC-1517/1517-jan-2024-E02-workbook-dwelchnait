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
    public class SupplierServices
    {
        #region setup of the context connecton variable and class constructor
        private readonly WestWindContext _context;

        //this constructor is obtaining the instance to the WestWindContext class
        //  that was added in the WestWindExtension class via the registrant of my context clas
        //  in the WestWindExtensionServices method
        internal SupplierServices(WestWindContext syscontext)
        {
            _context = syscontext;
        }
        #endregion

        //Services
        #region Queries
        public List<Supplier> Supplier_GetList()
        {
            //what context class am I using
            //what DbSet do I need access to
            //Is there any filtering of the data set
            //Am I getting the collect or a single instance
            //does the data have to be in a particular order
            IEnumerable<Supplier> info = _context.Suppliers
                                          .OrderBy(o => o.CompanyName);
            return info.ToList();
        }
        #endregion

    }
}

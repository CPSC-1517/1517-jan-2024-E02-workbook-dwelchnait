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
    public class CategoryServices
    {
        #region setup of the context connecton variable and class constructor
        private readonly WestWindContext _context;

        //this constructor is obtaining the instance to the WestWindContext class
        //  that was added in the WestWindExtension class via the registrant of my context clas
        //  in the WestWindExtensionServices method
        internal CategoryServices(WestWindContext syscontext)
        {
            _context = syscontext;
        }
        #endregion

        //Services
        #region Query
        public List<Category> Category_GetList()
        {
            // grab all records from the Categories sql table
            // the DbSet<Category> is Categories
            IEnumerable<Category> info = _context.Categories
                                        .OrderBy(c => c.CategoryName);
            return info.ToList();
        }
        #endregion
    }
}

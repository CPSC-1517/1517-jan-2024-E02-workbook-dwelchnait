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
    public class WestWindAbout
    {
        #region setup of the context connecton variable and class constructor
        private readonly WestWindContext _context;

        //this constructor is obtaining the instance to the WestWindContext class
        //  that was added in the WestWindExtension class via the registrant of my context clas
        //  in the WestWindExtensionServices method
        internal WestWindAbout(WestWindContext syscontext )
        {
            _context = syscontext;
        }
        #endregion

        //Services
        #region Queries
        public BuildVersion WestWindAbout_Get()
        {
            //call the context property and apply the LINQ query to the dataset (DbSet<T>) returned
            //  from the database.
            //each property is tried to a specific table in your database and is reflected by the
            //  property name
            IEnumerable<BuildVersion> info = _context.BuildVersions;

            //return one row from the data set within info. 
            //.FirstOrDefault() takes the first instance in the dataset. If the dataset is empty
            //  the returned value will be null
            return info.FirstOrDefault();                                
        }
        #endregion
    }
}

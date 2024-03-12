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
    public class RegionServices
    {
        #region setup of the context connecton variable and class constructor
        private readonly WestWindContext _context;

        //this constructor is obtaining the instance to the WestWindContext class
        //  that was added in the WestWindExtension class via the registrant of my context clas
        //  in the WestWindExtensionServices method
        internal RegionServices(WestWindContext syscontext)
        {
            _context = syscontext;
        }
        #endregion

        //Services
        #region Queries
        //assuming you have built these methods within LinqPad and already have proven
        //      that they work
        //what alterations do I need to make for the BLL
        //1) entities in Linq are plural, they need to be made singular in the BLL
        //2) access to the table in Linq was direct, you will need to add your 
        //      context variable name in front of the table names
        public List<Region> Region_Get()
        {
            IEnumerable<Region> info = _context.Regions.OrderBy(r => r.RegionDescription);
            return info.ToList();

        }

        public Region Region_GetByID(int regionid)
        {
            IEnumerable<Region> info = _context.Regions
                                                .Where(r => r.RegionID == regionid);
            return info.FirstOrDefault();


        }
        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using WebGYM.Interface;
using WebGYM.Models;

namespace WebGYM
{
    public class PeriodMaster : IPeriodMaster
    {
        private readonly DatabaseContext _databaseContext;
        public PeriodMaster(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PeriodTB> ListofPeriod()
        {
            var listofPeriod = _databaseContext.PeriodTb.ToList();

            listofPeriod.IndexOf(new PeriodTB()
            {
                Text = "---Select---",
                Value = string.Empty
            },0);

            return listofPeriod;
        }
    }
}

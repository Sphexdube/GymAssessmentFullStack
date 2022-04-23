using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM
{
    public class ReportsMaster : IReports
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _context;
        public ReportsMaster(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public List<MemberDetailsReportModel> Generate_AllMemberDetailsReport()
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                return con.Query<MemberDetailsReportModel>("Usp_GetAllRenwalrecords", null, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<YearwiseReportModel> Get_YearwisePayment_details(string year)
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var para = new DynamicParameters();
                para.Add("@year", year);
                return con.Query<YearwiseReportModel>("Usp_GetYearwisepaymentdetails", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<MonthWiseReportModel> Get_MonthwisePayment_details(string monthId)
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var para = new DynamicParameters();
                para.Add("@month", monthId);
                return con.Query<MonthWiseReportModel>("Usp_GetMonthwisepaymentdetails", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<RenewalReportViewModel> Get_RenewalReport(RenewalReportRequestModel renewalReport)
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var para = new DynamicParameters();
                para.Add("@Paymentfromdt", renewalReport.Paymentfromdate);
                para.Add("@Paymenttodt", renewalReport.Paymentfromto);
                return con.Query<RenewalReportViewModel>("Usp_GetAllRenwalrecordsFromBetweenDate", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}

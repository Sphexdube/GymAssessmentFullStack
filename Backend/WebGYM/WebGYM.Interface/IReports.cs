using System.Collections.Generic;
using WebGYM.Models.Model;

namespace WebGYM.Interface
{
    public interface IReports
    {
        List<MemberDetailsReportModel> Generate_AllMemberDetailsReport();
        List<YearwiseReportModel> Get_YearwisePayment_details(string year);
        List<MonthWiseReportModel> Get_MonthwisePayment_details(string monthId);
        List<RenewalReportViewModel> Get_RenewalReport(RenewalReportRequestModel renewalReport);
    }
}
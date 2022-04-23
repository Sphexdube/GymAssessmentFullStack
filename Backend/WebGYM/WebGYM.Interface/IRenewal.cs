using System;
using WebGYM.Models.Model;

namespace WebGYM.Interface
{
    public interface IRenewal
    {
        RenewalModel GetMemberNo(string memberNo, int userid);
        bool CheckRenewalPaymentExists(DateTime newdate, long memberId);
    }
}
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM
{
    public class Renewal : IRenewal
    {

        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _context;

        public Renewal(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public RenewalModel GetMemberNo(string memberNo , int userid)
        {
            var membernoList = (from member in _context.MemberRegistration
                                join payment in _context.PaymentDetails on member.MemberId equals payment.MemberID
                                where member.MemberNo == memberNo && member.Createdby == userid
                                select new RenewalModel
                                {
                                    MemberNo = member.MemberNo,
                                    MemberName = member.MemberFName + ' ' + member.MemberMName + ' ' + member.MemberLName,
                                    PlanID = payment.PlanID,
                                    MemberId = member.MemberId,
                                    SchemeID = payment.WorkouttypeID,
                                    NextRenwalDate = payment.NextRenwalDate,
                                    Amount = payment.PaymentAmount,
                                    PaymentID = payment.PaymentID
                                }).OrderByDescending(x => x.PaymentID).FirstOrDefault();

            return membernoList;
        }

        public bool CheckRenewalPaymentExists(DateTime newdate , long memberId)
        {
            var data = (from payment in _context.PaymentDetails 
                where payment.MemberID == memberId && newdate.Date >= payment.PaymentFromdt.Date && newdate.Date <= payment.PaymentTodt.Date
                select payment).Any();

            return data;
        }


    }
}

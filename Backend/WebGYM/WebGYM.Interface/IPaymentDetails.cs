using System.Linq;
using WebGYM.Models;
using WebGYM.Models.Model;

namespace WebGYM.Interface
{
    public interface IPaymentDetails
    {
        IQueryable<PaymentDetailsModel> GetAll(QueryParameters queryParameters, int userId);
        int Count(int userId);
        bool RenewalPayment(RenewalModel renewalViewModel);
    }
}
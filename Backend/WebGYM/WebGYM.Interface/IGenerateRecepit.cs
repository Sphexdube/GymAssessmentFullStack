using WebGYM.Models.Model;
using WebGYM.Models.Model;

namespace WebGYM.Interface
{
    public interface IGenerateRecepit
    {
        GenerateRecepitModel Generate(int paymentId);
    }
}
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM
{
    public class GenerateRecepit : IGenerateRecepit
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _context;

        public GenerateRecepit(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public GenerateRecepitModel Generate(int paymentId)
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var para = new DynamicParameters();
                para.Add("@PaymentID", paymentId);
                return con.Query<GenerateRecepitModel>("GetRecepit", para, null, true, 0, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}

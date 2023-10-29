using LoginRegisterationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegisterationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterationController : ControllerBase
    {
        public readonly IConfiguration _configuration;
       

        public RegisterationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registeration")]
        public string registeration(Registeration registeration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ToysCon").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO Registeration(UserName,Password,Email,IsActive) VALUES('" + registeration.UserName + "','" + registeration.Password + "','" + registeration.Email + "','" + registeration.IsActive + "')", con);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                return "Data inserted";
            }
            else
            {
                return "Error";
            }
            return "";
        }
        [HttpPost]
        [Route("login")]
        public string login(Registeration registeration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ToysCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registeration WHERE Email= '" + registeration.Email + "' AND Password = '" + registeration.Password + "' AND IsActive =1", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                return "Valid user";
            }
            else
            {
                return "Invalid user";
            }

        }
    }
}

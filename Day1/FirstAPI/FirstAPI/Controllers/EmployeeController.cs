using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<string> names = new List<string>{ "Sita", "Rita", "Bita", "Kita" };
        [HttpGet]
        public string[] Get()
        {
            return names.ToArray();
        }
        [HttpPost]
        public void Create(string name)
        {
            names.Add(name);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DesafioTecnico.ApiCalculaJuros.Controllers
{
    [ApiController]
    [Route("")]
    public class GitController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GitController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return _configuration.GetSection("GitFonteUrl").Value;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Api.Repository;

namespace Palmfit.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly IRegister _register;
	
		
public RegisterController(IRegister register)
		{
			_register = register;
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
		{
			 _register.RegisterUser(registerDTO);

			return Ok(ModelState);
		}
	}
}

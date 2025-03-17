using Microsoft.AspNetCore.Mvc;
using ValidUml.Logic;
using ValidUml.Logic.Models;
using ValidUml.Logic.Models.UsersRules;

namespace ValidUml.Service.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValidationController : ControllerBase
	{
		[HttpPost("class")]
		public ValidationResultModel ValidateClassDiagram([FromBody] UserInputModel<ClassRule> model)
			=> ValidationService.ValidateClassDiagram(model);
	}
}

using Microsoft.AspNetCore.Mvc;
using ValidUml.Logic.UmlParsers;

namespace ValidUml.Service.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly ClassDiagram _parser;
		public TestController(ClassDiagram parser)
		{
			_parser = parser;
		}

		[HttpGet]
		public void Test()
		{
			_parser.Test();
		}
	}
}

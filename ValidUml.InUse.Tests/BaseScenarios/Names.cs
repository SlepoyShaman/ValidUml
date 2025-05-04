using System.Text;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.RuleValidators;

namespace ValidUml.InUse.Tests.BaseScenarios
{
	public class Names
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\basepops.xml";
			var diagram = new ClassDiagram(diagramPath);
			var entity = diagram.GetClasses().First();

			var nameValidator = new NameValidator("Class A");
			Assert.Null(nameValidator.Validate(entity));
		}
	}
}

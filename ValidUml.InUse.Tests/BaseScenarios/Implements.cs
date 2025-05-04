using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.RuleValidators;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.BaseScenarios
{
	public class Implements
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\implements.xml";
			var diagram = new ClassDiagram(diagramPath);
			var entity = diagram.GetClasses().First(c => c.AttributeValue(Xname) == "Class B");

			var validator = new ImplementsValidator("Interface", diagram);
			Assert.Null(validator.Validate(entity));
		}
	}
}

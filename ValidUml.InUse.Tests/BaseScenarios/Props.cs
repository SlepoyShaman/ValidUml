using System.Text;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.RuleValidators;

namespace ValidUml.InUse.Tests.BaseScenarios
{
	public class Props
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\basepops.xml";
			var diagram = new ClassDiagram(diagramPath);
			var entity = diagram.GetClasses().First();

			var containsField = new ContainsPropertiesValidator("existField");
			var containsMethod = new ContainsMethodsValidator("existMethod");
			var notContainsField = new NotContainsPropertiesValidator("notExist");
			var notContainsMethod = new NotContainsMethodsValidator("notExistMethod");

			Assert.Null(containsField.Validate(entity));
			Assert.Null(containsMethod.Validate(entity));
			Assert.Null(notContainsField.Validate(entity));
			Assert.Null(notContainsMethod.Validate(entity));
		}
	}
}

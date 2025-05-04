using System.Text;
using ValidUml.Logic.Models.UsersRules;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators;

namespace ValidUml.InUse.Tests.Constructor
{
	public class Constructor
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\impl.xml";
			var diagram = new ClassDiagram(diagramPath);

			var rule = new ClassRule(
				"Тестовое правило",
				EntityType.Class,
				FilterType.Name,
				"Class A",
				Rules: [
					new(EntityRuleType.ContainsProperties, "Attribute"),
					new(EntityRuleType.Implements, "Interface")
				]);

			var validator = new ClassValidator(diagram);
			var result = validator.Validate(rule);
			Assert.True(result.IsValid);
		}
	}
}

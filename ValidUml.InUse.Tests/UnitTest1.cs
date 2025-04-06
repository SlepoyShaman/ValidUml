using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void TestClassDiagram()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\test.xml";
			var diagram = new ClassDiagram(diagramPath);

			var classA = diagram.GetClasses()
				.First(c => c.AttributeValue(Xname) == "Class A");

			var fields = classA.GetFields();
			var contains = fields.Any(f => f.Name == "Attribute 1");
			Assert.True(contains);
		}
	}
}
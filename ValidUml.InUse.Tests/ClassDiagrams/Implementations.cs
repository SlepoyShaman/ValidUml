using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.ClassDiagrams
{
	public class Implementations
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\impl.xml";
			var diagram = new ClassDiagram(diagramPath);

			var parent = diagram.GetInterfases().FirstOrDefault(c => c.AttributeValue(Xname) == "Interface");
			Assert.NotNull(parent);
			string[] childs = ["Class B", "Class C", "Class B2"];
			var classes = diagram.GetAllImplementations(parent);
			Assert.Equal(classes.Length, childs.Length);
			foreach (var child in classes)
			{
				Assert.Contains(child.AttributeValue(Xname), childs);
			}
		}
	}
}

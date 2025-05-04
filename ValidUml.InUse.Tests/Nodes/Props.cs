using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;

namespace ValidUml.InUse.Tests.Nodes
{
	public class Props
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\node.xml";
			var diagram = new ClassDiagram(diagramPath);

			var node = diagram.GetClasses().First();
			var field = node.GetFields().First();
			Assert.Equal("Attribute", field.Name);

			var method = node.GetMethods().First();
			Assert.Equal("Operation", method.Name);
		}
	}
}

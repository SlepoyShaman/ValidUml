using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.Nodes
{
	public class Attribute
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\node.xml";
			var diagram = new ClassDiagram(diagramPath);

			var node = diagram.GetClasses().First();
			var attribute = node.AttributeValue(Xtype);
			Assert.Equal("uml:Class", attribute);
		}
	}
}

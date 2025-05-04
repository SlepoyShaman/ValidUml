using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.ClassDiagrams
{
	public class ClassEntities
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\test1.xml";
			var diagram = new ClassDiagram(diagramPath);

			string[] interfaces = ["", ""];
			Assert.Equal(interfaces.Length, diagram.GetInterfases().Length);
			foreach (var node in diagram.GetInterfases())
			{
				var name = node.AttributeValue(Xname);
				Assert.Contains(name, interfaces);
			}

			string[] classes = ["", ""];
			Assert.Equal(classes.Length, diagram.GetClasses().Length);
			foreach (var node in diagram.GetClasses())
			{
				var name = node.AttributeValue(Xname);
				Assert.Contains(name, classes);
			}
		}
	}
}

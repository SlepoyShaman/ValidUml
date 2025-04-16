using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;

namespace ValidUml.InUse.Tests.ClassDiagrams
{
	public class RoutineCheck
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\test.xml";
			var diagram = new ClassDiagram(diagramPath);

			foreach (var node in diagram.GetInterfases())
			{
				var methods = node.GetMethods();
				Assert.NotEmpty(methods);
			}

			foreach (var node in diagram.GetClasses())
			{
				var fields = node.GetFields();
				Assert.NotEmpty(fields);

				var methods = node.GetMethods();
				Assert.NotEmpty(methods);
			}
		}
	}
}

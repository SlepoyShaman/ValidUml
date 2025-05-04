using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.ClassDiagrams
{
	public class AllEntities
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\test1.xml";
			var diagram = new ClassDiagram(diagramPath);

			HashSet<string> names = ["Класс1", "Класс2", "Интерфейс1", "Интерфейс2"];
			var entities = diagram.AllEntities();

			Assert.Equal(names.Count, entities.Length);
			foreach (var entity in diagram.AllEntities())
			{
				var name = entity.AttributeValue(Xname);
				Assert.Contains(name, names);
			}
		}
	}
}

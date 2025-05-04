using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.Filters;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.Filters
{
	public class Name
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\relations.xml";
			var diagram = new ClassDiagram(diagramPath);

			string[] should = ["Class A.1", "Class A.2"];
			var filtered = NameFilter.Execute(diagram.GetClasses(), "Class A.*");
			Assert.Equal(should.Length, filtered.Count());
			foreach (var child in filtered)
			{
				var name = child.AttributeValue(Xname);
				Assert.Contains(name, should);
			}
		}
	}
}

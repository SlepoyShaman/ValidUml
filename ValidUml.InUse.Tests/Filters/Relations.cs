using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.Filters;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.Filters
{
	public class Relations
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var diagramPath = "D:\\diplom\\relations.xml";
			var diagram = new ClassDiagram(diagramPath);

			var filtered = ImplementingFilter.Execute(diagram.GetClasses(), "Interface", diagram);
			string[] should = ["Class A", "Class B", "Class B2"];
			Assert.Equal(should.Length, filtered.Count());
			foreach (var child in filtered)
			{
				var name = child.AttributeValue(Xname);
				Assert.Contains(name, should);
			}
		}
	}
}

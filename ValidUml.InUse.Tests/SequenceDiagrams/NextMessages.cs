using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.SequenceDiagrams
{
	public class NextMessages
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var path = "D:\\diplom\\messages.xml";
			var diagram = new SequenceDiagram(path);

			var actor = diagram.GetActors().FirstOrDefault();
			Assert.NotNull(actor);
			string[] childs = ["Object A", "Object B"];
			var objects = diagram.GetNextInSequens(actor);
			Assert.Equal(objects.Length, childs.Length);
			foreach (var next in objects)
			{
				Assert.Contains(next.AttributeValue(Xname), childs);
			}
		}
	}
}

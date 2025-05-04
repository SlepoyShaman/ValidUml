using System.Text;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.InUse.Tests.SequenceDiagrams
{
	public class SequenceEntities
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var path = "D:\\diplom\\test3.xml";
			var diagram = new SequenceDiagram(path);

			string[] actors = ["Пользователь"];
			Assert.Equal(actors.Length, diagram.GetActors().Length);
			foreach (var actor in diagram.GetActors())
			{
				var name = actor.AttributeValue(Xname);
				Assert.Contains(name, actors);
			}

			string[] objects = ["Система"];
			Assert.Equal(objects.Length, diagram.GetObjects().Length);
			foreach (var obj in diagram.GetObjects())
			{
				var name = obj.AttributeValue(Xname);
				Assert.Contains(name, objects);
			}

			string[] loops = ["Цикл обработки"];
			Assert.Equal(loops.Length, diagram.GetLoops().Length);
			foreach (var loop in diagram.GetLoops())
			{
				var name = loop.AttributeValue(Xname);
				Assert.Contains(name, loops);
			}
		}
	}
}

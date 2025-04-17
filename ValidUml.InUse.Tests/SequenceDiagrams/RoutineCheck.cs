using System.Text;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.SequenceRuleValidators;

namespace ValidUml.InUse.Tests.SequenceDiagrams
{
	public class RoutineCheck
	{
		[Fact]
		public void Execute()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var path = "D:\\diplom\\seqrep.xml";
			var diagram = new SequenceDiagram(path);
			var validator = new CorrectSequenceValidator(diagram);

			var actors = diagram.GetActors();
			foreach (var actor in actors)
			{
				var actorResult = validator.Validate(actor);
				Assert.Null(actorResult);
			}

			var objects = diagram.GetObjects();
			foreach (var obj in objects)
			{
				var objectResult = validator.Validate(obj);
				Assert.Null(objectResult);
			}
		}
	}
}

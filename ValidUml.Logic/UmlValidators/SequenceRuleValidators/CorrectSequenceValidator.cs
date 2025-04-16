using System.Xml;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlValidators.SequenceRuleValidators
{
	public class CorrectSequenceValidator : IRuleValidator
	{
		private readonly SequenceDiagram _diagram;
		public CorrectSequenceValidator(SequenceDiagram diagram)
		{
			_diagram = diagram;
		}

		public string? Validate(XmlNode node)
		{
			var next = _diagram.GetNextInSequens(node);
			var linesTo = next.Length;
			var linesBack = next.DistinctBy(n => n.AttributeValue(Xid))
				.SelectMany(_diagram.GetPastInSequens)
				.Where(n => n.AttributeValue(Xid) == node.AttributeValue(Xid))
				.Count();

			if (linesTo == linesBack) return null;
			return $"У {node.AttributeValue(Xname)} количество вызовов не соответствует количеству ответов";
		}
	}
}

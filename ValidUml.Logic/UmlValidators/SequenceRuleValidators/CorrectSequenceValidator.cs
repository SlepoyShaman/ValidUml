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
			var errorMessage = $"У {node.AttributeValue(Xname)} количество вызовов не соответствует количеству ответов";
			var links = node.GetChildNode(Xlinks)
				.Childs()
				.Where(l => l.Name == Xsequence);

			var linksTo = links.Where(l => l.AttributeValue(Xstart) == node.AttributeValue(Xid))
				.GroupBy(l => l.AttributeValue(Xend))
				.ToDictionary(g => g.Key, g => g.Count());

			var linksFrom = links.Where(l => l.AttributeValue(Xend) == node.AttributeValue(Xid))
				.GroupBy(l => l.AttributeValue(Xstart))
				.ToDictionary(g => g.Key, g => g.Count());

			foreach (var pair in linksTo)
			{
				if (!linksFrom.TryGetValue(pair.Key, out var count))
					return errorMessage;

				if (count != pair.Value) return errorMessage;
			}

			return null;
		}
	}
}

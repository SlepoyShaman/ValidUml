using System.Xml;

namespace ValidUml.Logic.UmlValidators.RuleValidators
{
	public interface IRuleValidator
	{
		public string? Validate(XmlNode node);
	}
}

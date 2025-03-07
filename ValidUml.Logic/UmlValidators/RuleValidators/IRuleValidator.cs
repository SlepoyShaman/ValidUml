using System.Xml;

namespace ValidUml.Logic.UmlValidators.RuleValidators
{
	internal interface IRuleValidator
	{
		public string? Validate(XmlNode node);
	}
}

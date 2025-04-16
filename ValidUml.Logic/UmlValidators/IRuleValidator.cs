using System.Xml;

namespace ValidUml.Logic.UmlValidators
{
	public interface IRuleValidator
	{
		public string? Validate(XmlNode node);
	}
}

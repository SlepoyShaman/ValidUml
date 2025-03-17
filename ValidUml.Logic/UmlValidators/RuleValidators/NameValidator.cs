using System.Text.RegularExpressions;
using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlValidators.RuleValidators
{
	internal class NameValidator : IRuleValidator
	{
		private readonly string _name;
		public NameValidator(string name)
		{
			_name = name;
		}

		public string? Validate(XmlNode node)
		{
			var regex = new Regex(_name);
			if (regex.IsMatch(node.AttributeValue(Xname)))
				return null;

			return $"{node.AttributeValue(Xname)} не соответствует заданному выражению {_name}";
		}
	}
}

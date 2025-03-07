using System.Text.RegularExpressions;
using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlValidators.RuleValidators
{
	internal class ContainsPropertiesValidator : IRuleValidator
	{
		private readonly string _name;
		public ContainsPropertiesValidator(string name)
		{
			_name = name;
		}

		public string? Validate(XmlNode node)
		{
			var regex = new Regex(_name);
			if (node.GetFields().Any(f => regex.IsMatch(f.Name)))
				return null;

			return $"{node.AttributeValue(Xname)} не содержит аттрибута {_name}";
		}
	}

	internal class ContainsMethodsValidator : IRuleValidator
	{
		private readonly string _name;
		public ContainsMethodsValidator(string name)
		{
			_name = name;
		}

		public string? Validate(XmlNode node)
		{
			var regex = new Regex(_name);
			if (node.GetMethods().Any(f => regex.IsMatch(f.Name)))
				return null;

			return $"{node.AttributeValue(Xname)} не содержит метода {_name}";
		}
	}

	internal class NotContainsPropertiesValidator : IRuleValidator
	{
		private readonly string _name;
		public NotContainsPropertiesValidator(string name)
		{
			_name = name;
		}

		public string? Validate(XmlNode node)
		{
			var regex = new Regex(_name);
			if (node.GetFields().Any(f => !regex.IsMatch(f.Name)))
				return null;

			return $"{node.AttributeValue(Xname)} содержит аттрибута {_name}";
		}
	}

	internal class NotContainsMethodsValidator : IRuleValidator
	{
		private readonly string _name;
		public NotContainsMethodsValidator(string name)
		{
			_name = name;
		}

		public string? Validate(XmlNode node)
		{
			var regex = new Regex(_name);
			if (node.GetMethods().Any(f => !regex.IsMatch(f.Name)))
				return null;

			return $"{node.AttributeValue(Xname)} содержит метода {_name}";
		}
	}
}

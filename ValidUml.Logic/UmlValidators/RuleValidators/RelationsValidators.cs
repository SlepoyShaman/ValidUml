using System.Data;
using System.Xml;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.Filters;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlValidators.RuleValidators
{
	internal class ImplementsValidator : IRuleValidator
	{
		private readonly string _name;
		private readonly ClassDiagram _diagram;
		public ImplementsValidator(string name, ClassDiagram diagram)
		{
			_name = name;
			_diagram = diagram;
		}

		public string? Validate(XmlNode node)
		{
			var implimentsSet = ImplementingFilter.Execute(_diagram.GetClasses(), _name, _diagram)
				.Select(c => c.AttributeValue(Xid)).ToHashSet();

			if (implimentsSet.Contains(node.AttributeValue(Xid)))
			{
				return null;
			}

			return $"{node.AttributeValue(Xname)} не реализует интерфейс {_name}";
		}
	}

	internal class ChildsOfValidator : IRuleValidator
	{
		private readonly string _name;
		private readonly ClassDiagram _diagram;
		public ChildsOfValidator(string name, ClassDiagram diagram)
		{
			_name = name;
			_diagram = diagram;
		}

		public string? Validate(XmlNode node)
		{
			var implimentsSet = ChildsOfFilter.Execute(_diagram.GetClasses(), _name, _diagram)
				.Select(c => c.AttributeValue(Xid)).ToHashSet();

			if (implimentsSet.Contains(node.AttributeValue(Xid)))
			{
				return null;
			}

			return $"{node.AttributeValue(Xname)} не наследует класс {_name}";
		}
	}
}

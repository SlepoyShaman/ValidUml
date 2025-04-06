using System.Text.RegularExpressions;
using System.Xml;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlValidators.Filters
{
	public static class ImplementingFilter
	{
		public static IEnumerable<XmlNode> Execute(XmlNode[] data, string filterValue, ClassDiagram diagram)
		{
			var dataSet = data.Select(d => d.AttributeValue(Xid)).ToHashSet();
			var interfaceRegex = new Regex(filterValue);
			var interfaces = diagram.GetInterfases().Where(n => interfaceRegex.IsMatch(n.AttributeValue(Xname)));
			return interfaces.SelectMany(diagram.GetAllImplementations)
				.Where(e => dataSet.Contains(e.AttributeValue(Xid)));
		}
	}
}

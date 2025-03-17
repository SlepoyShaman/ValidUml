using System.Text.RegularExpressions;
using System.Xml;
using ValidUml.Logic.UmlExtensions;
using ValidUml.Logic.UmlParsers;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlValidators.Filters
{
	internal static class ChildsOfFilter
	{
		public static IEnumerable<XmlNode> Execute(XmlNode[] data, string filterValue, ClassDiagram diagram)
		{
			var dataSet = data.Select(d => d.AttributeValue(Xid)).ToHashSet();
			var interfaceRegex = new Regex(filterValue);
			var interfaces = diagram.GetClasses().Where(n => interfaceRegex.IsMatch(n.AttributeValue(Xname)));
			return interfaces.SelectMany(diagram.GetHierarchyChilds)
				.Where(e => dataSet.Contains(e.AttributeValue(Xid)));
		}
	}
}

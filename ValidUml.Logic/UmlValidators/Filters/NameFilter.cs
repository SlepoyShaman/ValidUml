using System.Text.RegularExpressions;
using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlValidators.Filters
{
	public static class NameFilter
	{
		public static IEnumerable<XmlNode> Execute(XmlNode[] data, string filterValue)
		{
			var regex = new Regex(filterValue);
			return data.Where(n => regex.IsMatch(n.AttributeValue(Xname)));
		}
	}
}

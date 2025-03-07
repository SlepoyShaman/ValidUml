using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.Models.ClassDiagram
{
	public record Field(string Scope, string Type, string Name)
	{
		public static Field FromNode(XmlNode node)
		{
			var name = node.AttributeValue(Xname);
			var scope = node.AttributeValue(Xscope);
			var type = node.GetChildNode("properties")
				.AttributeValue(XumlType);

			return new Field(scope, type, name);
		}
	}
}

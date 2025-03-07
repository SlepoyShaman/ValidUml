using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.Models.ClassDiagram
{
	public record Method(string ReturnType, string Scope, string Name, string[] ParamsType)
	{
		public static Method FromNode(XmlNode node)
		{
			var name = node.AttributeValue(Xname);
			var scope = node.AttributeValue(Xscope);
			var type = node.GetChildNode("type")
				.AttributeValue(XumlType);
			var paramsType = new List<string>();
			foreach (XmlNode parametr in node.GetChildNode("parameters").ChildNodes)
			{
				var parametrType = parametr.GetChildNode("properties").AttributeValue(XumlType);
				if (parametrType == "void") continue;
				paramsType.Add(parametrType);
			}

			return new Method(type, scope, name, [.. paramsType]);
		}
	}
}

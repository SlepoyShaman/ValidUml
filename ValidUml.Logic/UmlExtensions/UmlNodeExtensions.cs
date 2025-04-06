using System.Xml;

namespace ValidUml.Logic.UmlExtensions
{
	public static class UmlNodeExtensions
	{
		public static XmlNode GetChildNode(this XmlNode node, string name)
		{
			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.Name != name) continue;
				return childNode;
			}

			throw new Exception($"Не найдена нода {name}");
		}

		public static string AttributeValue(this XmlNode node, string attribute)
		{
			if (node.Attributes is null) throw new Exception($"нода {node.Name} не содержит атрибутов");
			foreach (XmlAttribute xmlAttribute in node.Attributes)
			{
				if (xmlAttribute.Name != attribute) continue;
				return xmlAttribute.Value;
			}

			throw new Exception($"у ноды {node.Name} нет атрибута {attribute}");
		}

		public static IEnumerable<XmlNode> Childs(this XmlNode node)
		{
			return node.ChildNodes.Cast<XmlNode>();
		}
	}
}

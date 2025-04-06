using System.Xml;
using ValidUml.Logic.Models.ClassDiagram;

namespace ValidUml.Logic.UmlExtensions
{
	public static class ClassDiagramNodeExtensions
	{
		public static Field[] GetFields(this XmlNode node)
		{
			return node.GetChildNode("attributes")
				.Childs()
				.Select(Field.FromNode)
				.ToArray();
		}

		public static Method[] GetMethods(this XmlNode node)
		{
			return node.GetChildNode("operations")
				.Childs()
				.Select(Method.FromNode)
				.ToArray();
		}
	}
}

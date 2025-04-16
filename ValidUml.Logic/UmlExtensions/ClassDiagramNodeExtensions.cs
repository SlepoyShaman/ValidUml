using System.Xml;
using ValidUml.Logic.Models.ClassDiagram;

namespace ValidUml.Logic.UmlExtensions
{
	public static class ClassDiagramNodeExtensions
	{
		public static Field[] GetFields(this XmlNode node)
		{
			try
			{
				return node.GetChildNode("attributes")
					.Childs()
					.Select(Field.FromNode)
					.ToArray();
			}
			catch
			{
				return [];
			}
		}

		public static Method[] GetMethods(this XmlNode node)
		{
			try
			{
				return node.GetChildNode("operations")
					.Childs()
					.Select(Method.FromNode)
					.ToArray();
			}
			catch
			{
				return [];
			}
		}
	}
}

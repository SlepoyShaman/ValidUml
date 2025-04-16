using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlParsers
{
	public class SequenceDiagram : BaseDiagram
	{
		public SequenceDiagram(string xmlPath) : base(xmlPath) { }

		public XmlNode[] GetActors()
		{
			return Elements.Where(c => c.AttributeValue(Xtype) == "uml:Actor")
				.ToArray();
		}

		public XmlNode[] GetObjects()
		{
			return Elements.Where(c => c.AttributeValue(Xtype) == "uml:Object")
				.ToArray();
		}

		public XmlNode[] GetLoops()
		{
			return Elements.Where(c => c.AttributeValue(Xtype) == "uml:InteractionFragment")
				.ToArray();
		}

		public XmlNode[] GetNextInSequens(XmlNode node)
		{
			return [.. GetLinkedChilds(node, Xsequence)];
		}

		public XmlNode[] GetPastInSequens(XmlNode node)
		{
			return [.. GetLinkedParents(node, Xsequence)];
		}
	}
}

using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlParsers
{
	public class ClassDiagram : BaseDiagram
	{
		public ClassDiagram(string xmlPath) : base(xmlPath) { }

		public XmlNode[] GetClasses()
		{
			return Elements.Where(c => c.AttributeValue(Xtype) == "uml:Class")
				.ToArray();
		}

		public XmlNode[] GetInterfases()
		{
			return Elements.Where(c => c.AttributeValue(Xtype) == "uml:Interface")
				.ToArray();
		}

		public XmlNode[] GetHierarchyChilds(XmlNode node)
		{
			var result = new List<XmlNode>();
			var queue = new Queue<XmlNode>();
			queue.Enqueue(node);

			while (queue.Count > 0)
			{
				var current = queue.Dequeue();
				result.Add(current);
				foreach (var child in GetLinkedChilds(current, Xgeneralization))
				{
					queue.Enqueue(child);
				}
			}
			return [.. result];
		}

		public XmlNode[] GetAllImplementations(XmlNode node)
		{
			return GetLinkedChilds(node, Ximplementation)
				.SelectMany(GetHierarchyChilds)
				.ToArray();
		}

		public XmlNode[] GetAggregatedElements(XmlNode node)
		{
			return [.. GetLinkedChilds(node, Xaggregation)];
		}
	}
}

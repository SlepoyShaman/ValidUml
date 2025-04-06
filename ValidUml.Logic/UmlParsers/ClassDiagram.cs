using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlParsers
{
	public class ClassDiagram
	{
		private readonly XmlNode _umlModel;
		public ClassDiagram(string xmlPath)
		{
			var xmlDocument = new XmlDocument();
			using var fs = File.OpenRead(xmlPath);
			xmlDocument.Load(fs);
			var root = xmlDocument.DocumentElement ?? throw new Exception("пустой рут");
			_umlModel = root.GetChildNode("xmi:Extension");
		}

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

		public XmlNode[] AllEntities()
		{
			return Elements.ToArray();
		}

		public XmlNode GetById(string id)
		{
			return Elements.FirstOrDefault(c => c.AttributeValue(Xid) == id)
				?? throw new KeyNotFoundException($"Не найдена нода с id {id}");
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

		private IEnumerable<XmlNode> Elements => _umlModel.GetChildNode("elements").Childs();
		private List<XmlNode> GetLinkedChilds(XmlNode node, string linkType)
		{
			var result = new List<XmlNode>();
			var links = node.GetChildNode(Xlinks)
				.Childs()
				.Where(l => l.Name == linkType);

			foreach (var link in links)
			{
				var id = link.AttributeValue(Xstart);
				if (id == node.AttributeValue(Xid)) continue;
				result.Add(GetById(id));
			}

			return result;
		}
	}
}

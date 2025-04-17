using System.Xml;
using ValidUml.Logic.UmlExtensions;
using static ValidUml.Logic.UmlParsers.XmiUmlNames;

namespace ValidUml.Logic.UmlParsers
{
	public abstract class BaseDiagram
	{
		protected readonly XmlNode _umlModel;
		protected BaseDiagram(string xmlPath)
		{
			var xmlDocument = new XmlDocument();
			using var fs = File.OpenRead(xmlPath);
			xmlDocument.Load(fs);
			var root = xmlDocument.DocumentElement ?? throw new Exception("пустой рут");
			_umlModel = root.GetChildNode("xmi:Extension");
		}

		public XmlNode[] AllEntities()
		{
			return [.. Elements];
		}

		protected IEnumerable<XmlNode> Elements => _umlModel.GetChildNode("elements").Childs();

		protected XmlNode GetById(string id)
		{
			return Elements.FirstOrDefault(c => c.AttributeValue(Xid) == id)
				?? throw new KeyNotFoundException($"Не найдена нода с id {id}");
		}

		protected virtual List<XmlNode> GetLinkedChilds(XmlNode node, string linkType)
		{
			return GetLinked(node, linkType, Xstart);
		}

		protected virtual List<XmlNode> GetLinkedParents(XmlNode node, string linkType)
		{
			return GetLinked(node, linkType, Xend);
		}

		protected List<XmlNode> GetLinked(XmlNode node, string linkType, string linkPlace)
		{
			var result = new List<XmlNode>();
			var links = node.GetChildNode(Xlinks)
				.Childs()
				.Where(l => l.Name == linkType);

			foreach (var link in links)
			{
				var id = link.AttributeValue(linkPlace);
				if (id == node.AttributeValue(Xid)) continue;
				result.Add(GetById(id));
			}

			return result;
		}
	}
}

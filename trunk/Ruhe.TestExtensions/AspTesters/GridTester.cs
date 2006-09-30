using System;
using System.Xml;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;

namespace Ruhe.TestExtensions.AspTesters {
	public enum GridButtonType {
		Edit,
		Cancel,
		Update,
		Delete
	}

	public class GridTester : DataGridTester {
		public GridTester(string aspId, Tester container) : base(aspId, container) {}

		public void ClickButton(GridButtonType buttonType, int index) {
			string buttonXPath = String.Format("//a[. = \"{0}\"]", buttonType);
			XmlNode editButtonNode = Element.SelectNodes(buttonXPath)[index];
			string anchorPostBackHref = editButtonNode.Attributes["href"].Value;
			PostBack(anchorPostBackHref);
		}

		public XmlElement GetElement() {
			return Element;
		}

		public int EditItemIndex {
			get {
				XmlNodeList inputElements;
				XmlNodeList textAreaElements;
				XmlNodeList selectElements;
				XmlElement rowElement;
				int elementNumber;

				for (int i = 0; i < RowCount; i++) {
					Row row = GetRow(i);
					rowElement = ControlTesterUtilities.GetXmlElement(row);
					inputElements = rowElement.SelectNodes(".//input");
					textAreaElements = rowElement.SelectNodes(".//textarea");
					selectElements = rowElement.SelectNodes(".//select");
					elementNumber = inputElements.Count + textAreaElements.Count + selectElements.Count;
					if (elementNumber > 0)
						return i;
				}
				return -1;
			}
		}
	}
}
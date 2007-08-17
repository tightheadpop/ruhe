using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
	public class NonBreakingSpace : Literal {
		private int numberOfSpaces;
		private const string nonBreakingSpace = "&nbsp;";

		public NonBreakingSpace() : this(1) {}

		public NonBreakingSpace(int numberOfSpaces) {
			if (numberOfSpaces > 0) {
				this.numberOfSpaces = numberOfSpaces;
			}
			else {
				throw new ArgumentOutOfRangeException("numberOfSpaces", numberOfSpaces, "must be greater than or equal to one");
			}
		}

		protected override void Render(HtmlTextWriter writer) {
			for (int i = 0; i < numberOfSpaces; i++) {
				writer.Write(nonBreakingSpace);
			}
		}
	}
}
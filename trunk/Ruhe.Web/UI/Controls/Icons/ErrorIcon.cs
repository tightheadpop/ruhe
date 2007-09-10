namespace Ruhe.Web.UI.Controls.Icons {
	public class ErrorIcon : ImageIcon {
		public ErrorIcon() {
			ImageUrl = "~/images/error.gif";
		}

		public ErrorIcon(string toolTip) : base(toolTip) {
			ImageUrl = "~/images/error.gif";
		}

		public override string Name {
			get { return "Error"; }
		}

		public override string Description {
			get { return "The marked field has a validation error."; }
		}
	}
}
namespace Ruhe.Web.UI.Controls.Icons {
	public interface IIcon {
		string Name { get; }
		string Description { get; }
		string ToolTip { get; set; }
	}
}
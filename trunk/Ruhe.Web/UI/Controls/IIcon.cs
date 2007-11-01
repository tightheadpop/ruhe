namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// All IIcon instances are auto-discovered by any <see cref="Legend"/> controls
    /// </summary>
    public interface IIcon {
        string Name { get; }
        string Description { get; }
        string ToolTip { get; set; }
    }
}
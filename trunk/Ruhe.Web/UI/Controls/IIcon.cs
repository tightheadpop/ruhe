namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// All IIcon instances are auto-discovered by any <see cref="Legend"/> controls
    /// </summary>
    public interface IIcon {
        string Description { get; }
        string Name { get; }
        string ToolTip { get; }
    }
}
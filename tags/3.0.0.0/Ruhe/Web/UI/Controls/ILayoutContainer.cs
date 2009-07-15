namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// May acts as a simple container for a <see cref="LabeledControlPanel"/>
    /// such that all child controls are effectively extracted and used directly
    /// as child controls of the parent. This interface is useful for grouping controls that are hidden 
    /// or shown as a whole.
    /// </summary>
    public interface ILayoutContainer {
        /// <summary>
        /// Returning true causes this control not to be rendered directly by a
        /// <see cref="LabeledControlPanel"/>, but rather to have its child controls
        /// rendered.
        /// </summary>
        bool IsLayoutContainer { get; }
    }
}
namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Defines the properties required for meaningful layout within a
    /// <see cref="LabeledControlPanel"/>
    /// </summary>
    public interface ILabeledControl {
        /// <summary>
        /// The descriptive name associated with a control rendered as a <c>&lt;label&gt;</c>
        /// </summary>
        string LabelText { get; set; }
        /// <summary>
        /// Additional information intended to help the user understand the
        /// format of the desired input
        /// </summary>
        string FormatText { get; set; }
    }
}
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Defines the basic expectations for an input control that is useful
    /// with the Ruhe framework. 
    /// </summary>
    public interface IInputControl : ILabeledControl {
        /// <summary>
        /// Gets the <see cref="Control.ClientID"/> of the control to use in client script
        /// such as validation.
        /// </summary>
        string DefaultElementClientId { get; }
        /// <summary>
        /// The <see cref="Control.ID"/> given to <see cref="BaseValidator"/>s
        /// </summary>
        string ValidatedControlId { get; }
        /// <summary>
        /// The single message given to users to indicate invalid input. This message
        /// is best written as a full sentence that describes in full the expectations
        /// for input format.
        /// </summary>
        string ErrorMessage { get; set; }
        /// <summary>
        /// When implemented, defines the behavior of what it means to be read-only.
        /// <seealso cref="InputTextBox.ReadOnly"/>
        /// <seealso cref="InputDropDownList.ReadOnly"/>
        /// </summary>
        bool ReadOnly { get; set; }
        /// <summary>
        /// Gets or sets whether the control requires user input
        /// </summary>
        bool Required { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="BaseValidator.ValidationGroup"/> 
        /// assigned to all child validators.
        /// </summary>
        string ValidationGroup { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="BaseValidator.EnableClientScript"/> of all child validators.
        /// </summary>
        bool EnableClientScript { get; set; }
        /// <summary>
        /// Sets the control's input back to a 'blank' state.
        /// </summary>
        void Clear();
    }
}
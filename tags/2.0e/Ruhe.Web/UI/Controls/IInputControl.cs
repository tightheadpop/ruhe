namespace Ruhe.Web.UI.Controls {
    public interface IInputControl : ILabeledControl {
        string DefaultElementClientId { get; }
        string ValidatedControlId { get; }
        string ErrorMessage { get; set; }
        //string Value { get; set; }
        bool ReadOnly { get; set; }
        bool Required { get; set; }
        string ValidationGroup { get; set; }
        bool EnableClientScript { get; set; }
        void Clear();
    }
}
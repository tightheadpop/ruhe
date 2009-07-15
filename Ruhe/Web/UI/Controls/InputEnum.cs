using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax;

namespace Ruhe.Web.UI.Controls {
    //TODO : IInputControl
    [Browsable(false)]
    [DesignTimeVisible(false)]
    public class InputEnumeration<T> : InputEnum where T : struct {
        public InputEnumeration() : base(typeof(T)) {
            BindValues();
        }

        public T? Value {
            get { return string.IsNullOrEmpty(List.SelectedValue) ? default(T?) : ((object) List.SelectedValue).As<T>(); }
            set { List.SelectedValue = (value.HasValue) ? value.Value.ToString() : string.Empty; }
        }

        protected void BindValues() {
            EnsureChildControls();
            List.BindList(Enum.GetNames(typeof(T)));
        }
    }

    [ControlBuilder(typeof(InputEnumControlBuilder))]
    public class InputEnum : Control, IInputControl {
        private Type enumType;
        private InputDropDownList list;

        internal InputEnum(Type enumType) {
            this.enumType = enumType;
        }

        public override ControlCollection Controls {
            get {
                EnsureChildControls();
                return base.Controls;
            }
        }

        public string DefaultElementClientId {
            get { return List.DefaultElementClientId; }
        }

        public bool EnableClientScript {
            get { return List.EnableClientScript; }
            set { List.EnableClientScript = value; }
        }

        /// <summary>
        /// Gets or sets the Enum type. This property must be set at design time.
        /// </summary>
        [DesignOnly(true)]
        public string Enumtype {
            get { return enumType.FullName; }
            set { enumType = Type.GetType(value); }
        }

        public string ErrorMessage {
            get { return List.ErrorMessage; }
            set { List.ErrorMessage = value; }
        }

        public string FormatText {
            get { return List.FormatText; }
            set { List.FormatText = value; }
        }

        public override string ID {
            get { return list.ID; }
            set { list.ID = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control should emit
        /// and blank <see cref="ListItem"/> before other items. The blank item
        /// is not displayed unless there is at least one other <see cref="ListItem"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool InitialBlank {
            get {
                EnsureChildControls();
                return List.Items.Count > 0 && List.Items[0].Text == string.Empty;
            }
            set {
                EnsureChildControls();
                if (value && !InitialBlank)
                    List.Items.Insert(0, new ListItem());
                else if (!value && InitialBlank)
                    List.Items.RemoveAt(0);
            }
        }

        public ListItemCollection Items {
            get {
                EnsureChildControls();
                return List.Items;
            }
        }

        public string LabelText {
            get { return List.LabelText; }
            set { List.LabelText = value; }
        }

        protected InputDropDownList List {
            get { return list; }
        }

        public bool ReadOnly {
            get { return List.ReadOnly; }
            set { List.ReadOnly = value; }
        }

        public bool Required {
            get { return List.Required; }
            set { List.Required = value; }
        }

        public string ValidatedControlId {
            get { return List.ValidatedControlId; }
        }

        public string ValidationGroup {
            get { return List.ValidationGroup; }
            set { List.ValidationGroup = value; }
        }

        public void Clear() {
            List.Clear();
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            list = new InputDropDownList();
            Controls.Add(List);
        }
    }

    /// <summary>
    /// Parses xml of InputEnum tag into generic InputEnum&lt;T&gt;
    /// </summary>
    public class InputEnumControlBuilder : ControlBuilder {
        [DebuggerStepThrough]
        public override void Init(TemplateParser parser, ControlBuilder parentBuilder, Type type, string tagName, string id, IDictionary attribs) {
            var enumTypeName = (string) attribs["EnumType"];
            var enumType = Type.GetType(enumTypeName);

            if (enumType == null)
                throw new ArgumentNullException(string.Format("{0} cannot be found", enumTypeName));

            if (!enumType.IsEnum)
                throw new ArgumentException(string.Format("{0} is not an enumeration", enumTypeName));

            var dropDownType = typeof(InputEnumeration<>).MakeGenericType(enumType);
            base.Init(parser, parentBuilder, dropDownType, tagName, id, attribs);
        }
    }
}
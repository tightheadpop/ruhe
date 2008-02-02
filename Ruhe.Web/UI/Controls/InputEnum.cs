using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
    //TODO : IInputControl
    [Browsable(false)]
    [DesignTimeVisible(false)]
    public class InputEnumeration<T> : InputEnum where T : struct {
        public InputEnumeration() : base(typeof(T)) {
            BindValues();
        }

        protected void BindValues() {
            EnsureChildControls();
            List.BindList(Enum.GetNames(typeof(T)));
        }

        public T? Value {
            get { return string.IsNullOrEmpty(List.SelectedValue) ? default(T?) : Reflector.ConvertToEnum<T>(List.SelectedValue); }
            set { List.SelectedValue = (value.HasValue) ? value.Value.ToString() : string.Empty; }
        }
    }

    [ControlBuilder(typeof(InputEnumControlBuilder))]
    public class InputEnum : Control, IInputControl {
        private InputDropDownList list;
        private Type enumType;

        internal InputEnum(Type enumType) {
            this.enumType = enumType;
        }

        /// <summary>
        /// Gets or sets the Enum type. This property must be set at design time.
        /// </summary>
        [DesignOnly(true)]
        public string Enumtype {
            get { return enumType.FullName; }
            set { enumType = Type.GetType(value); }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            list = new InputDropDownList();
            Controls.Add(List);
        }

        public override string ID {
            get { return list.ID; }
            set { list.ID = value; }
        }

        public override ControlCollection Controls {
            get {
                EnsureChildControls();
                return base.Controls;
            }
        }

        public ListItemCollection Items {
            get {
                EnsureChildControls();
                return List.Items;
            }
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

        public string DefaultElementClientId {
            get { return List.DefaultElementClientId; }
        }

        public string ValidatedControlId {
            get { return List.ValidatedControlId; }
        }

        public string ErrorMessage {
            get { return List.ErrorMessage; }
            set { List.ErrorMessage = value; }
        }

        public bool ReadOnly {
            get { return List.ReadOnly; }
            set { List.ReadOnly = value; }
        }

        public bool Required {
            get { return List.Required; }
            set { List.Required = value; }
        }

        public string ValidationGroup {
            get { return List.ValidationGroup; }
            set { List.ValidationGroup = value; }
        }

        public bool EnableClientScript {
            get { return List.EnableClientScript; }
            set { List.EnableClientScript = value; }
        }

        public void Clear() {
            List.Clear();
        }

        public string LabelText {
            get { return List.LabelText; }
            set { List.LabelText = value; }
        }

        public string FormatText {
            get { return List.FormatText; }
            set { List.FormatText = value; }
        }

        protected InputDropDownList List {
            get { return list; }
        }
    }

    /// <summary>
    /// Parses xml of InputEnum tag into generic InputEnum&lt;T&gt;
    /// </summary>
    public class InputEnumControlBuilder : ControlBuilder {
        [DebuggerStepThrough]
        public override void Init(TemplateParser parser, ControlBuilder parentBuilder, Type type, string tagName, string id, IDictionary attribs) {
            string enumTypeName = (string) attribs["EnumType"];
            Type enumType = Type.GetType(enumTypeName);

            if (enumType == null)
                throw new ArgumentNullException(string.Format("{0} cannot be found", enumTypeName));

            if (!enumType.IsEnum)
                throw new ArgumentException(string.Format("{0} is not an enumeration", enumTypeName));

            Type dropDownType = typeof(InputEnumeration<>).MakeGenericType(enumType);
            base.Init(parser, parentBuilder, dropDownType, tagName, id, attribs);
        }
    }
}
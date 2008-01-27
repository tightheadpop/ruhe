using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Provides a simplified user input that respects the user's culture settings.
    /// Includes a pop-up calendar for input using the mouse.
    /// </summary>
    public class InputDate : AbstractValueTypeInput<DateTime> {
        private CalendarExtender calendar;
        private Image image;
        private InputDateValidator dateValidator;

        protected override void AssignIdsToChildControls() {
            base.AssignIdsToChildControls();
            dateValidator.ID = ID + "_dateValidator";
            dateValidator.ControlToValidate = ID;
        }

        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.String; }
        }

        protected override string KeystrokeFilter {
            get { return "Ruhe$DATE"; }
        }

        protected override string Adapt(DateTime? value) {
            return value.HasValue ? value.Value.ToString(DatePattern) : string.Empty;
        }

        protected override DateTime? Adapt(string value) {
            if (string.IsNullOrEmpty(value))
                return null;
            else {
                DateTime result;
                if (DateTime.TryParseExact(value, DatePattern, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.AllowWhiteSpaces, out result))
                    return result;
                return null;
            }
        }

        public virtual string DatePattern {
            get {
                EnsureChildControls();
                return (string) ViewState["DatePattern"]
                       ?? RuheConfigurationSection.GetCurrent().DateFormat.Value;
            }
            set {
                EnsureChildControls();
                ViewState["DatePattern"] = value;
            }
        }

        public bool DefaultToToday {
            get { return Convert.ToBoolean(ViewState["DefaultToToday"]); }
            set {
                ViewState["DefaultToToday"] = value;
                if (!Value.HasValue && value)
                    Value = DateTime.Today;
            }
        }

        public override bool ReadOnly {
            get { return base.ReadOnly; }
            set {
                EnsureChildControls();
                base.ReadOnly = value;
                image.Visible = !value;
            }
        }

        protected override void CreateChildControls() {
            Controls.Add(CreateCalendarButton());
            base.CreateChildControls();
            Controls.Add(CreateDateValidator());
            Controls.Add(CreateCalendarExtender());
        }

        private InputDateValidator CreateDateValidator() {
            dateValidator = new InputDateValidator();
            return dateValidator;
        }

        private Image CreateCalendarButton() {
            image = new Image();
            image.AlternateText = "Select a date";
            image.ImageAlign = ImageAlign.AbsMiddle;
            image.Style[HtmlTextWriterStyle.Padding] = "3px";
            return image;
        }

        private CalendarExtender CreateCalendarExtender() {
            calendar = new CalendarExtender();
            calendar.Format = DatePattern;
            return calendar;
        }

        protected override void OnLoad(EventArgs e) {
            image.ID = ID + "_calendar";
            image.ImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(), "Ruhe.Web.Resources.calendar.png");
            calendar.TargetControlID = ID;
            calendar.PopupButtonID = image.ID;
            calendar.PopupPosition = CalendarPosition.BottomLeft;
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            Page.ClientScript.RegisterExpandoAttribute(ClientID, "datePattern", DatePattern);
        }
    }
}
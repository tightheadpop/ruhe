using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ruhe.Common.Utilities;
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
            return value.HasValue ? value.Value.ToString(Format) : string.Empty;
        }

        protected override DateTime? Adapt(string value) {
            if (string.IsNullOrEmpty(value))
                return null;
            else {
                DateTime result;
                if (DateTime.TryParseExact(value, Format, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.AllowWhiteSpaces, out result))
                    return result;
                return null;
            }
        }

        public virtual string Format {
            get {
                EnsureChildControls();
                return StringUtilities.TrimToNull((string) ViewState["Format"])
                       ?? RuheConfiguration.DateFormat;
            }
            set {
                EnsureChildControls();
                ViewState["Format"] = value;
                calendar.Format = value;
            }
        }

        public override string FormatText {
            get { return base.FormatText ?? RuheConfiguration.DateFormatText; }
            set { base.FormatText = value; }
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
                calendar.EnabledOnClient = calendar.Enabled = !value;
                dateValidator.Visible = dateValidator.Enabled = !value;
            }
        }

        protected override void CreateChildControls() {
            Controls.Add(CreateCalendarButton());
            //need to create dateValidator and calendar before calling base
            //which sets ReadOnly
            Controls.Add(CreateDateValidator());
            Controls.Add(CreateCalendarExtender());
            base.CreateChildControls();
            //move controls to desired location
            Controls.Add(dateValidator);
            Controls.Add(calendar);
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
            calendar.Format = Format;
            return calendar;
        }

        protected override void OnLoad(EventArgs e) {
            image.ID = ID + "_calendar";
            image.ImageUrl = RuheConfiguration.ImageUrlFor<InputDate>("calendar.png");
            calendar.TargetControlID = ID;
            calendar.PopupButtonID = image.ID;
            calendar.PopupPosition = CalendarPosition.BottomLeft;
            base.OnLoad(e);
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            CssClass = StringUtilities.ForceSuffix(Regex.Replace(CssClass, @"\binput-date\b", string.Empty), @" input-date").Trim();
            base.AddAttributesToRender(writer);
            Page.ClientScript.RegisterExpandoAttribute(ClientID, "datePattern", Format);
        }
    }
}
using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ruhe.Common.Utilities;

namespace Ruhe.Web.UI.Controls {
    public class InputDate : AbstractValueTypeInput<DateTime> {
        private CalendarExtender calendar;
        private Image image;

        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.Date; }
        }

        protected override string KeystrokeFilter {
            get { return "null"; }
        }

        protected override string Adapt(DateTime? value) {
            return value.HasValue ? value.Value.ToString(DatePattern) : string.Empty;
        }

        private static string DatePattern {
            get { return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern; }
        }

        public bool DefaultToToday {
            get { return Convert.ToBoolean(ViewState["DefaultToToday"]); }
            set {
                ViewState["DefaultToToday"] = value;
                if (!Value.HasValue && value)
                    Value = DateTime.Today;
            }
        }

        protected override DateTime? Adapt(string value) {
            return StringUtilities.IsEmpty(value) ? (DateTime?) null : DateTime.Parse(value, Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
        }

        protected override void CreateChildControls() {
            Controls.Add(CreateCalendarButton());
            base.CreateChildControls();
            Controls.Add(CreateCalendarExtender());
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.ReadOnly, "readonly");
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
    }
}
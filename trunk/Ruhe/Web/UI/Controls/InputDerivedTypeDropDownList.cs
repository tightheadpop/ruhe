using System;
using LiquidSyntax;

namespace Ruhe.Web.UI.Controls {
    public abstract class InputDerivedTypeDropDownList<T> : InputDropDownList where T : class {
        private DerivedTypeRepository<T> typeRepository = new DerivedTypeRepository<T>();

        protected override void CreateChildControls() {
            base.CreateChildControls();
            BindList(typeRepository.GetDisplayNames());
            SelectDefaultValue();
        }

        private void SelectDefaultValue() {
            SelectByText(DefaultValue.GetDisplayName());
        }

        protected abstract Type DefaultValue { get; }

        public Type SelectedType {
            get { return typeRepository.GetDerivedType(SelectedText); }
            set { SelectByText(value.GetDisplayName()); }
        }

        public T SelectedInstance {
            get { return typeRepository.GetInstanceOfDerivedType(SelectedText); }
            set { SelectByText(value.GetDisplayName()); }
        }
    }
}
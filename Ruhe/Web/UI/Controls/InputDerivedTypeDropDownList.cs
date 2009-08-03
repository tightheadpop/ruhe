using System;

namespace Ruhe.Web.UI.Controls {
    public abstract class InputDerivedTypeDropDownList<T> : InputDropDownList where T : class {
        private DerivedTypeRepository<T> typeRepository = new DerivedTypeRepository<T>();

        protected override void CreateChildControls() {
            base.CreateChildControls();
            BindList(typeRepository.GetDisplayNames());
        }

        public Type SelectedType {
            get { return typeRepository.GetDerivedType(SelectedText); }
        }

        public T SelectedInstance {
            get { return typeRepository.GetInstanceOfDerivedType(SelectedText); }
        }
    }
}
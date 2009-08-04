using System;
using System.ComponentModel;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public class SampleDerivedTypeList : InputDerivedTypeDropDownList<Foo> {
        protected override Type DefaultValue {
            get { return typeof(C); }
        }
    }

    public abstract class Foo {}

    [DisplayName("A class that extends Foo")]
    public class A : Foo {}

    [DisplayName("Another class that extends Foo")]
    public class B : Foo {}

    [DisplayName("Yet another class that extends Foo")]
    public class C : Foo {}
}
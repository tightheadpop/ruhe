<%@ Page MasterPageFile="~/Ajax.Master" Language="C#" AutoEventWireup="true" CodeBehind="DisabledElementTest.aspx.cs" Inherits="Ruhe.TestWeb.DisabledElementTest" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <%if (Page.IsPostBack) { %>
                Submitted = <%=foo.Checked ? "foo" : string.Empty%> 
                <%=bar.Checked ? "bar" : string.Empty%>
            <%} %>
            <asp:CheckBox ID="foo" Text="Foo" runat="server" Enabled="true" Checked="true" />
            <asp:CheckBox ID="bar" Text="Bar" runat="server" Enabled="false" Checked="true" />
            <asp:Button runat="server" Text="Go" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <ruhe:InputCheckBoxList runat="server" />
    <script type="text/javascript">
    alert(Sys$WebForms$PageRequestManager$_onFormSubmit);
        var f = Sys$WebForms$PageRequestManager$_onFormSubmit.toString();
        alert(f);
        var g = f.replace(/if \(typeof\(name\) === "undefined"/, "if (element.disabled || typeof(name) === \"undefined\" || (name === null) || (name.length === 0)) {");
        alert(g);
        eval(g);
    </script>
</asp:Content>

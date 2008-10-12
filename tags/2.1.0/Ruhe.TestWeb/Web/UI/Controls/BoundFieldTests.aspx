<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoundFieldTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.BoundFieldTests" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <ruhe:BoundField HeaderText="A null field does not cause an exception" DataField="Null.Length" />
                <ruhe:BoundField HeaderText="Check this OGNL!" DataField="Bar[0].Length" />
                <ruhe:DateBoundField HeaderText="Date with configured default" DataField="Baz" />
                <ruhe:DateBoundField HeaderText="Date with user format" DataField="Boz" DataFormatString="{0:M/d/yyyy}" />
                <ruhe:BooleanBoundField HeaderText="Bool as text" DataField="IsIt" TrueText="Yes" FalseText="No" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>

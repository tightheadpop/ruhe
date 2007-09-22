<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputButtonTests.aspx.cs" Inherits="Web_UI_Controls_InputButtonTests" %>
<%@ Register Assembly="Ruhe.Web" Namespace="Ruhe.Web.UI.Controls" TagPrefix="ruhe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<ruhe:InputButton ID="button1" runat="server" ImageUrl="~/images/foo.gif" Text="&Submit" />
		<ruhe:InputButton ID="button2" runat="server" Text="Click Here"/>
    </div>
    </form>
</body>
</html>

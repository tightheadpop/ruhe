<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputDropDownRequired.aspx.cs" Inherits="Web_UI_Controls_InputDropDownRequired" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<asp:validationsummary id="summary" runat="Server"/>
	<ruhe:inputdropdownlist id="DropDownTest" runat="server" Required="True"/>
	<asp:button id="submitButton" runat="Server"/>

    </div>
    </form>
</body>
</html>

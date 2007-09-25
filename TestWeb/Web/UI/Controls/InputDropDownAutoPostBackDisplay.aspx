<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputDropDownAutoPostBackDisplay.aspx.cs" Inherits="Web_UI_Controls_InputDropDownAutoPostBackDisplay" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<ruhe:InputDropDownList OnSelectedIndexChanged="firstDropDownList_SelectedIndexChanged" ID="firstDropDownList" runat="server" AutoPostBack="True" />
			<ruhe:InputDropDownList ID="secondDropDownList" runat="server" /></div>
		<div>
			<ruhe:InputDropDownList OnSelectedIndexChanged="thirdDropDownList_SelectedIndexChanged" ID="thirdDropDownList" runat="server" AutoPostBack="True" />
			<ruhe:InputDropDownList ID="fourthDropDownList" runat="server" /></div>
	</form>
</body>
</html>

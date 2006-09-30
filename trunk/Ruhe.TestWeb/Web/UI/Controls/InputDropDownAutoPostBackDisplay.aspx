<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<%@ Page language="c#" Codebehind="InputDropDownAutoPostBackDisplay.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.Tests.Web.UI.Controls.InputDropDownAutoPostBackDisplay" %>
<form id="InputDropDownAutoPostBackDisplay" method="post" runat="server" >
	<div><ruhe:InputDropDownList id="firstDropDownList" runat="server" AutoPostBack="True"/>
	<ruhe:InputDropDownList id="secondDropDownList" runat="server" /></div>
	<div><ruhe:InputDropDownList id="thirdDropDownList" runat="server" AutoPostBack="True"/>
	<ruhe:InputDropDownList id="fourthDropDownList" runat="server" /></div>
	
</form>

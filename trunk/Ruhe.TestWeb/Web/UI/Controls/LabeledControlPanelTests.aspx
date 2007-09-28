<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web_UI_Controls_LabeledControlPanelTests" Codebehind="LabeledControlPanelTests.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<ruhe:LabeledControlPanel ID="panel" runat="Server" LabelPosition="Left">
				<ruhe:InputTextBox ID="textbox" runat="server" FormatText="(format)" LabelText="label" />
			</ruhe:LabeledControlPanel>
		</div>
	</form>
</body>
</html>

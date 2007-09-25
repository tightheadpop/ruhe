<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sample.aspx.cs" Inherits="Sample" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Sample of Ruhe Web Controls</title>
</head>
<body>
	<form id="form1" runat="server">
		<ruhe:ValidationSummary runat="server" />
		<ruhe:LabeledControlPanel runat="server" GroupingText="Sample Form" >
			<ruhe:InputTextBox LabelText="Name" ID="name" runat="server" Required="true" />
			<ruhe:InputEmailAddress ID="email" runat="server" Required="true" />
			<ruhe:InputNumber LabelText="Your Age" NumericFormat="Integer" ID="age" runat="server"/>
			<ruhe:ControlGroup runat="server">
				<ruhe:SaveButton runat="server" />
				<ruhe:ResetButton runat="server" />
			</ruhe:ControlGroup>
		</ruhe:LabeledControlPanel>
		<ruhe:Legend runat="server" />
	</form>
</body>
</html>

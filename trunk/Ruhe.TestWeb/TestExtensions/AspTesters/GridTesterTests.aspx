<%@ Page language="c#" Codebehind="GridTesterTests.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.TestWeb.Tests.Extensions.AspTesters.GridTesterTests" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GridTesterTests</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid ID="grid" Runat="server">
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							&nbsp;
						</ItemTemplate>
						<EditItemTemplate>
							<asp:Label ID="message" Runat="server" Text="postback" />
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							&nbsp;
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox Runat="server"/>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							&nbsp;
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox TextMode="MultiLine" Runat="server"/>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							&nbsp;
						</ItemTemplate>
						<EditItemTemplate>
							<asp:DropDownList Runat="server">
								<asp:ListItem>One</asp:ListItem>
								<asp:ListItem>Two</asp:ListItem>
								<asp:ListItem>Three</asp:ListItem>
							</asp:DropDownList>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQueryIncludeTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.JQueryIncludeTests" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>jquery include</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span id="text"></span>
    </div>
    </form>
    <script type="text/javascript">
        $(function(){
            $('#text').text("updated!");
        });
    </script>
</body>
</html>

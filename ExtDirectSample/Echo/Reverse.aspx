<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reverse.aspx.cs" Inherits="ExtDirectSample.Echo.Reverse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../ext/resources/css/ext-all.css" />
    <link rel="Stylesheet" type="text/css" href="../Sample.css" />
    <script type="text/javascript" src="../ext/adapter/ext/ext-base-debug.js"></script>
    <script type="text/javascript" src="../ext/ext-all-debug.js"></script>
    <script type="text/javascript" src="EchoHandler.ashx"></script>
    <script type="text/javascript" src="Reverse.js"></script>
    <title>Echo With Parameters</title>
</head>
<body>
    <div class="header">Echo With Parameters</div>
    <p class="description">Makes a request to the server to reverse the inputted string.</p>
    
    <div id="container"></div>
</body>
</html>

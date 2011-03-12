<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sum.aspx.cs" Inherits="ExtDirectSample.Echo.Sum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../ext/resources/css/ext-all.css" />
    <link rel="Stylesheet" type="text/css" href="../Sample.css" />
    <script type="text/javascript" src="../ext/adapter/ext/ext-base-debug.js"></script>
    <script type="text/javascript" src="../ext/ext-all-debug.js"></script>
    <script type="text/javascript" src="EchoHandler.ashx"></script>
    <script type="text/javascript" src="Sum.js"></script>
    <title>Simple Sum</title>
</head>
<body>
    <div class="header">Simple Sum</div>
    <p class="description">Makes a request to the server to add 2 numbers. This illustrates working with particular types.</p>
    
    <div id="container"></div>
</body>
</html>

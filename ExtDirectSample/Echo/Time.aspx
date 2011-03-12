<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Time.aspx.cs" Inherits="ExtDirectSample.Echo.Time" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../ext/resources/css/ext-all.css" />
    <link rel="Stylesheet" type="text/css" href="../Sample.css" />
    <script type="text/javascript" src="../ext/adapter/ext/ext-base-debug.js"></script>
    <script type="text/javascript" src="../ext/ext-all-debug.js"></script>
    <script type="text/javascript" src="EchoHandler.ashx"></script>
    <script type="text/javascript" src="Time.js"></script>
    <title>Echo Current Time</title>
</head>
<body>
    <div class="header">Echo Current Time</div>
    <p class="description">Makes a request to the server to get the current date/time. Note that the parameter passed back is a javascript date object.</p>
    
    <div id="container"></div>
</body>
</html>

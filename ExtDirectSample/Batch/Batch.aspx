<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Batch.aspx.cs" Inherits="ExtDirectSample.Batch.Batch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../ext/resources/css/ext-all.css" />
    <link rel="Stylesheet" type="text/css" href="../Sample.css" />
    <script type="text/javascript" src="../ext/adapter/ext/ext-base-debug.js"></script>
    <script type="text/javascript" src="../ext/ext-all-debug.js"></script>
    <script type="text/javascript" src="BatchHandler.ashx"></script>
    <script type="text/javascript" src="Batch.js"></script>
    <title>Batching Sample</title>
</head>
<body>
    <div class="header">Batching Sample</div>
    <p class="description">4 requests are sent at the same time, however only 1 Ajax request is fired.</p>
    
    <div id="container"></div>
</body>
</html>


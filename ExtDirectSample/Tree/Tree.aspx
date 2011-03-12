<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tree.aspx.cs" Inherits="ExtDirectSample.Tree.Tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../ext/resources/css/ext-all.css" />
    <link rel="Stylesheet" type="text/css" href="../Sample.css" />
    <script type="text/javascript" src="../ext/adapter/ext/ext-base-debug.js"></script>
    <script type="text/javascript" src="../ext/ext-all-debug.js"></script>
    <script type="text/javascript" src="TreeHandler.ashx"></script>
    <script type="text/javascript" src="Tree.js"></script>
    <title>Simple Tree</title>
</head>
<body>
    <div class="header">Simple Tree</div>
    <p class="description">Simple tree examples, loads/saves data with an XML document. Nodes are draggable and persist. The titles are also editable.</p>
    
    <div id="container"></div>
</body>
</html>

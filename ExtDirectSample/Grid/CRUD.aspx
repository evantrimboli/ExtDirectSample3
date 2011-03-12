<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="ExtDirectSample.Grid.CRUD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../ext/resources/css/ext-all.css" />
    <link rel="Stylesheet" type="text/css" href="../Sample.css" />
    <script type="text/javascript" src="../ext/adapter/ext/ext-base-debug.js"></script>
    <script type="text/javascript" src="../ext/ext-all-debug.js"></script>
    <script type="text/javascript" src="GridHandler.ashx"></script>
    <script type="text/javascript" src="CRUD.js"></script>
    <title>Grid - Simple CRUD Grid With Remote Sorting</title>
</head>
<body>
    <div class="header">Grid - Simple CRUD Grid With Remote Sorting</div>
    <p class="description">Simple CRUD grid backed by a persistent database.</p>
    
    <div id="container"></div>
</body>
</html>

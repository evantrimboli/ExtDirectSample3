<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paging.aspx.cs" Inherits="ExtDirectSample.Grid.Paging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../ext/resources/css/ext-all.css" />
    <link rel="Stylesheet" type="text/css" href="../Sample.css" />
    <script type="text/javascript" src="../ext/adapter/ext/ext-base-debug.js"></script>
    <script type="text/javascript" src="../ext/ext-all-debug.js"></script>
    <script type="text/javascript" src="GridHandler.ashx"></script>
    <script type="text/javascript" src="Paging.js"></script>
    <title>Grid - Paging With Remote Sorting</title>
</head>
<body>
    <div class="header">Grid - Paging With Remote Sorting</div>
    <p class="description">Simple remote grid, that supports both paging and sorting.</p>
    
    <div id="container"></div>
</body>
</html>

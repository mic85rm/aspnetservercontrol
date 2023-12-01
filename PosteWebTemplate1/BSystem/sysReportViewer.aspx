<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysReportViewer.aspx.cs" Inherits="PosteWebTemplate1.sysReportViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Anteprima di stampa</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:Literal ID="LtrReport" runat="server"></asp:Literal>
    </div>
  </form>
</body>
</html>

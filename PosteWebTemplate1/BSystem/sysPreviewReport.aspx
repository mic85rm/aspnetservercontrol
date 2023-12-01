<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysPreviewReport.aspx.cs" Inherits="PosteWebTemplate1.sysPreviewReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title>Anteprima di stampa</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="Header" class="BPagePreviewReport_Header">
      <div class="BPagePreviewReport_HeaderLeft"></div>
    </div>
    <asp:Panel ID="PnlContainer" runat="server" CssClass="BPagePreviewReport_Container">
      <div class="BWidth100 BHeight100 BPagePreviewReport_ReportContainer">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%">
        </rsweb:ReportViewer>
      </div>
    </asp:Panel>
  </form>
</body>
</html>


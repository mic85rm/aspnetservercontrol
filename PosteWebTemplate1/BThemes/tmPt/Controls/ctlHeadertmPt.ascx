<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlHeadertmPt.ascx.cs" Inherits="PosteWebTemplate1.ctlHeadertmPt" %>
<%@ Register Src="~/BSystem/Controls/BCtlUtenteEntrato.ascx" TagPrefix="uc1" TagName="BCtlUtenteEntrato" %>
<%@ Register Src="~/BSystem/Controls/BCtlHeaderBar.ascx" TagPrefix="uc1" TagName="BCtlHeaderBar" %>


<div class="Header">
  <div class="HeaderLeft">
    <uc1:BCtlHeaderBar runat="server" ID="BCtlHeaderBar" />
  </div>
  <div class="HeaderRight">
    <uc1:BCtlUtenteEntrato runat="server" ID="BCtlUtenteEntrato" />
  </div>
</div>



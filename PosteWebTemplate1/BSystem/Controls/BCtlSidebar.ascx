<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlSidebar.ascx.cs" Inherits="PosteWebTemplate1.BCtlSidebar" %>
<%@ Register Src="~/BSystem/Controls/BCtlElencoSistemi.ascx" TagPrefix="uc1" TagName="BCtlElencoSistemi" %>
<%@ Register Src="~/BSystem/Controls/BCtlElencoProfili.ascx" TagPrefix="uc1" TagName="BCtlElencoProfili" %>
<%@ Register Src="~/BSystem/Controls/BCtlElencoApplicazioni.ascx" TagPrefix="uc1" TagName="BCtlElencoApplicazioni" %>
<%@ Register Src="~/BSystem/Controls/BCtlElencoVisibilita.ascx" TagPrefix="uc1" TagName="BCtlElencoVisibilita" %>


<div class="BSideBarContent">
  <div class="BFloatLeft BWidth100">
    <uc1:BCtlElencoSistemi runat="server" ID="CtlElencoSistemi" />
  </div>
  <div class="BFloatLeft BWidth100">
    <uc1:BCtlElencoProfili runat="server" ID="CtlElencoProfili" />
  </div>

  <div class="BFloatLeft BWidth100">
    <uc1:BCtlElencoVisibilita runat="server" ID="CtlElencoVisibilita" />
  </div>
  <div class="BFloatLeft BWidth100">
    <uc1:BCtlElencoApplicazioni runat="server" ID="CtlElencoApplicazioni" />
  </div>
</div>


' MailLink.vb
Option Strict On
Imports System
Imports System.ComponentModel
Imports System.Security
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

'<DynamicMenuStyle CssClass=”DynamicMenu” />

Namespace Samples.AspNet.VB.Controls
  <
  AspNetHostingPermission(SecurityAction.Demand,
      Level:=AspNetHostingPermissionLevel.Minimal),
  AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level:=AspNetHostingPermissionLevel.Minimal),
  DefaultProperty("Email"),
  ParseChildren(True, "Text"),
  ToolboxData("<{0}:MailLink runat=""server""> </{0}:MailLink>")
  >
  Public Class MailLink
    Inherits WebControl
    <
    Bindable(True),
    Category("Appearance"),
    DefaultValue(""),
    Description("The e-mail address.")
    >
    Public Overridable Property Email() As String
      Get
        Dim s As String = CStr(ViewState("Email"))
        If s Is Nothing Then s = String.Empty
        Return s
      End Get
      Set(ByVal value As String)
        ViewState("Email") = value
      End Set
    End Property

    <
    Bindable(True),
    Category("Appearance"),
    DefaultValue(""),
    Description("The text to display on the link."),
    Localizable(True),
    PersistenceMode(PersistenceMode.InnerDefaultProperty)
    >
    Public Overridable Property Text() As String
      Get
        Dim s As String = CStr(ViewState("Text"))
        If s Is Nothing Then s = String.Empty
        Return s
      End Get
      Set(ByVal value As String)
        ViewState("Text") = value
      End Set
    End Property

    Protected Overrides ReadOnly Property TagKey() _
        As HtmlTextWriterTag
      Get
        Return HtmlTextWriterTag.A
      End Get
    End Property


    Protected Overrides Sub AddAttributesToRender(
        ByVal writer As HtmlTextWriter)
      MyBase.AddAttributesToRender(writer)
      writer.AddAttribute(HtmlTextWriterAttribute.Href,
          "mailto:" & Email)
    End Sub

    Protected Overrides Sub RenderContents(
        ByVal writer As HtmlTextWriter)
      If (Text = String.Empty) Then
        Text = Email
      End If
      writer.WriteEncodedText(Text)
    End Sub

  End Class
End Namespace
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace prova
  <DefaultProperty("Title")>
  <ToolboxData("<{0}:Workspace runat=server></{0}:Workspace>")>
  Public Class Workspace
    Inherits CompositeControl

    Private _TitleBarTemplateValue As ITemplate
    Private _ActionBarTemplateValue As ITemplate
    Private _TitleBarOwnerValue As TemplateOwner
    Private _ActionBarOwnerValue As TemplateOwner

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property TitleBarOwner As TemplateOwner
      Get
        Return _TitleBarOwnerValue
      End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property ActionBarOwner As TemplateOwner
      Get
        Return _ActionBarOwnerValue
      End Get
    End Property

    <Bindable(True)>
    <Category("Appearance")>
    <DefaultValue("[Provide the title for the workspace]")>
    <Localizable(True)>
    Public Property Title As String
      Get
        Dim s As String = CStr(ViewState("Title"))
        Return (If((s Is Nothing), "[" & Me.ID & "]", s))
      End Get
      Set(ByVal value As String)
        ViewState("Text") = value
      End Set
    End Property

    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(GetType(ITemplate), ""), Description("Control template"), TemplateContainer(GetType(Workspace))>
    Public Overridable Property TitleBar As ITemplate
      Get
        Return _TitleBarTemplateValue
      End Get
      Set(ByVal value As ITemplate)
        _TitleBarTemplateValue = value
      End Set
    End Property

    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(GetType(ITemplate), ""), Description("Control template"), TemplateContainer(GetType(Workspace))>
    Public Overridable Property ActionBar As ITemplate
      Get
        Return _ActionBarTemplateValue
      End Get
      Set(ByVal value As ITemplate)
        _ActionBarTemplateValue = value
      End Set
    End Property

    Protected Overrides Sub CreateChildControls()
      Controls.Clear()
      _TitleBarOwnerValue = New TemplateOwner()
      _ActionBarOwnerValue = New TemplateOwner()
      Dim temp1 As ITemplate = _TitleBarTemplateValue
      Dim temp2 As ITemplate = _ActionBarTemplateValue
      temp1.InstantiateIn(_TitleBarOwnerValue)
      temp2.InstantiateIn(_ActionBarOwnerValue)
      Me.Controls.Add(_TitleBarOwnerValue)
      Me.Controls.Add(_ActionBarOwnerValue)
    End Sub

    Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
      MyBase.RenderContents(writer)
    End Sub
  End Class

  <ToolboxItem(False)>
  Public Class TemplateOwner
    Inherits WebControl
  End Class
End Namespace

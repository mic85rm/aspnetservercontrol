Imports System.Drawing
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<
  Bindable(True),
  Category("Appearance"),
  DefaultValue(""),
  Description("Prova Menu Alternativo."),
  Localizable(True)
  >
<DefaultProperty("Text")>
<ToolboxData("<{0}:MenuFunzione runat=server></{0}:MenuFunzione>")>
<ToolboxBitmap(GetType(MenuFunzione), "menu.bmp")>
Public Class MenuFunzione
  Inherits Menu


  '  .menu ul li ul
  '{
  '    display: none;
  '}

  '.menu ul li 
  '{
  '    position: relative; 
  '    float: left;
  '    list-style: none;
  '}

  Public Sub CaricaMenu(ByVal ds As DataSet)
    Me.Orientation = Orientation.Horizontal
    Me.Attributes.Add("style", ".menu ul li ul{  display: none;}")
    Me.Attributes.Add("style", ".menu ul li  {position: relative; float: left;list-style: none;}")
    Dim drs() As DataRow
    Dim mi As MenuItem = Nothing
    Dim mf As MenuItem = Nothing
    drs = ds.Tables(0).Select("IDPadre is null")

    For Each dr As DataRow In drs
      mi = New MenuItem(dr("Descrizione"))
      mi.NavigateUrl = "~/" & dr("Comando")
      mi.ToolTip = dr("ToolTip") & ""

      mi = CaricaFigli(ds, mi, dr("ID"))

      Me.Items.Add(mi)
    Next
  End Sub


  Private Function CaricaFigli(ByVal ds As DataSet, ByVal nodo As MenuItem, ByVal menuID As Integer) As MenuItem
    Me.Orientation = Orientation.Horizontal
    Dim drs() As DataRow
    Dim mi As MenuItem
    drs = ds.Tables(0).Select("IDPadre = " & menuID)

    For Each dr As DataRow In drs
      mi = New MenuItem(dr("Descrizione"))
      mi.NavigateUrl = "~/" & dr("Comando")
      mi.ToolTip = dr("ToolTip") & ""

      mi = CaricaFigli(ds, mi, dr("ID"))

      nodo.ChildItems.Add(mi)
    Next
    Return nodo
    'Me.Attributes.Clear()
  End Function



  Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)

  End Sub

End Class
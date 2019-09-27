Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Newtonsoft
Imports Newtonsoft.Json

<ToolboxData("<{0}:Mtmenu runat=server></{0}:Mtmenu>")>
<ToolboxBitmap(GetType(Mtmenu), "menu.bmp")>
Public Class Mtmenu
  Inherits WebControl


  Dim menuTree As List(Of menudinamico) = New List(Of menudinamico)

  <Description("The image associated with the control"),
      Category("Appearance")>
  Public _mtdatatable As DataTable
  <Description("The image associated with the control"),
      Category("Appearance")>
  Public Property MTDatatable() As DataTable
    Get
      Return _mtdatatable
    End Get
    Set(ByVal value As DataTable)
      _mtdatatable = value
    End Set
  End Property

  'Public _mtdataset As DataSet

  'Public Property MTDataset() As DataSet
  '  Get
  '    Return _mtdataset
  '  End Get
  '  Set(ByVal value As DataSet)
  '    _mtdataset = value
  '  End Set
  'End Property

  Public _menucss As String
  Public Property MenuCss() As String
    Get
      Return _menucss
    End Get
    Set(ByVal value As String)
      _menucss = value
    End Set
  End Property
  'Public _menuid As String
  'Public Property MenuId() As String
  '  Get
  '    Return _menuid
  '  End Get
  '  Set(ByVal value As String)
  '    _menuid = value
  '  End Set
  'End Property


  Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
    writer.Write("<link href=""" + MenuCss + """ rel = ""stylesheet"" />")
    writer.Write(System.Environment.NewLine)
    writer.Write("<div id=""container"">")
    writer.Write(System.Environment.NewLine)
    writer.Write("<nav>")
    writer.Write(System.Environment.NewLine)
    writer.Write("<ul>")
    writer.Write(System.Environment.NewLine)
    'writer.Write("<asp:Button ID=""btnrespnav"" runat=""server"" Text=""🞬"" CausesValidation=""false""/>")
    writer.Write(convertitore(menuTree))
    writer.Write(System.Environment.NewLine)
    writer.Write("</ul>")
    writer.Write(System.Environment.NewLine)
    writer.Write("</nav>")
    writer.Write(System.Environment.NewLine)
    writer.Write("</div>")
  End Sub

  Public Function BindMenuData() As String
    Dim ds As DataSet = New DataSet()
    Dim listmenu As List(Of menudinamico) = New List(Of menudinamico)
    For Each row As DataRow In MTDatatable.Rows
      Dim menu As menudinamico = New menudinamico()
      menu.id = row.Item("id")
      If Not IsDBNull(row.Item("idpadre")) Then
        menu.idpadre = row.Item("idpadre")
      Else
        menu.idpadre = 0
      End If
      menu.descrizione = row.Item("descrizione").ToString()
      menu.tooltip = row.Item("tooltip").ToString
      menu.comando = Page.ResolveUrl("~/") & row.Item("Comando").ToString()
      menu.ordine = row.Item("ordine")
      menu.active = row.Item("auth")
      listmenu.Add(menu)
    Next row
    menuTree = GetMenuTree(listmenu, 0)
    Dim js As String = ""
    js = JsonConvert.SerializeObject(menuTree)
    convertitore(menuTree)
    Return js
  End Function

  Private Function GetMenuTree(ByVal list As List(Of menudinamico), ByVal parentId As Integer) As List(Of menudinamico)
    Dim obj As menudinamico = New menudinamico
    Return list.Where(Function(x) x.idpadre = parentId).Select(Function(x) New menudinamico() With {
                      .id = x.id,
                      .active = x.active,
                      .comando = x.comando,
                      .descrizione = x.descrizione,
                       .idpadre = x.idpadre,
                       .ordine = x.ordine,
                       .tooltip = x.tooltip,
                       .visitato = False,
                       .Mlist = GetMenuTree(list, x.id)}).ToList()

  End Function
  Dim s As StringBuilder = New StringBuilder()
  Private Function convertitore(ByVal list As List(Of menudinamico)) As String

    For Each item In list
      If item.Mlist.Count = 0 And item.visitato = False Then
        s.Append(System.Environment.NewLine)
        s.Append("<li>")
        s.Append("<a href ='" + item.comando + "'>")
    s.Append(item.descrizione)
        s.Append("</a>")
        s.Append("</li>")
      ElseIf item.Mlist.Count > 0 And item.visitato = False Then
        s.Append("<li>")
        s.Append("<a href ='" + item.comando + "'>")
        s.Append(item.descrizione)
        s.Append("</a>")
        s.Append(System.Environment.NewLine)

        s.Append(System.Environment.NewLine)
        s.Append("<ul>")
        convertitore(item.Mlist)
        s.Append("</ul>")
        s.Append("</li>")
      End If
      item.visitato = True
    Next
    Return s.ToString()
  End Function

End Class




Class menudinamico
  Public Property id As Integer
  Public Property descrizione As String
  Public Property comando As String 'url
  Public Property tooltip As String
  Public Property idpadre As Integer
  Public Property ordine As Integer
  Public Property active As Boolean
  Public Property Mlist As List(Of menudinamico)

  Public property visitato As boolean
End Class



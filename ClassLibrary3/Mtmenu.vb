Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

<ToolboxData("<{0}:Mtmenu runat=server></{0}:Mtmenu>")>
<ToolboxBitmap(GetType(Mtmenu), "menu.bmp")>
Public Class Mtmenu
  Inherits WebControl

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
    'Dim menuidappoggio As String
    'Dim conta As Integer
    'If MenuId <> String.Empty Then
    '  menuidappoggio = MenuId.ToString()
    '  menuidappoggio.Insert(0, " "" ")
    '  conta = menuidappoggio.Count
    '  menuidappoggio.Insert(conta, " "" ")
    'Else
    '  menuidappoggio = String.Empty
    'End If
    Try
      writer.Write("<link href=""" + MenuCss + """ rel = ""stylesheet"" />")
      'writer.Write("<div id=""" + menuidappoggio + """>")
      writer.Write("<div>")
      writer.Write("<nav>")
      writer.Write("<ul>")
      writer.Write(menuHtmlGenerator(Me.ShowMenuDT()))
      writer.Write("</ul>")
      writer.Write("</nav>")
      writer.Write("</div>")
    Catch ex As Exception
      writer.Write(ex.Message)
    End Try
  End Sub

  Private Function ShowMenuDT() As List(Of MenuItem)
    Dim menuitems As List(Of MenuItem) = New List(Of MenuItem)
    Dim ds As DataSet = New DataSet()
    Try
      If Not MTDatatable Is Nothing AndAlso MTDatatable.Rows.Count > 0 Then
        ds.Tables.Add(MTDatatable)
        ds.DataSetName = "Menus"
        ds.Tables(0).TableName = "Menu"
        Dim relation As New DataRelation("ParentChild", MTDatatable.Columns("ID"), MTDatatable.Columns("IDPadre"), True)
        relation.Nested = True
        ds.Relations.Add(relation)
      End If
      Dim drs() As DataRow
      drs = ds.Tables(0).Select("IDPadre Is null")
      For Each dr As DataRow In drs
        Dim itm As MenuItem = New MenuItem()
        itm.Text = (dr("Descrizione")).ToString
        'itm.NavigateUrl = "~/" & dr("Comando")
        itm.NavigateUrl = Page.ResolveUrl("~/") & dr("Comando")
        itm.ToolTip = dr("ToolTip") & ""
        itm.Value = dr("id").ToString()
        menuitems.Add(itm)
        Dim drs2() As DataRow
        drs2 = ds.Tables(0).Select("IDPadre = " & itm.Value.ToString())
        For Each dr2 As DataRow In drs2
          Dim mi As MenuItem = New MenuItem()
          mi.Text = (dr2("Descrizione")).ToString()
          'mi.NavigateUrl = "~/" & dr2("Comando")
          mi.NavigateUrl = Page.ResolveUrl("~/") & dr2("Comando")
          mi.ToolTip = dr2("ToolTip") & ""
          itm.ChildItems.Add(mi)
        Next
      Next
    Catch ex As Exception

    End Try
    Return menuitems
  End Function


  'Public Function ShowMenu() As List(Of MenuItem)
  '  Dim menuitems As List(Of MenuItem) = New List(Of MenuItem)
  '  Try
  '    Dim drs() As DataRow
  '    drs = MTDataset.Tables(0).Select("IDPadre Is null")
  '    For Each dr As DataRow In drs
  '      Dim itm As MenuItem = New MenuItem()
  '      itm.Text = (dr("Descrizione")).ToString
  '      itm.NavigateUrl = "~/" & dr("Comando")
  '      itm.ToolTip = dr("ToolTip") & ""
  '      itm.Value = dr("id").ToString()
  '      menuitems.Add(itm)
  '      Dim drs2() As DataRow
  '      drs2 = MTDataset.Tables(0).Select("IDPadre = " & itm.Value.ToString())
  '      For Each dr2 As DataRow In drs2
  '        Dim mi As MenuItem = New MenuItem()
  '        mi.Text = (dr2("Descrizione")).ToString()
  '        mi.NavigateUrl = "~/" & dr2("Comando")
  '        mi.ToolTip = dr2("ToolTip") & ""
  '        itm.ChildItems.Add(mi)
  '      Next
  '    Next
  '  Catch ex As Exception

  '  End Try
  '  Return menuitems
  'End Function



  Protected Function menuHtmlGenerator(ByVal aList As List(Of MenuItem)) As String
    Dim s As StringBuilder = New StringBuilder()
    Dim menulist As MenuItem = New MenuItem
    For i As Integer = 0 To aList.Count - 1
      's.Append("<ul style='float:Left;list-style-type:none;'>")
      's.Append("<ul>")
      's.Append(System.Environment.NewLine)
      If (aList(i).ChildItems.Count = 0) Then

        s.Append("<li>")
        's.Append("<a href ='" & (CType(aList(i), MenuItem)).NavigateUrl & "' style='text-decoration:none;' ")
        s.Append("<a href ='" & (CType(aList(i), MenuItem)).NavigateUrl & "' ")
        's.Append("title='" & (CType(aList(i), MenuItem)).Text & "' ")
        'If useDiffCssForCrrntItem Then
        '  If (CType(aList(i), MenuItem)).Text = currentItemId Then s.Append("class='" & currentItemClass & "' ")
        'End If
        s.Append(">")
        s.Append((CType(aList(i), MenuItem)).Text)
        's.Append("<span>" & (CType(aList(i), MenuItem)).Text & "</span> ")
        s.Append("</a>")
        s.Append("</li>")
        's.Append("</ul>")
        s.Append(System.Environment.NewLine)
      Else
        s.Append("<li >")
        's.Append("<a href ='" & (CType(aList(i), MenuItem)).NavigateUrl & "'style='text-decoration:none;' ")
        s.Append("<a href ='" & (CType(aList(i), MenuItem)).NavigateUrl & "' ")
        's.Append("title='" & (CType(aList(i), MenuItem)).Text & "' ")
        s.Append(">")
        s.Append((CType(aList(i), MenuItem)).Text)
        's.Append("<span>" & (CType(aList(i), MenuItem)).Text & "</span> ")
        s.Append("</a>")
        's.Append("</li>")
        's.Append("<ul style='float:Left;list-style-type:none;'>")
        s.Append("<ul >")
        s.Append(System.Environment.NewLine)
        For j As Integer = 0 To aList(i).ChildItems.Count - 1
          s.Append("<li >")
          's.Append("<a href ='" & (CType(aList(i).ChildItems(j), MenuItem)).NavigateUrl & "' style='text-decoration:none;' ")
          s.Append("<a href ='" & (CType(aList(i).ChildItems(j), MenuItem)).NavigateUrl & "' ")
          's.Append("title='" & (CType(aList(i).ChildItems(j), MenuItem)).Text & "' ")

          'If useDiffCssForCrrntItem Then
          '  If (CType(aList(i), MenuItem)).Text = currentItemId Then s.Append("class='" & currentItemClass & "' ")
          'End If

          s.Append(">")
          s.Append((CType(aList(i).ChildItems(j), MenuItem)).Text)
          's.Append("<span>" & (CType(aList(i).ChildItems(j), MenuItem)).Text & "</span> ")
          s.Append("</a>")
          s.Append("</li>")

          s.Append(System.Environment.NewLine)
        Next
        s.Append("</ul>")
        s.Append("</li>")
      End If
      's.Append("</ul>")
    Next

    Return s.ToString()
  End Function




End Class




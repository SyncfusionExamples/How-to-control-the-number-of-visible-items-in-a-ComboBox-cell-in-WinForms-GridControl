Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Grid

Public Class Form1
    Public Sub New()
        InitializeComponent()

        ' ComboBox for Row 2, Column 1
        Dim comboItems1 As New StringCollection()
        comboItems1.AddRange(New String() {"Data", "Table", "Control", "Combo", "Control", "Unique", "Valid", "Bag", "Board", "Mouse"})
        gridControl1(2, 1).CellType = "ComboBox"
        gridControl1(2, 1).ChoiceList = comboItems1
        gridControl1(2, 1).Text = "Control"

        ' ComboBox for Row 4, Column 2
        Dim comboItems2 As New StringCollection()
        comboItems2.AddRange(New String() {"Data", "Table", "Control", "Combo", "Control", "Unique", "Valid"})
        gridControl1(4, 2).CellType = "ComboBox"
        gridControl1(4, 2).ChoiceList = comboItems2
        gridControl1(4, 2).Text = "Table"

        ' ComboBox for Row 6, Column 3
        Dim comboItems3 As New StringCollection()
        comboItems3.AddRange(New String() {"Data", "Table", "Control", "Combo"})
        gridControl1(6, 3).CellType = "ComboBox"
        gridControl1(6, 3).ChoiceList = comboItems3
        gridControl1(6, 3).Text = "Control"

        ' Attach the drop-down customization event
        AddHandler gridControl1.CurrentCellShowingDropDown, AddressOf OnCurrentCellShowingDropDown
    End Sub

    Private Sub OnCurrentCellShowingDropDown(sender As Object, e As GridCurrentCellShowingDropDownEventArgs)
        Dim grid As GridControlBase = TryCast(sender, GridControlBase)
        If grid IsNot Nothing Then
            Dim cc As GridCurrentCell = grid.CurrentCell
            Dim cr As GridComboBoxCellRenderer = TryCast(cc.Renderer, GridComboBoxCellRenderer)

            If cc IsNot Nothing AndAlso cr IsNot Nothing Then
                Dim listBoxPart As GridComboBoxListBoxPart = CType(cr.ListBoxPart, GridComboBoxListBoxPart)

                ' Set number of visible items based on row index
                Select Case cc.RowIndex
                    Case 6
                        listBoxPart.DropDownRows = 4
                    Case 4
                        listBoxPart.DropDownRows = 7
                    Case 2
                        listBoxPart.DropDownRows = 10
                    Case Else
                        listBoxPart.DropDownRows = 6
                End Select
            End If
        End If
    End Sub

End Class
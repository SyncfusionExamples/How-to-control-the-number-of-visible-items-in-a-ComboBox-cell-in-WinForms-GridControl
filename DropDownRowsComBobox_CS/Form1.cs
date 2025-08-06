using Syncfusion.Windows.Forms.Grid;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace DropDownRowsComBobox_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StringCollection comboItems1 = new StringCollection();
            comboItems1.AddRange(new string[] { "Data", "Table", "Control", "Combo","Control","Unique","Valid","Bag","Board","Mouse" });
            gridControl1[2,1].CellType = "ComboBox";
            gridControl1[2,1].ChoiceList = comboItems1;
            gridControl1[2,1].Text = "Control";

            StringCollection comboItems2= new StringCollection();
            comboItems2.AddRange(new string[] { "Data", "Table", "Control", "Combo", "Control", "Unique", "Valid" });
            gridControl1[4, 2].CellType = "ComboBox";
            gridControl1[4, 2].ChoiceList = comboItems2;
            gridControl1[4, 2].Text = "Table";

            StringCollection comboItems3 = new StringCollection();
            comboItems3.AddRange(new string[] { "Data", "Table", "Control", "Combo"});
            gridControl1[6, 3].CellType = "ComboBox";
            gridControl1[6, 3].ChoiceList = comboItems3;
            gridControl1[6, 3].Text = "Control";

            gridControl1.CurrentCellShowingDropDown += OnCurrentCellShowingDropDown;

        }

        void OnCurrentCellShowingDropDown(object sender, GridCurrentCellShowingDropDownEventArgs e)
        {
            GridControlBase grid = sender as GridControlBase;
            if (grid != null)
            {
                GridCurrentCell cc = grid.CurrentCell;
                GridComboBoxCellRenderer cr = cc.Renderer as GridComboBoxCellRenderer;

                //Sets number of visible items for comboboxes in Row 6 as 4, Row 4 as 7, Row 2 as 10 , and so on. 

                if (cc != null)
                {
                    if (cc.RowIndex == 6)
                        ((GridComboBoxListBoxPart)cr.ListBoxPart).DropDownRows = 4;
                    else if (cc.RowIndex == 4)
                        ((GridComboBoxListBoxPart)cr.ListBoxPart).DropDownRows = 7;
                    else if (cc.RowIndex == 2)
                        ((GridComboBoxListBoxPart)cr.ListBoxPart).DropDownRows = 10;
                    else ((GridComboBoxListBoxPart)cr.ListBoxPart).DropDownRows = 6;
                }
            }
        }

    }
}
using FuelStation.EF.Repository;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win
{
    public partial class ItemForm : Form
    {
        private readonly IEntityRepo<Item> _itemRepo;
        private bool pressedEdit = false;
        public ItemForm(IEntityRepo<Item> itemRepo)
        {
            InitializeComponent();
            _itemRepo = itemRepo;
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            RefreshItemList();
            PopulateComboBox();
            EmptyControls();
        }

        private async void RefreshItemList()
        {
            grvItems.DataSource = null;
            grvItems.DataSource = await _itemRepo.GetAllAsync();            

            grvItems.Update();
            grvItems.Refresh();
        }

        private void EmptyTextBoxes()
        {
            txtCode.Text = string.Empty;
            txtCost.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;            
        }

        private void EmptyComboBox()
        {
            comboBoxItemType.Text = string.Empty;
        }

        private void EmptyControls()
        {
            EmptyTextBoxes();
            EmptyComboBox();
        }

        private void PopulateComboBox()
        {
            comboBoxItemType.DataSource = Enum.GetNames(typeof(ItemType));
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (pressedEdit)
                return;

            var code = txtCode.Text;
            var cost = txtCost.Text;
            var description = txtDescription.Text;
            var price = txtPrice.Text;
            var itemType = comboBoxItemType.Text;

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(cost) || string.IsNullOrEmpty(description)
                || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(itemType))
            {
                MessageBox.Show("Empty Textboxes!");
                return;
            }

            var item = new Item() { Code = code, Cost = Decimal.Parse(cost), Description = description, Price = Decimal.Parse(price) };//Enum.TryParse("Active", out StatusEnum myStatus);
            Enum.TryParse(itemType, out ItemType itemTypeParsed);
            item.ItemType = itemTypeParsed;

            
            try
            {
                await _itemRepo.CreateAsync(item);
            }
            catch (Exception DbUpdateException)
            {

                MessageBox.Show("Item code already exists");
            }

            EmptyControls();
            RefreshItemList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pressedEdit = true;
            if (grvItems.Rows.Count > 0)
            {
                var selectedRow = grvItems.CurrentRow;
                var selectedItem = selectedRow.DataBoundItem as Item;

                if (selectedItem is not null)
                {
                    txtCode.Text = selectedItem.Code;
                    txtDescription.Text = selectedItem.Description;
                    txtCost.Text = selectedItem.Cost.ToString();
                    txtPrice.Text = selectedItem.Price.ToString();
                    comboBoxItemType.Text = selectedItem.ItemType.ToString();
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!pressedEdit)
                return;

            if (grvItems.Rows.Count > 0)
            {
                var selectedRow = grvItems.CurrentRow;
                var selectedItem = selectedRow.DataBoundItem as Item;

                if (selectedItem is not null)
                {
                    selectedItem.Code = txtCode.Text;
                    selectedItem.Cost = Decimal.Parse(txtCost.Text);
                    selectedItem.Description = txtDescription.Text;
                    selectedItem.Price = Decimal.Parse(txtPrice.Text);                    

                    Enum.TryParse(comboBoxItemType.Text, out ItemType itemTypeParsed);
                    selectedItem.ItemType = itemTypeParsed;
                }
                try
                {
                    await _itemRepo.UpdateAsync(selectedItem.ID, selectedItem);
                }
                catch (Exception DbUpdateException)
                {

                    MessageBox.Show("Item code already exists");
                }
                
                RefreshItemList();
            }
            EmptyControls();            
            pressedEdit = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvItems.Rows.Count > 0)
            {
                var selectedRow = grvItems.CurrentRow;
                var selectedItem = selectedRow.DataBoundItem as Item;

                if (selectedItem is not null)
                {
                    await _itemRepo.DeleteAsync(selectedItem.ID);
                    RefreshItemList();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyControls();    
            pressedEdit = false;
        }

        private void grvItems_DataBindingComplete(object sender,
        DataGridViewBindingCompleteEventArgs e)
        {
            // Hide some of the columns.            
            grvItems.Columns["TransactionLine"].Visible = false;
            grvItems.Columns["ID"].Visible = false;


            grvItems.AutoResizeColumns();
        }
    }
}

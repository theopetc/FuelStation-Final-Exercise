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
    public partial class CustomerForm : Form
    {
        private readonly IEntityRepo<Customer> _customerRepo;
        private bool pressedEdit = false;

        public CustomerForm(IEntityRepo<Customer> customerRepo)
        {
            InitializeComponent();
            _customerRepo = customerRepo;            
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            RefreshCustomerList();
        }

        private async void RefreshCustomerList()
        {
            grvCustomers.DataSource = null;            
            grvCustomers.DataSource = await _customerRepo.GetAllAsync();

            grvCustomers.Update();
            grvCustomers.Refresh();
        }

        private void EmptyTextBoxes()
        {
            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtCardNumber.Text = string.Empty;
        }

        private async void btnAdd_ClickAsync(object sender, EventArgs e)
        {
            if (pressedEdit)
                return;

            var name = txtName.Text;
            var surname = txtSurname.Text;
            var cardNumber = txtCardNumber.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(cardNumber))
            {
                MessageBox.Show("Empty Textboxes!");
                return;
            }

            var customer = new Customer() { Name = name, Surname = surname, CardNumber = cardNumber };
            await _customerRepo.CreateAsync(customer);

            EmptyTextBoxes();
            RefreshCustomerList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pressedEdit = true;
            if (grvCustomers.Rows.Count > 0)
            {
                var selectedRow = grvCustomers.CurrentRow;
                var selectedCustomer = selectedRow.DataBoundItem as Customer;

                if (selectedCustomer is not null)
                {
                    txtName.Text = selectedCustomer.Name;
                    txtSurname.Text = selectedCustomer.Surname;
                    txtCardNumber.Text = selectedCustomer.CardNumber;
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvCustomers.Rows.Count > 0)
            {
                var selectedRow = grvCustomers.CurrentRow;
                var selectedCustomer = selectedRow.DataBoundItem as Customer;

                if (selectedCustomer is not null)
                {
                    await _customerRepo.DeleteAsync(selectedCustomer.ID);
                    RefreshCustomerList();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyTextBoxes();
            pressedEdit = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!pressedEdit)
                return;

            if (grvCustomers.Rows.Count > 0)
            {
                var selectedRow = grvCustomers.CurrentRow;
                var selectedCustomer = selectedRow.DataBoundItem as Customer;

                if (selectedCustomer is not null)
                {
                    selectedCustomer.Name = txtName.Text;
                    selectedCustomer.Surname = txtSurname.Text;
                    selectedCustomer.CardNumber = txtCardNumber.Text;                    
                }
                await _customerRepo.UpdateAsync(selectedCustomer.ID, selectedCustomer);
                RefreshCustomerList();
            }
            EmptyTextBoxes();
            pressedEdit = false;
        }
    }
}

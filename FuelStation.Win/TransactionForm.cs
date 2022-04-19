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
    public partial class TransactionForm : Form
    {
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Item> _itemRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IEntityRepo<Transaction> _transactionRepo;
        //private readonly IEntityRepo<TransactionLine> _transactionLineRepo;

        public TransactionForm(IEntityRepo<Customer> customerRepo, IEntityRepo<Item> itemRepo,
                        IEntityRepo<Employee> employeeRepo, IEntityRepo<Transaction> transactionRepo)
        {
            _customerRepo = customerRepo;
            _itemRepo = itemRepo;
            _employeeRepo = employeeRepo;
            _transactionRepo = transactionRepo;
            InitializeComponent();
        }
        public TransactionForm()
        {
            InitializeComponent();            
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            PopulateComboBoxes();
            EmptyControls();
        }

        private async void PopulateComboBoxes()
        {
            List<string> customerList = new List<string>();
            var customers = await _customerRepo.GetAllAsync();
            foreach (var customer in customers)
            {
                customerList.Add(customer.CardNumber);
            }

            List<string> employeeList = new List<string>();
            var employees = await _employeeRepo.GetAllAsync();
            foreach (var employee in employees)
            {
                employeeList.Add(employee.Name + " " + employee.Surname);
            }

            List<string> itemList = new List<string>();
            var items = await _itemRepo.GetAllAsync();
            foreach (var item in items)
            {
                itemList.Add(item.Description);
            }

            comboBoxCustomer.DataSource = customerList;
            comboBoxEmployee.DataSource = employeeList; 
            comboBoxItem.DataSource = itemList;
            await RefreshTransactionListAsync();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm(_customerRepo);
            customerForm.ShowDialog();
        }

        private async void btnAddTransaction_Click(object sender, EventArgs e)
        {
            Customer foundCustomer = new();
            Employee foundEmployee = new();
            var customerCardNumber = comboBoxCustomer.Text;
            var employeeFullName = comboBoxEmployee.Text;
            var employeeName = employeeFullName.Split(' ');

            if (string.IsNullOrEmpty(customerCardNumber) || string.IsNullOrEmpty(employeeFullName))
            {
                MessageBox.Show("Empty Textboxes!");
                return;
            }

            var customerList = await _customerRepo.GetAllAsync();
            foreach (var customer in customerList)
            {
                if (customer.CardNumber == customerCardNumber)
                {
                    foundCustomer = customer;
                }
            }            

            var employeeList = await _employeeRepo.GetAllAsync();
            foreach (var employee in employeeList)
            {
                if (employee.Surname == employeeName[1])
                {
                    foundEmployee = employee;
                }
            }            

            Transaction newTransaction = new Transaction();
            newTransaction.Date = DateTime.Now;
            newTransaction.EmployeeID = foundEmployee.ID;
            newTransaction.CustomerID = foundCustomer.ID;
            newTransaction.PaymentMethod = PaymentMethod.Cash;                               

            await _transactionRepo.CreateAsync(newTransaction);
            EmptyControls();
            await RefreshTransactionListAsync();
        }

        private void EmptyControls()
        {
            comboBoxCustomer.Text = string.Empty;
            comboBoxEmployee.Text = string.Empty;
        }

        private async Task RefreshTransactionListAsync()
        {
            grvTransactions.DataSource = null;
            grvTransactions.DataSource = await _transactionRepo.GetAllAsync();

            //TODO:Get customer and employee names

            grvTransactions.Update();
            grvTransactions.Refresh();
        }

        private void grvTransactions_DataBindingComplete(object sender,
        DataGridViewBindingCompleteEventArgs e)
        {
            // Hide some of the columns.
            grvTransactions.Columns["EmployeeID"].Visible = false;
            grvTransactions.Columns["CustomerID"].Visible = false;
            grvTransactions.Columns["ID"].Visible = false;

            grvTransactions.AutoResizeColumns();
        }

        private async void btnRemoveTransaction_Click(object sender, EventArgs e)
        {
            if (grvTransactions.Rows.Count > 0)
            {
                var selectedRow = grvTransactions.CurrentRow;
                var selectedItem = selectedRow.DataBoundItem as Transaction;

                if (selectedItem is not null)
                {
                    await _transactionRepo.DeleteAsync(selectedItem.ID);
                    await RefreshTransactionListAsync();
                }
            }
        }
    }
}

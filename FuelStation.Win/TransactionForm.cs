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
            //MessageBox.Show(employeeName[1]);
            

            var customerList = await _customerRepo.GetAllAsync();
            foreach (var customer in customerList)
            {
                if (customer.CardNumber == customerCardNumber)
                {
                    foundCustomer = customer;
                }
            }
            //MessageBox.Show(foundCustomer.Name);

            var employeeList = await _employeeRepo.GetAllAsync();
            foreach (var employee in employeeList)
            {
                if (employee.Surname == employeeName[1])
                {
                    foundEmployee = employee;
                }
            }
            //MessageBox.Show(foundEmployee.Name);

            Transaction newTransaction = new Transaction();
            newTransaction.Date = DateTime.Now;
            newTransaction.EmployeeID = foundEmployee.ID;
            newTransaction.CustomerID = foundCustomer.ID;
            newTransaction.PaymentMethod = PaymentMethod.Cash;

            await _transactionRepo.CreateAsync(newTransaction);
            EmptyControls();
            RefreshTransactionListAsync();
        }

        private void EmptyControls()
        {

        }

        private async Task RefreshTransactionListAsync()
        {
            grvTransactions.DataSource = null;
            grvTransactions.DataSource = await _transactionRepo.GetAllAsync();

            grvTransactions.Update();
            grvTransactions.Refresh();
        }
    }
}

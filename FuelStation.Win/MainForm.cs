using FuelStation.EF.Repository;
using FuelStation.Model;

namespace FuelStation.Win
{
    public partial class MainForm : Form
    {
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Item> _itemRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IEntityRepo<Transaction> _transactionRepo;
        //private readonly IEntityRepo<TransactionLine> _transactionLineRepo;

        public MainForm(IEntityRepo<Customer> customerRepo, IEntityRepo<Item> itemRepo,
                        IEntityRepo<Employee> employeeRepo, IEntityRepo<Transaction> transactionRepo)
        {
            _customerRepo = customerRepo;
            _itemRepo = itemRepo;
            _employeeRepo = employeeRepo;
            _transactionRepo = transactionRepo;
            InitializeComponent();

        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            var transactionForm = new TransactionForm(_customerRepo, _itemRepo, _employeeRepo, _transactionRepo);
            transactionForm.ShowDialog();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            var itemForm = new ItemForm(_itemRepo);
            itemForm.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm(_customerRepo);
            customerForm.ShowDialog();
        }
    }
}
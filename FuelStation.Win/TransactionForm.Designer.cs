namespace FuelStation.Win
{
    partial class TransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grvTransactions = new System.Windows.Forms.DataGridView();
            this.grvTransactionLines = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnRemoveTransaction = new System.Windows.Forms.Button();
            this.btnAddTransactionLine = new System.Windows.Forms.Button();
            this.btnRemoveTransactionLine = new System.Windows.Forms.Button();
            this.btnEditTransactionLine = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).BeginInit();
            this.SuspendLayout();
            // 
            // grvTransactions
            // 
            this.grvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTransactions.Location = new System.Drawing.Point(12, 27);
            this.grvTransactions.Name = "grvTransactions";
            this.grvTransactions.RowTemplate.Height = 25;
            this.grvTransactions.Size = new System.Drawing.Size(564, 159);
            this.grvTransactions.TabIndex = 0;
            // 
            // grvTransactionLines
            // 
            this.grvTransactionLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTransactionLines.Location = new System.Drawing.Point(12, 207);
            this.grvTransactionLines.Name = "grvTransactionLines";
            this.grvTransactionLines.RowTemplate.Height = 25;
            this.grvTransactionLines.Size = new System.Drawing.Size(564, 231);
            this.grvTransactionLines.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transaction Lines";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Transaction List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(584, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Employee";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(649, 52);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(121, 23);
            this.comboBoxCustomer.TabIndex = 6;
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(649, 81);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(121, 23);
            this.comboBoxEmployee.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Transaction Info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(649, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Transaction Line Info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(614, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Item";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(592, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(649, 267);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 23);
            this.txtQuantity.TabIndex = 14;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Location = new System.Drawing.Point(649, 110);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(100, 23);
            this.btnAddTransaction.TabIndex = 18;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // btnRemoveTransaction
            // 
            this.btnRemoveTransaction.Location = new System.Drawing.Point(649, 139);
            this.btnRemoveTransaction.Name = "btnRemoveTransaction";
            this.btnRemoveTransaction.Size = new System.Drawing.Size(130, 23);
            this.btnRemoveTransaction.TabIndex = 19;
            this.btnRemoveTransaction.Text = "Remove Transaction";
            this.btnRemoveTransaction.UseVisualStyleBackColor = true;
            // 
            // btnAddTransactionLine
            // 
            this.btnAddTransactionLine.Location = new System.Drawing.Point(649, 296);
            this.btnAddTransactionLine.Name = "btnAddTransactionLine";
            this.btnAddTransactionLine.Size = new System.Drawing.Size(132, 23);
            this.btnAddTransactionLine.TabIndex = 20;
            this.btnAddTransactionLine.Text = "Add Transaction Line";
            this.btnAddTransactionLine.UseVisualStyleBackColor = true;
            // 
            // btnRemoveTransactionLine
            // 
            this.btnRemoveTransactionLine.Location = new System.Drawing.Point(649, 325);
            this.btnRemoveTransactionLine.Name = "btnRemoveTransactionLine";
            this.btnRemoveTransactionLine.Size = new System.Drawing.Size(146, 23);
            this.btnRemoveTransactionLine.TabIndex = 21;
            this.btnRemoveTransactionLine.Text = "Remove Transaction Line";
            this.btnRemoveTransactionLine.UseVisualStyleBackColor = true;
            // 
            // btnEditTransactionLine
            // 
            this.btnEditTransactionLine.Location = new System.Drawing.Point(649, 354);
            this.btnEditTransactionLine.Name = "btnEditTransactionLine";
            this.btnEditTransactionLine.Size = new System.Drawing.Size(75, 23);
            this.btnEditTransactionLine.TabIndex = 22;
            this.btnEditTransactionLine.Text = "Edit";
            this.btnEditTransactionLine.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(649, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(651, 230);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(121, 23);
            this.comboBoxItem.TabIndex = 24;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Location = new System.Drawing.Point(649, 168);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(100, 23);
            this.btnAddNewCustomer.TabIndex = 25;
            this.btnAddNewCustomer.Text = "Add Customer";
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 450);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Controls.Add(this.comboBoxItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEditTransactionLine);
            this.Controls.Add(this.btnRemoveTransactionLine);
            this.Controls.Add(this.btnAddTransactionLine);
            this.Controls.Add(this.btnRemoveTransaction);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxEmployee);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grvTransactionLines);
            this.Controls.Add(this.grvTransactions);
            this.Name = "TransactionForm";
            this.Text = "Transaction Form";
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView grvTransactions;
        private DataGridView grvTransactionLines;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxCustomer;
        private ComboBox comboBoxEmployee;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtQuantity;
        private Button btnAddTransaction;
        private Button btnRemoveTransaction;
        private Button btnAddTransactionLine;
        private Button btnRemoveTransactionLine;
        private Button btnEditTransactionLine;
        private Button btnCancel;
        private ComboBox comboBoxItem;
        private Button btnAddNewCustomer;
    }
}
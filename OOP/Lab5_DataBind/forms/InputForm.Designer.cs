namespace Lab5_DataBind
{
    partial class InputForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelSecondName = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDataBase = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.radioJson = new System.Windows.Forms.RadioButton();
            this.radioMySql = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 110);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(337, 150);
            this.dataGridView.TabIndex = 15;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(12, 33);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(100, 20);
            this.tbFirstName.TabIndex = 0;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(118, 33);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(118, 20);
            this.tbLastName.TabIndex = 1;
            // 
            // tbAge
            // 
            this.tbAge.Location = new System.Drawing.Point(242, 33);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(100, 20);
            this.tbAge.TabIndex = 2;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(12, 13);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(54, 13);
            this.labelFirstName.TabIndex = 4;
            this.labelFirstName.Text = "FirstName";
            // 
            // labelSecondName
            // 
            this.labelSecondName.AutoSize = true;
            this.labelSecondName.Location = new System.Drawing.Point(118, 12);
            this.labelSecondName.Name = "labelSecondName";
            this.labelSecondName.Size = new System.Drawing.Size(55, 13);
            this.labelSecondName.TabIndex = 5;
            this.labelSecondName.Text = "LastName";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(239, 12);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(26, 13);
            this.labelAge.TabIndex = 6;
            this.labelAge.Text = "Age";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(186, 58);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // btnDataBase
            // 
            this.btnDataBase.Location = new System.Drawing.Point(267, 58);
            this.btnDataBase.Name = "btnDataBase";
            this.btnDataBase.Size = new System.Drawing.Size(75, 23);
            this.btnDataBase.TabIndex = 9;
            this.btnDataBase.Text = "Database";
            this.btnDataBase.UseVisualStyleBackColor = true;
            this.btnDataBase.Click += new System.EventHandler(this.buttonDb_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(96, 58);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // radioJson
            // 
            this.radioJson.AutoSize = true;
            this.radioJson.Checked = true;
            this.radioJson.Location = new System.Drawing.Point(267, 87);
            this.radioJson.Name = "radioJson";
            this.radioJson.Size = new System.Drawing.Size(72, 17);
            this.radioJson.TabIndex = 16;
            this.radioJson.TabStop = true;
            this.radioJson.Text = "JSON File";
            this.radioJson.UseVisualStyleBackColor = true;
            // 
            // radioMySql
            // 
            this.radioMySql.AutoSize = true;
            this.radioMySql.Location = new System.Drawing.Point(175, 87);
            this.radioMySql.Name = "radioMySql";
            this.radioMySql.Size = new System.Drawing.Size(86, 17);
            this.radioMySql.TabIndex = 17;
            this.radioMySql.Text = "MySql server";
            this.radioMySql.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 90);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Allow adding dublicates.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // InputForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 271);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.radioMySql);
            this.Controls.Add(this.radioJson);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDataBase);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelSecondName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.tbAge);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.dataGridView);
            this.Name = "InputForm";
            this.Text = "Input Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelSecondName;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDataBase;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RadioButton radioJson;
        private System.Windows.Forms.RadioButton radioMySql;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}


namespace Lab5_DataBind.form
{
    partial class DbForm
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
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.tbxServer = new System.Windows.Forms.TextBox();
            this.tbxUser = new System.Windows.Forms.TextBox();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.lbAdress = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.tbxSchema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToDeleteRows = false;
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dbGridView.Location = new System.Drawing.Point(12, 125);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridView.Size = new System.Drawing.Size(337, 150);
            this.dbGridView.TabIndex = 1;
            // 
            // tbxServer
            // 
            this.tbxServer.Location = new System.Drawing.Point(12, 25);
            this.tbxServer.Name = "tbxServer";
            this.tbxServer.Size = new System.Drawing.Size(139, 20);
            this.tbxServer.TabIndex = 2;
            // 
            // tbxUser
            // 
            this.tbxUser.Location = new System.Drawing.Point(157, 25);
            this.tbxUser.Name = "tbxUser";
            this.tbxUser.Size = new System.Drawing.Size(100, 20);
            this.tbxUser.TabIndex = 3;
            // 
            // tbxPass
            // 
            this.tbxPass.Location = new System.Drawing.Point(263, 25);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.PasswordChar = '*';
            this.tbxPass.Size = new System.Drawing.Size(86, 20);
            this.tbxPass.TabIndex = 4;
            // 
            // lbAdress
            // 
            this.lbAdress.AutoSize = true;
            this.lbAdress.Location = new System.Drawing.Point(13, 6);
            this.lbAdress.Name = "lbAdress";
            this.lbAdress.Size = new System.Drawing.Size(38, 13);
            this.lbAdress.TabIndex = 5;
            this.lbAdress.Text = "Server";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(157, 6);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(29, 13);
            this.lbUser.TabIndex = 6;
            this.lbUser.Text = "User";
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(260, 6);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(53, 13);
            this.lbPass.TabIndex = 7;
            this.lbPass.Text = "Password";
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(210, 66);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(103, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(111, 66);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(93, 23);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Enabled = false;
            this.btnAddAll.Location = new System.Drawing.Point(192, 96);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(121, 23);
            this.btnAddAll.TabIndex = 10;
            this.btnAddAll.Text = "Move From Input";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // tbxSchema
            // 
            this.tbxSchema.Location = new System.Drawing.Point(12, 69);
            this.tbxSchema.Name = "tbxSchema";
            this.tbxSchema.Size = new System.Drawing.Size(93, 20);
            this.tbxSchema.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Schema";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(111, 96);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 289);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSchema);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.lbAdress);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.tbxUser);
            this.Controls.Add(this.tbxServer);
            this.Controls.Add(this.dbGridView);
            this.Name = "DbForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DbForm";
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGridView;
        private System.Windows.Forms.TextBox tbxServer;
        private System.Windows.Forms.TextBox tbxUser;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.Label lbAdress;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.TextBox tbxSchema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;

    }
}
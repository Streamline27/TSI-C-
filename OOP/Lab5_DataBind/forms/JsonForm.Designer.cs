namespace Lab5_DataBind.forms
{
    partial class JsonForm
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
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFlush = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToDeleteRows = false;
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dbGridView.Location = new System.Drawing.Point(12, 99);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridView.Size = new System.Drawing.Size(337, 150);
            this.dbGridView.TabIndex = 2;
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Location = new System.Drawing.Point(13, 31);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.Size = new System.Drawing.Size(343, 20);
            this.tbxFilePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Path:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(98, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFlush
            // 
            this.btnFlush.Enabled = false;
            this.btnFlush.Location = new System.Drawing.Point(179, 57);
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.Size = new System.Drawing.Size(96, 23);
            this.btnFlush.TabIndex = 6;
            this.btnFlush.Text = "Move From Input";
            this.btnFlush.UseVisualStyleBackColor = true;
            this.btnFlush.Click += new System.EventHandler(this.btnFlush_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(281, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(17, 57);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // JsonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 261);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFlush);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxFilePath);
            this.Controls.Add(this.dbGridView);
            this.Name = "JsonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JsonForm";
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGridView;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFlush;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnConnect;
    }
}
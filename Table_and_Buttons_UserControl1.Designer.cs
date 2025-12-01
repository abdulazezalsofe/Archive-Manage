namespace ArchifProjcet_2
{
    partial class Table_and_Buttons_UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewUserControl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserControl)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUserControl
            // 
            this.dataGridViewUserControl.AllowUserToAddRows = false;
            this.dataGridViewUserControl.AllowUserToDeleteRows = false;
            this.dataGridViewUserControl.AllowUserToResizeRows = false;
            this.dataGridViewUserControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserControl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewUserControl.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUserControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUserControl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewUserControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUserControl.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUserControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dataGridViewUserControl.Name = "dataGridViewUserControl";
            this.dataGridViewUserControl.ReadOnly = true;
            this.dataGridViewUserControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewUserControl.RowHeadersWidth = 62;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rubik Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewUserControl.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUserControl.RowTemplate.Height = 28;
            this.dataGridViewUserControl.Size = new System.Drawing.Size(4083, 2726);
            this.dataGridViewUserControl.TabIndex = 2;
            this.dataGridViewUserControl.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUserControl_CellFormatting);
            // 
            // Table_and_Buttons_UserControl1
            // 
            this.Appearance.Font = new System.Drawing.Font("Rubik", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewUserControl);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "Table_and_Buttons_UserControl1";
            this.Size = new System.Drawing.Size(4083, 2726);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridViewUserControl;
    }
}

namespace Fowl_Giveaways
{
    partial class Winners
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winners));
            this.WinnerGrid = new System.Windows.Forms.DataGridView();
            this.Winner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.WinnerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WinnerGrid
            // 
            this.WinnerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WinnerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Winner,
            this.Item});
            this.WinnerGrid.Location = new System.Drawing.Point(13, 27);
            this.WinnerGrid.Name = "WinnerGrid";
            this.WinnerGrid.Size = new System.Drawing.Size(270, 180);
            this.WinnerGrid.TabIndex = 0;
            // 
            // Winner
            // 
            this.Winner.HeaderText = "Winner";
            this.Winner.Name = "Winner";
            this.Winner.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Winners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 219);
            this.Controls.Add(this.WinnerGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Winners";
            this.Text = "Winners";
            ((System.ComponentModel.ISupportInitialize)(this.WinnerGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WinnerGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Winner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
    }
}
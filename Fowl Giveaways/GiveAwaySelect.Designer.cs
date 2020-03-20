namespace Fowl_Giveaways
{
    partial class GiveAwaySelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiveAwaySelect));
            this.giveAwaySel = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // giveAwaySel
            // 
            this.giveAwaySel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.giveAwaySel.FormattingEnabled = true;
            this.giveAwaySel.Location = new System.Drawing.Point(12, 1);
            this.giveAwaySel.Name = "giveAwaySel";
            this.giveAwaySel.Size = new System.Drawing.Size(121, 176);
            this.giveAwaySel.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 169);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(121, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // GiveAwaySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(145, 193);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.giveAwaySel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GiveAwaySelect";
            this.Text = "GiveAwaySelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox giveAwaySel;
        private System.Windows.Forms.Button btnSelect;
    }
}
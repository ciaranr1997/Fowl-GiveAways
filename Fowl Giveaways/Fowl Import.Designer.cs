namespace Fowl_Giveaways
{
    partial class Fowl_Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fowl_Import));
            this.importList = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importList
            // 
            this.importList.Location = new System.Drawing.Point(13, 12);
            this.importList.Multiline = true;
            this.importList.Name = "importList";
            this.importList.Size = new System.Drawing.Size(440, 342);
            this.importList.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(13, 360);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(440, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Fowl_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 395);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.importList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fowl_Import";
            this.Text = "Fowl_Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox importList;
        private System.Windows.Forms.Button btnImport;
    }
}
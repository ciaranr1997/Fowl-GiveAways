namespace Fowl_Giveaways
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGiveawayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectGiveawayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureGiveawayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fowlImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GiveAwayMembers = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KnownAs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tokens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membersMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickWinner = new System.Windows.Forms.PictureBox();
            this.giveawayName = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GiveAwayMembers)).BeginInit();
            this.membersMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickWinner)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGiveawayToolStripMenuItem,
            this.selectGiveawayToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGiveawayToolStripMenuItem
            // 
            this.newGiveawayToolStripMenuItem.Name = "newGiveawayToolStripMenuItem";
            this.newGiveawayToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newGiveawayToolStripMenuItem.Text = "New Giveaway";
            this.newGiveawayToolStripMenuItem.Click += new System.EventHandler(this.newGiveawayToolStripMenuItem_Click);
            // 
            // selectGiveawayToolStripMenuItem
            // 
            this.selectGiveawayToolStripMenuItem.Name = "selectGiveawayToolStripMenuItem";
            this.selectGiveawayToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.selectGiveawayToolStripMenuItem.Text = "Select giveaway";
            this.selectGiveawayToolStripMenuItem.Click += new System.EventHandler(this.selectGiveawayToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureGiveawayToolStripMenuItem,
            this.fowlImportToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // configureGiveawayToolStripMenuItem
            // 
            this.configureGiveawayToolStripMenuItem.Name = "configureGiveawayToolStripMenuItem";
            this.configureGiveawayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.configureGiveawayToolStripMenuItem.Text = "Configure Giveaway";
            this.configureGiveawayToolStripMenuItem.Click += new System.EventHandler(this.configureGiveawayToolStripMenuItem_Click);
            // 
            // fowlImportToolStripMenuItem
            // 
            this.fowlImportToolStripMenuItem.Name = "fowlImportToolStripMenuItem";
            this.fowlImportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fowlImportToolStripMenuItem.Text = "Fowl Import";
            this.fowlImportToolStripMenuItem.Click += new System.EventHandler(this.fowlImportToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // GiveAwayMembers
            // 
            this.GiveAwayMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GiveAwayMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.UserName,
            this.KnownAs,
            this.Tokens});
            this.GiveAwayMembers.ContextMenuStrip = this.membersMenu;
            this.GiveAwayMembers.Location = new System.Drawing.Point(13, 111);
            this.GiveAwayMembers.Name = "GiveAwayMembers";
            this.GiveAwayMembers.Size = new System.Drawing.Size(529, 327);
            this.GiveAwayMembers.TabIndex = 1;
            this.GiveAwayMembers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GiveAwayMembers_CellValueChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Username";
            this.UserName.Name = "UserName";
            // 
            // KnownAs
            // 
            this.KnownAs.HeaderText = "Name";
            this.KnownAs.Name = "KnownAs";
            // 
            // Tokens
            // 
            this.Tokens.HeaderText = "Tokens";
            this.Tokens.Name = "Tokens";
            // 
            // membersMenu
            // 
            this.membersMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeEntryToolStripMenuItem});
            this.membersMenu.Name = "membersMenu";
            this.membersMenu.Size = new System.Drawing.Size(148, 26);
            // 
            // removeEntryToolStripMenuItem
            // 
            this.removeEntryToolStripMenuItem.Name = "removeEntryToolStripMenuItem";
            this.removeEntryToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.removeEntryToolStripMenuItem.Text = "Remove Entry";
            this.removeEntryToolStripMenuItem.Click += new System.EventHandler(this.removeEntryToolStripMenuItem_Click);
            // 
            // pickWinner
            // 
            this.pickWinner.Image = ((System.Drawing.Image)(resources.GetObject("pickWinner.Image")));
            this.pickWinner.Location = new System.Drawing.Point(464, 27);
            this.pickWinner.Name = "pickWinner";
            this.pickWinner.Size = new System.Drawing.Size(78, 78);
            this.pickWinner.TabIndex = 2;
            this.pickWinner.TabStop = false;
            this.pickWinner.Click += new System.EventHandler(this.pickWinner_Click);
            // 
            // giveawayName
            // 
            this.giveawayName.AutoSize = true;
            this.giveawayName.Location = new System.Drawing.Point(13, 57);
            this.giveawayName.Name = "giveawayName";
            this.giveawayName.Size = new System.Drawing.Size(97, 13);
            this.giveawayName.TabIndex = 3;
            this.giveawayName.Text = "xxxxxx GIVEAWAY";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 450);
            this.Controls.Add(this.giveawayName);
            this.Controls.Add(this.pickWinner);
            this.Controls.Add(this.GiveAwayMembers);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Fowl Giveaways!";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GiveAwayMembers)).EndInit();
            this.membersMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pickWinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGiveawayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectGiveawayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureGiveawayToolStripMenuItem;
        private System.Windows.Forms.DataGridView GiveAwayMembers;
        private System.Windows.Forms.PictureBox pickWinner;
        private System.Windows.Forms.ContextMenuStrip membersMenu;
        private System.Windows.Forms.ToolStripMenuItem removeEntryToolStripMenuItem;
        private System.Windows.Forms.Label giveawayName;
        private System.Windows.Forms.ToolStripMenuItem fowlImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KnownAs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tokens;
    }
}


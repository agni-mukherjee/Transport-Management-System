
namespace TRANSPORT_1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportReviewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fullBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFalseEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addDriverToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addDriverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVHEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vechicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._DATA = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 675);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1116, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportReviewToolStripMenuItem1
            // 
            this.reportReviewToolStripMenuItem1.Name = "reportReviewToolStripMenuItem1";
            this.reportReviewToolStripMenuItem1.Size = new System.Drawing.Size(220, 26);
            this.reportReviewToolStripMenuItem1.Text = "Report / Review";
            this.reportReviewToolStripMenuItem1.Click += new System.EventHandler(this.reportReviewToolStripMenuItem1_Click);
            // 
            // fullBookToolStripMenuItem
            // 
            this.fullBookToolStripMenuItem.Name = "fullBookToolStripMenuItem";
            this.fullBookToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.fullBookToolStripMenuItem.Text = "Book Vehicle";
            this.fullBookToolStripMenuItem.Click += new System.EventHandler(this.fullBookToolStripMenuItem_Click);
            // 
            // bookingToolStripMenuItem
            // 
            this.bookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullBookToolStripMenuItem,
            this.reportReviewToolStripMenuItem1,
            this.billingToolStripMenuItem,
            this.deleteFalseEntriesToolStripMenuItem});
            this.bookingToolStripMenuItem.Name = "bookingToolStripMenuItem";
            this.bookingToolStripMenuItem.Size = new System.Drawing.Size(78, 26);
            this.bookingToolStripMenuItem.Text = "Booking";
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.billingToolStripMenuItem.Text = "Billing";
            this.billingToolStripMenuItem.Click += new System.EventHandler(this.billingToolStripMenuItem_Click);
            // 
            // deleteFalseEntriesToolStripMenuItem
            // 
            this.deleteFalseEntriesToolStripMenuItem.Name = "deleteFalseEntriesToolStripMenuItem";
            this.deleteFalseEntriesToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.deleteFalseEntriesToolStripMenuItem.Text = "Delete False Entries";
            // 
            // reviewReportToolStripMenuItem
            // 
            this.reviewReportToolStripMenuItem.Name = "reviewReportToolStripMenuItem";
            this.reviewReportToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.reviewReportToolStripMenuItem.Text = "Review / Report";
            this.reviewReportToolStripMenuItem.Click += new System.EventHandler(this.reviewReportToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientToolStripMenuItem,
            this.reviewReportToolStripMenuItem});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(61, 26);
            this.clientToolStripMenuItem.Text = "Client";
            // 
            // addClientToolStripMenuItem
            // 
            this.addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            this.addClientToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.addClientToolStripMenuItem.Text = "Add Client";
            this.addClientToolStripMenuItem.Click += new System.EventHandler(this.addClientToolStripMenuItem_Click);
            // 
            // reviewReportToolStripMenuItem1
            // 
            this.reviewReportToolStripMenuItem1.Name = "reviewReportToolStripMenuItem1";
            this.reviewReportToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.reviewReportToolStripMenuItem1.Text = "Review / Report";
            this.reviewReportToolStripMenuItem1.Click += new System.EventHandler(this.reviewReportToolStripMenuItem1_Click);
            // 
            // addDriverToolStripMenuItem1
            // 
            this.addDriverToolStripMenuItem1.Name = "addDriverToolStripMenuItem1";
            this.addDriverToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.addDriverToolStripMenuItem1.Text = "Add Driver";
            this.addDriverToolStripMenuItem1.Click += new System.EventHandler(this.addDriverToolStripMenuItem1_Click);
            // 
            // addDriverToolStripMenuItem
            // 
            this.addDriverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDriverToolStripMenuItem1,
            this.reviewReportToolStripMenuItem1});
            this.addDriverToolStripMenuItem.Name = "addDriverToolStripMenuItem";
            this.addDriverToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.addDriverToolStripMenuItem.Text = "Driver";
            this.addDriverToolStripMenuItem.Click += new System.EventHandler(this.addDriverToolStripMenuItem_Click);
            // 
            // reportReviewToolStripMenuItem
            // 
            this.reportReviewToolStripMenuItem.Name = "reportReviewToolStripMenuItem";
            this.reportReviewToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.reportReviewToolStripMenuItem.Text = "Report / Review";
            this.reportReviewToolStripMenuItem.Click += new System.EventHandler(this.reportReviewToolStripMenuItem_Click);
            // 
            // addVHEToolStripMenuItem
            // 
            this.addVHEToolStripMenuItem.Name = "addVHEToolStripMenuItem";
            this.addVHEToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.addVHEToolStripMenuItem.Text = "Add VHE";
            this.addVHEToolStripMenuItem.Click += new System.EventHandler(this.addVHEToolStripMenuItem_Click);
            // 
            // vechicleToolStripMenuItem
            // 
            this.vechicleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVHEToolStripMenuItem,
            this.reportReviewToolStripMenuItem,
            this.addDriverToolStripMenuItem});
            this.vechicleToolStripMenuItem.Name = "vechicleToolStripMenuItem";
            this.vechicleToolStripMenuItem.Size = new System.Drawing.Size(77, 26);
            this.vechicleToolStripMenuItem.Text = "Vechicle";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vechicleToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.bookingToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1116, 30);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "name";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(659, 680);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(547, 680);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Logged In as :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(794, 680);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log In Time :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(899, 680);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "time";
            // 
            // _DATA
            // 
            this._DATA.AutoSize = true;
            this._DATA.Location = new System.Drawing.Point(432, 9);
            this._DATA.Name = "_DATA";
            this._DATA.Size = new System.Drawing.Size(368, 17);
            this._DATA.TabIndex = 51;
            this._DATA.Text = "D:\\Project\\TRANSPORT_1\\TRANSPORT_1\\TransDB";
            this._DATA.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1116, 701);
            this.ControlBox = false;
            this.Controls.Add(this._DATA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transport Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportReviewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fullBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addDriverToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addDriverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVHEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vechicleToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFalseEntriesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _DATA;
    }
}


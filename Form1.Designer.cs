namespace VkForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.authorizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UserName = new System.Windows.Forms.Label();
            this.Posts = new System.Windows.Forms.DataGridView();
            this.ShowPostsButton = new System.Windows.Forms.Button();
            this.DownloadCommentsButton = new System.Windows.Forms.Button();
            this.GroupList = new System.Windows.Forms.ComboBox();
            this.numberOfPosts = new System.Windows.Forms.TextBox();
            this.selectedPostsLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveUsersIDtoFileButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.AdminIDLable = new System.Windows.Forms.Label();
            this.SaveToFileprogressBar1 = new System.Windows.Forms.ProgressBar();
            this.adminIDTextBox = new System.Windows.Forms.RichTextBox();
            this.ThresholdValueLabel = new System.Windows.Forms.Label();
            this.ThresholdValueTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Posts)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // authorizeToolStripMenuItem
            // 
            this.authorizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorizeToolStripMenuItem1});
            this.authorizeToolStripMenuItem.Name = "authorizeToolStripMenuItem";
            this.authorizeToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.authorizeToolStripMenuItem.Text = "Account";
            // 
            // authorizeToolStripMenuItem1
            // 
            this.authorizeToolStripMenuItem1.Name = "authorizeToolStripMenuItem1";
            this.authorizeToolStripMenuItem1.Size = new System.Drawing.Size(148, 26);
            this.authorizeToolStripMenuItem1.Text = "Authorize";
            this.authorizeToolStripMenuItem1.Click += new System.EventHandler(this.authorizeToolStripMenuItem1_Click);
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(12, 28);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(0, 17);
            this.UserName.TabIndex = 1;
            // 
            // Posts
            // 
            this.Posts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Posts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Posts.Location = new System.Drawing.Point(12, 48);
            this.Posts.Name = "Posts";
            this.Posts.RowTemplate.Height = 24;
            this.Posts.Size = new System.Drawing.Size(586, 292);
            this.Posts.TabIndex = 2;
            this.Posts.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Posts_CellMouseDoubleClick);
            // 
            // ShowPostsButton
            // 
            this.ShowPostsButton.Location = new System.Drawing.Point(751, 78);
            this.ShowPostsButton.Name = "ShowPostsButton";
            this.ShowPostsButton.Size = new System.Drawing.Size(101, 26);
            this.ShowPostsButton.TabIndex = 3;
            this.ShowPostsButton.Text = "Show posts";
            this.ShowPostsButton.UseVisualStyleBackColor = true;
            this.ShowPostsButton.Click += new System.EventHandler(this.ShowPostsButton_Click);
            // 
            // DownloadCommentsButton
            // 
            this.DownloadCommentsButton.Location = new System.Drawing.Point(349, 384);
            this.DownloadCommentsButton.Name = "DownloadCommentsButton";
            this.DownloadCommentsButton.Size = new System.Drawing.Size(249, 32);
            this.DownloadCommentsButton.TabIndex = 4;
            this.DownloadCommentsButton.Text = "Download comments from this post";
            this.DownloadCommentsButton.UseVisualStyleBackColor = true;
            this.DownloadCommentsButton.Click += new System.EventHandler(this.DownloadCommentsButton_Click);
            // 
            // GroupList
            // 
            this.GroupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupList.FormattingEnabled = true;
            this.GroupList.Location = new System.Drawing.Point(604, 48);
            this.GroupList.Name = "GroupList";
            this.GroupList.Size = new System.Drawing.Size(248, 24);
            this.GroupList.TabIndex = 6;
            // 
            // numberOfPosts
            // 
            this.numberOfPosts.Location = new System.Drawing.Point(658, 78);
            this.numberOfPosts.Name = "numberOfPosts";
            this.numberOfPosts.Size = new System.Drawing.Size(87, 22);
            this.numberOfPosts.TabIndex = 7;
            this.numberOfPosts.Text = "20";
            // 
            // selectedPostsLabel
            // 
            this.selectedPostsLabel.AutoSize = true;
            this.selectedPostsLabel.Location = new System.Drawing.Point(604, 141);
            this.selectedPostsLabel.Name = "selectedPostsLabel";
            this.selectedPostsLabel.Size = new System.Drawing.Size(0, 17);
            this.selectedPostsLabel.TabIndex = 9;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(218, 384);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(125, 32);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Clear list";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SaveUsersIDtoFileButton
            // 
            this.SaveUsersIDtoFileButton.Location = new System.Drawing.Point(218, 346);
            this.SaveUsersIDtoFileButton.Name = "SaveUsersIDtoFileButton";
            this.SaveUsersIDtoFileButton.Size = new System.Drawing.Size(125, 32);
            this.SaveUsersIDtoFileButton.TabIndex = 11;
            this.SaveUsersIDtoFileButton.Text = "Save";
            this.SaveUsersIDtoFileButton.UseVisualStyleBackColor = true;
            this.SaveUsersIDtoFileButton.Click += new System.EventHandler(this.SaveUsersIDtoFileButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(349, 346);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(249, 14);
            this.progressBar1.TabIndex = 12;
            // 
            // AdminIDLable
            // 
            this.AdminIDLable.AutoSize = true;
            this.AdminIDLable.Location = new System.Drawing.Point(12, 352);
            this.AdminIDLable.Name = "AdminIDLable";
            this.AdminIDLable.Size = new System.Drawing.Size(116, 17);
            this.AdminIDLable.TabIndex = 14;
            this.AdminIDLable.Text = "Administrator ID :";
            // 
            // SaveToFileprogressBar1
            // 
            this.SaveToFileprogressBar1.Location = new System.Drawing.Point(349, 363);
            this.SaveToFileprogressBar1.Name = "SaveToFileprogressBar1";
            this.SaveToFileprogressBar1.Size = new System.Drawing.Size(249, 14);
            this.SaveToFileprogressBar1.TabIndex = 15;
            // 
            // adminIDTextBox
            // 
            this.adminIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminIDTextBox.Location = new System.Drawing.Point(132, 346);
            this.adminIDTextBox.Name = "adminIDTextBox";
            this.adminIDTextBox.Size = new System.Drawing.Size(80, 32);
            this.adminIDTextBox.TabIndex = 16;
            this.adminIDTextBox.Text = "77777";
            // 
            // ThresholdValueLabel
            // 
            this.ThresholdValueLabel.AutoSize = true;
            this.ThresholdValueLabel.Location = new System.Drawing.Point(12, 393);
            this.ThresholdValueLabel.Name = "ThresholdValueLabel";
            this.ThresholdValueLabel.Size = new System.Drawing.Size(114, 17);
            this.ThresholdValueLabel.TabIndex = 17;
            this.ThresholdValueLabel.Text = "Threshold value:";
            // 
            // ThresholdValueTextBox
            // 
            this.ThresholdValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThresholdValueTextBox.Location = new System.Drawing.Point(132, 387);
            this.ThresholdValueTextBox.Name = "ThresholdValueTextBox";
            this.ThresholdValueTextBox.Size = new System.Drawing.Size(80, 32);
            this.ThresholdValueTextBox.TabIndex = 16;
            this.ThresholdValueTextBox.Text = "5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 435);
            this.Controls.Add(this.ThresholdValueLabel);
            this.Controls.Add(this.ThresholdValueTextBox);
            this.Controls.Add(this.adminIDTextBox);
            this.Controls.Add(this.SaveToFileprogressBar1);
            this.Controls.Add(this.AdminIDLable);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.SaveUsersIDtoFileButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.selectedPostsLabel);
            this.Controls.Add(this.numberOfPosts);
            this.Controls.Add(this.GroupList);
            this.Controls.Add(this.DownloadCommentsButton);
            this.Controls.Add(this.ShowPostsButton);
            this.Controls.Add(this.Posts);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Vk API";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Posts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem authorizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorizeToolStripMenuItem1;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.DataGridView Posts;
        private System.Windows.Forms.Button ShowPostsButton;
        private System.Windows.Forms.Button DownloadCommentsButton;
        private System.Windows.Forms.ComboBox GroupList;
        private System.Windows.Forms.TextBox numberOfPosts;
        private System.Windows.Forms.Label selectedPostsLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SaveUsersIDtoFileButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label AdminIDLable;
        private System.Windows.Forms.ProgressBar SaveToFileprogressBar1;
        private System.Windows.Forms.RichTextBox adminIDTextBox;
        private System.Windows.Forms.Label ThresholdValueLabel;
        private System.Windows.Forms.RichTextBox ThresholdValueTextBox;
    }
}


namespace NewRocketApp
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
            this.emailBtn = new System.Windows.Forms.Button();
            this.listViewAPI = new System.Windows.Forms.ListView();
            this.dbLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewDB = new System.Windows.Forms.ListView();
            this.refreshDbBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // emailBtn
            // 
            this.emailBtn.Location = new System.Drawing.Point(866, 35);
            this.emailBtn.Name = "emailBtn";
            this.emailBtn.Size = new System.Drawing.Size(142, 43);
            this.emailBtn.TabIndex = 0;
            this.emailBtn.Text = "send email";
            this.emailBtn.UseVisualStyleBackColor = true;
            this.emailBtn.Click += new System.EventHandler(this.emailBtnClick);
            // 
            // listViewAPI
            // 
            this.listViewAPI.HideSelection = false;
            this.listViewAPI.Location = new System.Drawing.Point(25, 108);
            this.listViewAPI.Name = "listViewAPI";
            this.listViewAPI.Size = new System.Drawing.Size(502, 300);
            this.listViewAPI.TabIndex = 4;
            this.listViewAPI.UseCompatibleStateImageBehavior = false;
            // 
            // dbLabel
            // 
            this.dbLabel.Location = new System.Drawing.Point(0, 0);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(100, 23);
            this.dbLabel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(21, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rockets Launched in the next 7 days";
            // 
            // listViewDB
            // 
            this.listViewDB.HideSelection = false;
            this.listViewDB.Location = new System.Drawing.Point(547, 108);
            this.listViewDB.Name = "listViewDB";
            this.listViewDB.Size = new System.Drawing.Size(561, 300);
            this.listViewDB.TabIndex = 8;
            this.listViewDB.UseCompatibleStateImageBehavior = false;
            // 
            // refreshDbBtn
            // 
            this.refreshDbBtn.Location = new System.Drawing.Point(722, 35);
            this.refreshDbBtn.Name = "refreshDbBtn";
            this.refreshDbBtn.Size = new System.Drawing.Size(110, 43);
            this.refreshDbBtn.TabIndex = 9;
            this.refreshDbBtn.Text = "Refresh DB";
            this.refreshDbBtn.UseVisualStyleBackColor = true;
            this.refreshDbBtn.Click += new System.EventHandler(this.RefreshDb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(544, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Database";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 557);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refreshDbBtn);
            this.Controls.Add(this.listViewDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbLabel);
            this.Controls.Add(this.listViewAPI);
            this.Controls.Add(this.emailBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button emailBtn;
        private System.Windows.Forms.ListView listViewAPI;
        private System.Windows.Forms.Label dbLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewDB;
        private System.Windows.Forms.Button refreshDbBtn;
        private System.Windows.Forms.Label label2;
    }
}


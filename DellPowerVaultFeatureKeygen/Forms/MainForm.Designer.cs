namespace DellPowerVaultFeatureKeygen
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblFeatureEnableIdentifier = new System.Windows.Forms.Label();
            this.txtFeatureEnableIdentifier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(12, 109);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(223, 30);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.Generate);
            // 
            // cmbModel
            // 
            this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Items.AddRange(new object[] {
            "MD32XX"});
            this.cmbModel.Location = new System.Drawing.Point(12, 29);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(223, 21);
            this.cmbModel.TabIndex = 3;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(9, 13);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(36, 13);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "Model";
            // 
            // lblFeatureEnableIdentifier
            // 
            this.lblFeatureEnableIdentifier.AutoSize = true;
            this.lblFeatureEnableIdentifier.Location = new System.Drawing.Point(9, 59);
            this.lblFeatureEnableIdentifier.Name = "lblFeatureEnableIdentifier";
            this.lblFeatureEnableIdentifier.Size = new System.Drawing.Size(122, 13);
            this.lblFeatureEnableIdentifier.TabIndex = 5;
            this.lblFeatureEnableIdentifier.Text = "Feature Enable Identifier";
            // 
            // txtFeatureEnableIdentifier
            // 
            this.txtFeatureEnableIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeatureEnableIdentifier.Location = new System.Drawing.Point(12, 75);
            this.txtFeatureEnableIdentifier.Name = "txtFeatureEnableIdentifier";
            this.txtFeatureEnableIdentifier.Size = new System.Drawing.Size(223, 20);
            this.txtFeatureEnableIdentifier.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 151);
            this.Controls.Add(this.txtFeatureEnableIdentifier);
            this.Controls.Add(this.lblFeatureEnableIdentifier);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Dell PowerVault Feature Key Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblFeatureEnableIdentifier;
        private System.Windows.Forms.TextBox txtFeatureEnableIdentifier;
    }
}


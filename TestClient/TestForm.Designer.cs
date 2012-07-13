namespace BBC.Practice.WCF.Routing.Test
{
    partial class TestForm
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
            this.ddlVersion = new System.Windows.Forms.ComboBox();
            this.btnRoot = new System.Windows.Forms.Button();
            this.btnRouting = new System.Windows.Forms.Button();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ddlVersion
            // 
            this.ddlVersion.FormattingEnabled = true;
            this.ddlVersion.Items.AddRange(new object[] {
            "Version 1",
            "Version 2"});
            this.ddlVersion.Location = new System.Drawing.Point(12, 12);
            this.ddlVersion.Name = "ddlVersion";
            this.ddlVersion.Size = new System.Drawing.Size(121, 21);
            this.ddlVersion.TabIndex = 0;
            // 
            // btnRoot
            // 
            this.btnRoot.Location = new System.Drawing.Point(139, 10);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(113, 23);
            this.btnRoot.TabIndex = 1;
            this.btnRoot.Text = "Root Service";
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // btnRouting
            // 
            this.btnRouting.Location = new System.Drawing.Point(258, 10);
            this.btnRouting.Name = "btnRouting";
            this.btnRouting.Size = new System.Drawing.Size(113, 23);
            this.btnRouting.TabIndex = 2;
            this.btnRouting.Text = "Routing Service";
            this.btnRouting.UseVisualStyleBackColor = true;
            this.btnRouting.Click += new System.EventHandler(this.btnRouting_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(12, 133);
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ReadOnly = true;
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequest.Size = new System.Drawing.Size(354, 165);
            this.txtRequest.TabIndex = 3;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(17, 325);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(354, 165);
            this.txtResponse.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Response";
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Location = new System.Drawing.Point(12, 77);
            this.txtEndpoint.Multiline = true;
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.ReadOnly = true;
            this.txtEndpoint.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtEndpoint.Size = new System.Drawing.Size(359, 31);
            this.txtEndpoint.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Endpoint";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndpoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.btnRouting);
            this.Controls.Add(this.btnRoot);
            this.Controls.Add(this.ddlVersion);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlVersion;
        private System.Windows.Forms.Button btnRoot;
        private System.Windows.Forms.Button btnRouting;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Label label3;
    }
}
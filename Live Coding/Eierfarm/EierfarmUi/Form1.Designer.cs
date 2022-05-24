namespace EierfarmUi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxTiere = new System.Windows.Forms.ComboBox();
            this.btnNeuesHuhn = new System.Windows.Forms.Button();
            this.btnNeueEnte = new System.Windows.Forms.Button();
            this.btnEiLegen = new System.Windows.Forms.Button();
            this.btnFuettern = new System.Windows.Forms.Button();
            this.pgdTier = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // cbxTiere
            // 
            this.cbxTiere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTiere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTiere.FormattingEnabled = true;
            this.cbxTiere.Location = new System.Drawing.Point(12, 17);
            this.cbxTiere.Name = "cbxTiere";
            this.cbxTiere.Size = new System.Drawing.Size(189, 23);
            this.cbxTiere.TabIndex = 0;
            this.cbxTiere.SelectedIndexChanged += new System.EventHandler(this.cbxTiere_SelectedIndexChanged);
            // 
            // btnNeuesHuhn
            // 
            this.btnNeuesHuhn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuesHuhn.Location = new System.Drawing.Point(207, 16);
            this.btnNeuesHuhn.Name = "btnNeuesHuhn";
            this.btnNeuesHuhn.Size = new System.Drawing.Size(75, 23);
            this.btnNeuesHuhn.TabIndex = 1;
            this.btnNeuesHuhn.Text = "Huhn";
            this.btnNeuesHuhn.UseVisualStyleBackColor = true;
            this.btnNeuesHuhn.Click += new System.EventHandler(this.btnNeuesHuhn_Click);
            // 
            // btnNeueEnte
            // 
            this.btnNeueEnte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeueEnte.Location = new System.Drawing.Point(207, 45);
            this.btnNeueEnte.Name = "btnNeueEnte";
            this.btnNeueEnte.Size = new System.Drawing.Size(75, 23);
            this.btnNeueEnte.TabIndex = 2;
            this.btnNeueEnte.Text = "Ente";
            this.btnNeueEnte.UseVisualStyleBackColor = true;
            this.btnNeueEnte.Click += new System.EventHandler(this.btnNeueEnte_Click);
            // 
            // btnEiLegen
            // 
            this.btnEiLegen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEiLegen.Location = new System.Drawing.Point(207, 210);
            this.btnEiLegen.Name = "btnEiLegen";
            this.btnEiLegen.Size = new System.Drawing.Size(75, 23);
            this.btnEiLegen.TabIndex = 3;
            this.btnEiLegen.Text = "Ei legen";
            this.btnEiLegen.UseVisualStyleBackColor = true;
            this.btnEiLegen.Click += new System.EventHandler(this.btnEiLegen_Click);
            // 
            // btnFuettern
            // 
            this.btnFuettern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFuettern.Location = new System.Drawing.Point(207, 181);
            this.btnFuettern.Name = "btnFuettern";
            this.btnFuettern.Size = new System.Drawing.Size(75, 23);
            this.btnFuettern.TabIndex = 4;
            this.btnFuettern.Text = "Füttern";
            this.btnFuettern.UseVisualStyleBackColor = true;
            this.btnFuettern.Click += new System.EventHandler(this.btnFuettern_Click);
            // 
            // pgdTier
            // 
            this.pgdTier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgdTier.HelpVisible = false;
            this.pgdTier.Location = new System.Drawing.Point(12, 58);
            this.pgdTier.Name = "pgdTier";
            this.pgdTier.Size = new System.Drawing.Size(189, 175);
            this.pgdTier.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 255);
            this.Controls.Add(this.pgdTier);
            this.Controls.Add(this.btnFuettern);
            this.Controls.Add(this.btnEiLegen);
            this.Controls.Add(this.btnNeueEnte);
            this.Controls.Add(this.btnNeuesHuhn);
            this.Controls.Add(this.cbxTiere);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbxTiere;
        private Button btnNeuesHuhn;
        private Button btnNeueEnte;
        private Button btnEiLegen;
        private Button btnFuettern;
        private PropertyGrid pgdTier;
    }
}
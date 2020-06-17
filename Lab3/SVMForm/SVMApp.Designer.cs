namespace SVMForm
{
    partial class SVMApp
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
            this.LoadDataSetButton = new System.Windows.Forms.Button();
            this.UseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadDataSetButton
            // 
            this.LoadDataSetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadDataSetButton.Location = new System.Drawing.Point(119, 102);
            this.LoadDataSetButton.Name = "LoadDataSetButton";
            this.LoadDataSetButton.Size = new System.Drawing.Size(231, 31);
            this.LoadDataSetButton.TabIndex = 11;
            this.LoadDataSetButton.Text = "Загрузить выборку";
            this.LoadDataSetButton.UseVisualStyleBackColor = true;
            this.LoadDataSetButton.Click += new System.EventHandler(this.LoadDataSetButton_Click);
            // 
            // UseBtn
            // 
            this.UseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UseBtn.Location = new System.Drawing.Point(119, 102);
            this.UseBtn.Name = "UseBtn";
            this.UseBtn.Size = new System.Drawing.Size(231, 31);
            this.UseBtn.TabIndex = 14;
            this.UseBtn.Text = "Определить изображение";
            this.UseBtn.UseVisualStyleBackColor = true;
            this.UseBtn.Visible = false;
            this.UseBtn.Click += new System.EventHandler(this.UseBtn_Click);
            // 
            // SVMApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 231);
            this.Controls.Add(this.LoadDataSetButton);
            this.Controls.Add(this.UseBtn);
            this.Name = "SVMApp";
            this.Text = "Л. 3";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LoadDataSetButton;
        private System.Windows.Forms.Button UseBtn;
    }
}
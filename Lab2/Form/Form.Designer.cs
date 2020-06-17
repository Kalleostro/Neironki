namespace NeuroL2App
{
    partial class Form
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
            this.HidenLayersTextBox = new System.Windows.Forms.TextBox();
            this.CreateTopologyButton = new System.Windows.Forms.Button();
            this.LearningRateTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LearnNEpoch = new System.Windows.Forms.Button();
            this.CountOfEpochTextBox = new System.Windows.Forms.TextBox();
            this.LoadDataSetButton = new System.Windows.Forms.Button();
            this.UseNeuronSystemButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HidenLayersTextBox
            // 
            this.HidenLayersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HidenLayersTextBox.Location = new System.Drawing.Point(12, 27);
            this.HidenLayersTextBox.Name = "HidenLayersTextBox";
            this.HidenLayersTextBox.Size = new System.Drawing.Size(206, 22);
            this.HidenLayersTextBox.TabIndex = 3;
            this.HidenLayersTextBox.Text = "10";
            this.HidenLayersTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CreateTopologyButton
            // 
            this.CreateTopologyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTopologyButton.Location = new System.Drawing.Point(12, 99);
            this.CreateTopologyButton.Name = "CreateTopologyButton";
            this.CreateTopologyButton.Size = new System.Drawing.Size(206, 31);
            this.CreateTopologyButton.TabIndex = 6;
            this.CreateTopologyButton.Text = "Создать";
            this.CreateTopologyButton.UseVisualStyleBackColor = true;
            this.CreateTopologyButton.Click += new System.EventHandler(this.CreateTopologyButton_Click);
            // 
            // LearningRateTextBox
            // 
            this.LearningRateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LearningRateTextBox.Location = new System.Drawing.Point(12, 71);
            this.LearningRateTextBox.Name = "LearningRateTextBox";
            this.LearningRateTextBox.Size = new System.Drawing.Size(206, 22);
            this.LearningRateTextBox.TabIndex = 10;
            this.LearningRateTextBox.Text = "0,1";
            this.LearningRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(48, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Скорость обучения";
            // 
            // LearnNEpoch
            // 
            this.LearnNEpoch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LearnNEpoch.Location = new System.Drawing.Point(237, 56);
            this.LearnNEpoch.Name = "LearnNEpoch";
            this.LearnNEpoch.Size = new System.Drawing.Size(264, 37);
            this.LearnNEpoch.TabIndex = 12;
            this.LearnNEpoch.Text = "Обучить";
            this.LearnNEpoch.UseVisualStyleBackColor = true;
            this.LearnNEpoch.Click += new System.EventHandler(this.LearnNEpoch_Click);
            // 
            // CountOfEpochTextBox
            // 
            this.CountOfEpochTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountOfEpochTextBox.Location = new System.Drawing.Point(237, 24);
            this.CountOfEpochTextBox.Name = "CountOfEpochTextBox";
            this.CountOfEpochTextBox.Size = new System.Drawing.Size(264, 26);
            this.CountOfEpochTextBox.TabIndex = 11;
            this.CountOfEpochTextBox.Text = "1000";
            this.CountOfEpochTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoadDataSetButton
            // 
            this.LoadDataSetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadDataSetButton.Location = new System.Drawing.Point(12, 134);
            this.LoadDataSetButton.Name = "LoadDataSetButton";
            this.LoadDataSetButton.Size = new System.Drawing.Size(206, 31);
            this.LoadDataSetButton.TabIndex = 11;
            this.LoadDataSetButton.Text = "Загрузить выборку";
            this.LoadDataSetButton.UseVisualStyleBackColor = true;
            this.LoadDataSetButton.Click += new System.EventHandler(this.LoadDataSetButton_Click);
            // 
            // UseNeuronSystemButton
            // 
            this.UseNeuronSystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UseNeuronSystemButton.Location = new System.Drawing.Point(237, 100);
            this.UseNeuronSystemButton.Name = "UseNeuronSystemButton";
            this.UseNeuronSystemButton.Size = new System.Drawing.Size(264, 65);
            this.UseNeuronSystemButton.TabIndex = 14;
            this.UseNeuronSystemButton.Text = "Определить изображение";
            this.UseNeuronSystemButton.UseVisualStyleBackColor = true;
            this.UseNeuronSystemButton.Click += new System.EventHandler(this.UseNeuronSystemButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Количество скрытых нейронов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(292, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Количество обучений";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LearnNEpoch);
            this.Controls.Add(this.LearningRateTextBox);
            this.Controls.Add(this.CountOfEpochTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CreateTopologyButton);
            this.Controls.Add(this.HidenLayersTextBox);
            this.Controls.Add(this.LoadDataSetButton);
            this.Controls.Add(this.UseNeuronSystemButton);
            this.Name = "Form";
            this.Text = "Лаб. 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox HidenLayersTextBox;
        private System.Windows.Forms.Button CreateTopologyButton;
        private System.Windows.Forms.TextBox LearningRateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CountOfEpochTextBox;
        private System.Windows.Forms.Button LearnNEpoch;
        private System.Windows.Forms.Button LoadDataSetButton;
        private System.Windows.Forms.Button UseNeuronSystemButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}
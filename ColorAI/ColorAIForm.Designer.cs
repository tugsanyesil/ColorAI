namespace ColorAI
{
    partial class ColorAIForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TrainButton = new System.Windows.Forms.Button();
            this.QButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AddSampleButton = new System.Windows.Forms.Button();
            this.DeleteSampleButton = new System.Windows.Forms.Button();
            this.TrainWithSamplesButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.TrainTimer = new System.Windows.Forms.Timer(this.components);
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.SaveBrainButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(274, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 2;
            // 
            // TrainButton
            // 
            this.TrainButton.Location = new System.Drawing.Point(380, 12);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(120, 23);
            this.TrainButton.TabIndex = 3;
            this.TrainButton.Text = "Train";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.Train_Click);
            // 
            // QButton
            // 
            this.QButton.Location = new System.Drawing.Point(380, 68);
            this.QButton.Name = "QButton";
            this.QButton.Size = new System.Drawing.Size(120, 23);
            this.QButton.TabIndex = 7;
            this.QButton.Text = "What is That?";
            this.QButton.UseVisualStyleBackColor = true;
            this.QButton.Click += new System.EventHandler(this.Q_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(380, 97);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(758, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(400, 518);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(12, 274);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // AddSampleButton
            // 
            this.AddSampleButton.Location = new System.Drawing.Point(506, 12);
            this.AddSampleButton.Name = "AddSampleButton";
            this.AddSampleButton.Size = new System.Drawing.Size(120, 23);
            this.AddSampleButton.TabIndex = 11;
            this.AddSampleButton.Text = "Add Sample";
            this.AddSampleButton.UseVisualStyleBackColor = true;
            this.AddSampleButton.Click += new System.EventHandler(this.AddSample_Click);
            // 
            // DeleteSampleButton
            // 
            this.DeleteSampleButton.Location = new System.Drawing.Point(506, 41);
            this.DeleteSampleButton.Name = "DeleteSampleButton";
            this.DeleteSampleButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteSampleButton.TabIndex = 12;
            this.DeleteSampleButton.Text = "Delete Sample";
            this.DeleteSampleButton.UseVisualStyleBackColor = true;
            this.DeleteSampleButton.Click += new System.EventHandler(this.DeleteSample_Click);
            // 
            // TrainWithSamplesButton
            // 
            this.TrainWithSamplesButton.Location = new System.Drawing.Point(380, 41);
            this.TrainWithSamplesButton.Name = "TrainWithSamplesButton";
            this.TrainWithSamplesButton.Size = new System.Drawing.Size(120, 23);
            this.TrainWithSamplesButton.TabIndex = 13;
            this.TrainWithSamplesButton.Text = "Train with Samples";
            this.TrainWithSamplesButton.UseVisualStyleBackColor = true;
            this.TrainWithSamplesButton.Click += new System.EventHandler(this.TrainWithSamples_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(632, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 82);
            this.listBox1.TabIndex = 14;
            // 
            // TrainTimer
            // 
            this.TrainTimer.Interval = 1;
            this.TrainTimer.Tick += new System.EventHandler(this.TrainTimer_Tick);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(506, 68);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save Samples";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(506, 97);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(120, 23);
            this.LoadButton.TabIndex = 16;
            this.LoadButton.Text = "Load Samples";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(702, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sample Set :";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(274, 274);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.Color = System.Drawing.Color.Black;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(478, 258);
            this.chart1.TabIndex = 19;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 20;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(277, 124);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 100);
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // SaveBrainButton
            // 
            this.SaveBrainButton.Location = new System.Drawing.Point(506, 126);
            this.SaveBrainButton.Name = "SaveBrainButton";
            this.SaveBrainButton.Size = new System.Drawing.Size(120, 23);
            this.SaveBrainButton.TabIndex = 22;
            this.SaveBrainButton.Text = "Save Brain";
            this.SaveBrainButton.UseVisualStyleBackColor = true;
            this.SaveBrainButton.Click += new System.EventHandler(this.SaveBrainButton_Click);
            // 
            // AIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 544);
            this.Controls.Add(this.SaveBrainButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.TrainWithSamplesButton);
            this.Controls.Add(this.DeleteSampleButton);
            this.Controls.Add(this.AddSampleButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.QButton);
            this.Controls.Add(this.TrainButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AIForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button TrainButton;
        private System.Windows.Forms.Button QButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button AddSampleButton;
        private System.Windows.Forms.Button DeleteSampleButton;
        private System.Windows.Forms.Button TrainWithSamplesButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer TrainTimer;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button SaveBrainButton;
    }
}


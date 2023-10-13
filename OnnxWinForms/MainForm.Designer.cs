namespace OnnxWinForms
{
    partial class MainForm
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
            pictureBoxImage = new PictureBox();
            comboBoxModel = new ComboBox();
            label1 = new Label();
            textBoxDirectory = new TextBox();
            textBoxOutput = new TextBox();
            listBoxDirectory = new ListBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(426, 2);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(640, 640);
            pictureBoxImage.TabIndex = 0;
            pictureBoxImage.TabStop = false;
            // 
            // comboBoxModel
            // 
            comboBoxModel.FormattingEnabled = true;
            comboBoxModel.Location = new Point(60, 13);
            comboBoxModel.Name = "comboBoxModel";
            comboBoxModel.Size = new Size(352, 28);
            comboBoxModel.TabIndex = 3;
            comboBoxModel.SelectionChangeCommitted += ComboBoxModelItemChange;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 16);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 4;
            label1.Text = "模型：";
            // 
            // textBoxDirectory
            // 
            textBoxDirectory.Location = new Point(60, 47);
            textBoxDirectory.Name = "textBoxDirectory";
            textBoxDirectory.Size = new Size(352, 27);
            textBoxDirectory.TabIndex = 7;
            textBoxDirectory.MouseClick += TextBoxDirectoryClick;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(1079, 2);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(200, 640);
            textBoxOutput.TabIndex = 8;
            // 
            // listBoxDirectory
            // 
            listBoxDirectory.FormattingEnabled = true;
            listBoxDirectory.ItemHeight = 20;
            listBoxDirectory.Location = new Point(20, 88);
            listBoxDirectory.Name = "listBoxDirectory";
            listBoxDirectory.Size = new Size(392, 544);
            listBoxDirectory.TabIndex = 9;
            listBoxDirectory.MouseClick += ListBoxDirectoryClick;
            listBoxDirectory.SelectedIndexChanged += ListBoxDirectoryChange;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 54);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 10;
            label2.Text = "目录：";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 645);
            Controls.Add(label2);
            Controls.Add(listBoxDirectory);
            Controls.Add(pictureBoxImage);
            Controls.Add(textBoxOutput);
            Controls.Add(textBoxDirectory);
            Controls.Add(label1);
            Controls.Add(comboBoxModel);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxImage;
        private ComboBox comboBoxModel;
        private Label label1;
        private TextBox textBoxDirectory;
        private ListBox listBoxDirectory;
        private Label label2;
        private TextBox textBoxOutput;
    }
}
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
            buttonInfer = new Button();
            textBoxDirectory = new TextBox();
            panel1 = new Panel();
            listBoxDirectory = new ListBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(1, 0);
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
            comboBoxModel.Size = new Size(215, 28);
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
            // buttonInfer
            // 
            buttonInfer.Location = new Point(293, 12);
            buttonInfer.Name = "buttonInfer";
            buttonInfer.Size = new Size(119, 28);
            buttonInfer.TabIndex = 5;
            buttonInfer.Text = "检测(Enter)";
            buttonInfer.UseVisualStyleBackColor = true;
            buttonInfer.Click += ButtonInferClick;
            // 
            // textBoxDirectory
            // 
            textBoxDirectory.Location = new Point(60, 47);
            textBoxDirectory.Name = "textBoxDirectory";
            textBoxDirectory.Size = new Size(352, 27);
            textBoxDirectory.TabIndex = 7;
            textBoxDirectory.Click += TextBoxDirectoryClick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(pictureBoxImage);
            panel1.Location = new Point(433, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(642, 642);
            panel1.TabIndex = 8;
            // 
            // listBoxDirectory
            // 
            listBoxDirectory.FormattingEnabled = true;
            listBoxDirectory.ItemHeight = 20;
            listBoxDirectory.Location = new Point(20, 88);
            listBoxDirectory.Name = "listBoxDirectory";
            listBoxDirectory.Size = new Size(392, 544);
            listBoxDirectory.TabIndex = 9;
            listBoxDirectory.Click += ListBoxDirectoryClick;
            listBoxDirectory.KeyDown += ListBoxDirectoryKeyDown;
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
            AcceptButton = buttonInfer;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 645);
            Controls.Add(label2);
            Controls.Add(listBoxDirectory);
            Controls.Add(panel1);
            Controls.Add(textBoxDirectory);
            Controls.Add(buttonInfer);
            Controls.Add(label1);
            Controls.Add(comboBoxModel);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxImage;
        private ComboBox comboBoxModel;
        private Label label1;
        private Button buttonInfer;
        private TextBox textBoxDirectory;
        private Panel panel1;
        private ListBox listBoxDirectory;
        private Label label2;
    }
}
using Common.Helper;
using OnnxDemo;
using OnnxDemo.Detection;
using OnnxDemo.Extensions;
using OnnxDemo.Utils;

namespace OnnxWinForms
{
    public partial class MainForm : Form

    {
        private readonly Dictionary<string, YamlConfig> configs;
        private IOnnxModel model;
        private Bitmap bitmap;
        private static readonly string[] imageExts = { ".jpg", ".png", ".bmp" };

        public MainForm()
        {
            try
            {
                YamlParse yamlParse = new(Properties.Resources.OnnxDemoYaml);
                configs = YamlConfig.ToDict(yamlParse.ParseList<YamlConfig>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

            InitializeComponent();
            string[] configNames = configs.Keys.ToArray();
            comboBoxModel.Items.AddRange(configNames);
            comboBoxModel.SelectedIndex = 0;
            ChangeModel();
        }

        private void ButtonInferClick(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                pictureBoxImage.Image = model.Predict<Bitmap>((Bitmap)bitmap.Clone());
            }
        }


        private void TextBoxDirectoryClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                Description = "选择匹配目录"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDirectory.Text = folderBrowserDialog.SelectedPath;
                UpdateListBox(textBoxDirectory.Text);
            }
        }
        private void UpdateListBox(string dirPath)
        {
            listBoxDirectory.Items.Clear();
            FileInfo[] files = new DirectoryInfo(dirPath).GetFiles();
            foreach (FileInfo file in files.Where(fileInfo => imageExts.Contains(fileInfo.Extension)))
            {
                listBoxDirectory.Items.Add(file.Name);
            }
            listBoxDirectory.Update();
        }

        private void ListBoxDirectoryClick(object sender, EventArgs e)
        {
            ShowImage();
        }


        private void ShowImage()
        {
            string path = textBoxDirectory.Text + "\\" + listBoxDirectory.SelectedItem.ToString();
            //DefaultFileLogHelper.Info(path);
            if (File.Exists(path))
            {
                bitmap = (Bitmap)Image.FromFile(path);
                bitmap = bitmap.Resize(640, 640);
                pictureBoxImage.Image = bitmap;
            }
        }
        private void ComboBoxModelItemChange(object sender, EventArgs e)
        {
            ChangeModel();
        }

        private void ChangeModel()
        {
            string modelName = comboBoxModel.Items[comboBoxModel.SelectedIndex].ToString();
            DefaultFileLogHelper.Info(modelName);

            YamlConfig CurrentConfig = configs[modelName];
            model = new YoloOnnxModel(onnxPath: CurrentConfig.OnnxPath,
                                  labels: CurrentConfig.Labels)
            {
                IOUThreshold = CurrentConfig.IOUThreshold,
                ConfThreshold = CurrentConfig.ConfThreshold,
            };
        }

        private void ListBoxDirectoryKeyDown(object sender, KeyEventArgs e)
        {
            ShowImage();
        }
    }
}
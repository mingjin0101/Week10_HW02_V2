namespace MyNotepadLab001
{
    public partial class Form1 : Form
    {
        private string currentFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Open file clicked"); // method overloading
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                richTextBox.Text = File.ReadAllText(currentFilePath);
            }

        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Save file clicked");
            // Form1 屬性：private string currentFilePath; // 如果有Open File, 則應該有路徑被紀錄！

            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            //
            File.WriteAllText(currentFilePath, richTextBox.Text);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Exit clicked");
            DialogResult result = MessageBox.Show("是否要結束程式？", "結束程式", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("XXX", "Title", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
             
            MessageBox.Show("檔案讀取失敗：" , "錯誤", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); 
            

        }
    }
}

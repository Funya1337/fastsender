using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadCaptchaImage();
        }
        int number = 0;
        private void loadCaptchaImage()
        {
            Random r1 = new Random();
            number = r1.Next(100, 1000);
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(number.ToString(), font, Brushes.Green, new Point(0, 0));
            pictureBox1.Image = image;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadCaptchaImage();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == number.ToString())
            {
                string name = textBox3.Text;
                string message = richTextBox1.Text;
                string email = textBox2.Text;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string emailTrim = email.Trim();

                if (IsValidEmail(emailTrim))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1/project/server.php?name={name}&message={message}&email={email}&date={date}");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    MessageBox.Show("Mail sucessfully send!");
                }
                else
                {
                    MessageBox.Show("Email is not valid.", "Validation Result");
                }
            }
            else
            {
                MessageBox.Show("DOes not Match Text with Captcha");
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PDF_Community;

namespace BookLibrary
{
    public partial class Form1 : Form
    {
        IEnumerable<string> bookCollection;

        private Profile User;
        private Book BookToAdd;
        public Form1()
        {
            InitializeComponent();
            scroller.Top = Shop.Top;
            scroller.Height = Shop.Height;
        }
        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HideButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                circularPictureBox1.Height = 80;
                circularPictureBox1.Width = 90;
                circularPictureBox1.Left = 333;
                label3.Left = 95;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                circularPictureBox1.Height = 120;
                circularPictureBox1.Width = 120;
                circularPictureBox1.Left = 600;
                label3.Left = 200;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 2;
        }
        private void Login_Click(object sender, EventArgs e)
        {
            User = new Profile();
            string folderName = System.IO.Directory.GetCurrentDirectory();
            string subFolder1 = LoginName.Text + LoginPassword.Text;
            string pathString = System.IO.Path.Combine(folderName, subFolder1);
            string fileName = LoginName.Text + ".txt";
            string newPathString = System.IO.Path.Combine(pathString, fileName);
            if (System.IO.Directory.Exists(pathString))
            {
                using (StreamReader reader = new StreamReader(newPathString))
                {
                    User.ProfileName = reader.ReadLine();
                    User.Password = reader.ReadLine();
                    User.UserName = reader.ReadLine();
                }
                MyApp.SelectedIndex = 3;
                LoginName.Clear();
                LoginPassword.Clear();
            }
            else
            {
                DialogResult result = MessageBox.Show("This Account Does Not Exist, Do You Wish To Signup?", "Login error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    MyApp.SelectedIndex = 2;
                }
                LoginName.Clear();
                LoginPassword.Clear();
            }
        }
        private void Signup_Click(object sender, EventArgs e)
        {
            if (SignupPassword.Text == RepeatPassword.Text)
            {
                User = new Profile(SignupName.Text, SignupUsername.Text, SignupPassword.Text, SelectProfilePicture.BackgroundImage);
                string folderName = System.IO.Directory.GetCurrentDirectory();
                string subFolder1 = User.ProfileName + User.Password;
                string push = subFolder1 + @"\Books";
                string pathString = System.IO.Path.Combine(folderName, push);
                string path = System.IO.Path.Combine(folderName, subFolder1);
                if (System.IO.Directory.Exists(pathString))
                {
                    MessageBox.Show("Account already exists, do you wish to login?", "signup error");
                }
                else
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    string fileName = User.ProfileName + ".txt";
                    string newPathString = System.IO.Path.Combine(path, fileName);
                    using (StreamWriter writer = new StreamWriter(newPathString))
                    {
                        writer.WriteLine(User.ProfileName);
                        writer.WriteLine(User.Password);
                        writer.WriteLine(User.UserName);
                    }
                    MyApp.SelectedIndex = 3;
                    SignupName.Clear();
                    SignupUsername.Clear();
                    SignupPassword.Clear();
                    SelectProfilePicture.BackgroundImage = null;
                }
            }
            else
            {
                MessageBox.Show("Unsure Password", "signup error");
                SignupPassword.Clear();
                RepeatPassword.Clear();
            }
        }
        private void ReadBook(object sender, EventArgs e)
        {
            string folderName = System.IO.Directory.GetCurrentDirectory();
            string subFolder1 = User.ProfileName + User.Password;
            string push = subFolder1 + @"\Books";
            string path = System.IO.Path.Combine(folderName, push);
            bookCollection = System.IO.Directory.EnumerateFiles(path);
            foreach (string item in bookCollection)
            {
                string Filepath = System.IO.Path.Combine(path, item);
                axAcroPDF1.src = Filepath;
            }
            MyApp.SelectedIndex = 5;
        }
        private void DeleteBook(object sender, EventArgs e)
        {
            string folderName = System.IO.Directory.GetCurrentDirectory();
            string subFolder1 = User.ProfileName + User.Password;
            string push = subFolder1 + @"\Books";
            string path = System.IO.Path.Combine(folderName, push);
            bookCollection = System.IO.Directory.EnumerateFiles(path);
            foreach (string item in bookCollection)
            {
                File.Delete(item);
            }
            foreach (Panel items in panel4.Controls)
            {
                panel4.Controls.Remove(items);
            }
        }
        private void Shop_MouseHover(object sender, EventArgs e)
        {
            scroller.Top = Shop.Top;
            scroller.Height = Shop.Height;
        }
        private void Library_MouseHover(object sender, EventArgs e)
        {
            scroller.Top = Library.Top;
            scroller.Height = Library.Height;
        }
        private void Logout_MouseHover(object sender, EventArgs e)
        {
            scroller.Top = Logout.Top;
            scroller.Height = Logout.Height;
        }
        private void ExitApp_MouseHover(object sender, EventArgs e)
        {
            scroller.Top = ExitApp.Top;
            scroller.Height = ExitApp.Height;
        }
        private void Shop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Appologies dear, This Feature Is Not Yet Available");
        }
        private void Library_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 4;
            string folderName = System.IO.Directory.GetCurrentDirectory();
            string subFolder1 = User.ProfileName + User.Password;
            string push = subFolder1 + @"\Books";
            string path = System.IO.Path.Combine(folderName, push);
            IEnumerable<string> bookCollection = System.IO.Directory.EnumerateFiles(path);
            if (bookCollection.Count() == 0)
            {
                return;
            }
            else
            {
                foreach (string item in bookCollection)
                {
                    BookToAdd = new Book();
                    int currentPosition = BookToAdd.TheBook.Height;
                    BookToAdd.BookName = item.Remove(0, path.Length);
                    BookToAdd.NameLabel.Text = BookToAdd.BookName;
                    BookToAdd.BookImage.BackgroundImage = BookImage.BackgroundImage;
                    if (panel4.Controls.Count == 0)
                    {
                        BookToAdd.TheBook.Top += 0;
                    }
                    else
                    {
                        BookToAdd.TheBook.Top += currentPosition + 30;
                    }
                    panel4.Controls.Add(BookToAdd.TheBook);
                    BookToAdd.Read.Click += new System.EventHandler(ReadBook);
                    BookToAdd.Delete.Click += new System.EventHandler(DeleteBook);
                }
            }
        }
        private void Logout_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 0;
            User = null;
        }
        private void ExitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HomePge_Click(object sender, EventArgs e)
        {
            ViewProfilePic.Image = User.ProfilePicture;
            NameLabel.Text = User.ProfileName;
            UsernameLabel.Text = User.UserName;
        }
        private void GuestExit_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 0;
        }
        private void GuestSignup_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 2;
        }
        private void GuestReadBook_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PDF Files(*.pdf)|*.pdf";
            DialogResult result = open.ShowDialog();
            if (result == DialogResult.OK)
            {
                axAcroPDF2.src = open.FileName;
            }
        }
        private void BackToLibrary_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 4;
        }
        private void LibraryToHome_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 3;
        }
        private void SelectProfilePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg)|*.jpg|(*.png)|*.png";
            DialogResult result = open.ShowDialog();
            if (result == DialogResult.OK)
            {
                SelectProfilePicture.BackgroundImage = Image.FromFile(open.FileName);
            }
        }
        private void SignupBtn_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 2;
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 1;
        }
        private void GuestBtn_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 6;
        }
        private void AddNewBook_Click(object sender, EventArgs e)
        {
            BookToAdd = new Book();
            string folderName = System.IO.Directory.GetCurrentDirectory();
            string subFolder1 = User.ProfileName + User.Password;
            string push = subFolder1 + @"\Books";
            string path = System.IO.Path.Combine(folderName, push);
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files(*.pdf)|*.pdf";
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string Filepath = System.IO.Path.Combine(path, openFile.SafeFileName);
                if (File.Exists(Filepath))
                {
                    MessageBox.Show("This Book Already Exist In Your Library");
                }
                else
                {
                    File.Copy(openFile.FileName, Filepath);
                    BookToAdd = new Book();
                    int currentPosition = BookToAdd.TheBook.Height;
                    BookToAdd.BookName = openFile.SafeFileName;
                    BookToAdd.NameLabel.Text = BookToAdd.BookName;
                    BookToAdd.BookImage.BackgroundImage = BookImage.BackgroundImage;
                    if (panel4.Controls.Count == 0)
                    {
                        BookToAdd.TheBook.Top += 0;
                    }
                    else
                    {
                        BookToAdd.TheBook.Top += currentPosition + 30;
                    }
                    panel4.Controls.Add(BookToAdd.TheBook);
                    BookToAdd.Read.Click += new System.EventHandler(ReadBook);
                    BookToAdd.Delete.Click += new System.EventHandler(DeleteBook);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 0;
        }
        private void SignupToLogin_Click(object sender, EventArgs e)
        {
            MyApp.SelectedIndex = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Community
{
    class Book
    { 
        public string BookName { get; set; }
        public PictureBox BookImage = new PictureBox();
        public Panel TheBook = new Panel();
        public Label NameLabel = new Label();
        public Button Delete = new Button();
        public Button Read = new Button();
        public Book()
        {
            BookImage.BackgroundImageLayout = ImageLayout.Stretch;
            TheBook.Top = 5;
            TheBook.Width = 545;
            TheBook.Height = 100;
            TheBook.BackColor = Color.DarkSeaGreen;
            NameLabel.ForeColor = Color.White;
            TheBook.Left = 7;
            TheBook.BorderStyle = BorderStyle.FixedSingle;
            BookImage.Width = 75;
            BookImage.Height = 90;
            BookImage.Top = 7;
            TheBook.Controls.Add(BookImage);
            NameLabel.AutoSize = true;
            NameLabel.Top = 50;
            NameLabel.Left = 80;
            TheBook.Controls.Add(NameLabel);
            Delete.Top = 7;
            Delete.Left = 440;
            Delete.Height = 30;
            Delete.Width = 100;
            Delete.BackColor = Color.Red;
            Delete.Text = "Delete";
            TheBook.Controls.Add(Delete);
            Read.Top = 67;
            Read.Left = 440;
            Read.Height = 30;
            Read.Width = 100;
            Read.BackColor = Color.Green;
            Read.Text = "Read";
            TheBook.Controls.Add(Read);
        }
    }
}

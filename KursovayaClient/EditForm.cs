using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovayaCSharp
{
    public partial class EditForm : Form
    {
        public string EditedText { get; private set; }

        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(string title) : this()
        {
            WhatChangeLabel.Text = title;
            WhatChangeLabel.Location = new Point((this.Size.Width - WhatChangeLabel.Size.Width)/2, WhatChangeLabel.Location.Y);
        }

        public EditForm(string title, string text) : this()
        {
            WhatChangeLabel.Text = title;
            WhatChangeLabel.Location = new Point((this.Size.Width - WhatChangeLabel.Size.Width) / 2, WhatChangeLabel.Location.Y);
            TextBox.Text = text;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon_colored;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            EditedText = TextBox.Text;

            DialogResult = DialogResult.OK;
            Text = TextBox.Text;
        }
    }
}

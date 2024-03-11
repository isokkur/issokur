using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm1
{
    [DefaultEvent(nameof(TextChanged))]
    public partial class ClearTextBox : UserControl
    {
        public ClearTextBox()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        public new event EventHandler? TextChanged
        {
            add => txtValue.TextChanged += value;
            remove => txtValue.TextChanged -= value;
        }
        [Browsable(true)]
        public new string Text
        {
            get => txtValue.Text;
            set => txtValue.Text = value;
        }
        [Browsable(true)]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        private void btnClear_Click(object sender, EventArgs e) =>
    Text = "";
    }
}

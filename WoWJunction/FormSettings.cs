using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWJunction
{
    public partial class FormSettings : Form
    {
        private FormMain parent = null;

        public FormSettings(FormMain parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
    }
}

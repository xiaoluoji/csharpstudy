using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpstudy
{
    public partial class testform : Form
    {
        public testform(System.Windows.Forms.Form ParentForm)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(ParentForm.Location.X+200,ParentForm.Location.Y+200);
        }
    }
}

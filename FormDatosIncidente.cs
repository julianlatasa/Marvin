using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marvin
{
    public partial class FormDatosIncidente : Form
    {
        public FormDatosIncidente()
        {
            InitializeComponent();
        }

        public FormDatosIncidente(String NroIncdente)
        {
            InitializeComponent();
            webBrowser1.Url = new Uri(@"http://s001012/PropiedadesAsistencia/ConsultaAsistencia.aspx?NumAsistencia=" + NroIncdente);
        }
    }
}

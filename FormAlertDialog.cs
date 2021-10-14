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
    public partial class FormAlertDialog : Form
    {
        private String srvNumero;
        private Int32 srvTime;

        public FormAlertDialog()
        {
            InitializeComponent();
        }

        private void formAlertDialog_Load(object sender, EventArgs e)
        {
        }

        public void setServiceNumber(String srvNumero)
        {
            this.srvNumero = srvNumero;
            updateLabel();
        }

        public void setServiceTime(Int32 srvTime)
        {
            this.srvTime = srvTime;
            updateLabel();
        }

        private void updateLabel()
        {
            this.label1.Text = "Servicio " + srvNumero + " sin evaluar\ndesde hace " + getTextSrvTime();
        }

        private String getTextSrvTime()
        {
            Int32 horas = 0;
            Int32 minutos = 0;
            horas = (srvTime / 60);
            minutos = (horas > 0) ? (srvTime - (horas*60)) : srvTime;
            if (horas == 0)
                return minutos.ToString() + " minutos";
            else if (horas == 1)
                return horas.ToString() + " hora y " + minutos.ToString() + " minutos";
            else 
                return horas.ToString() + " horas y " + minutos.ToString() + " minutos";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.White)
            {
                label1.ForeColor = Color.Black;
                label1.BackColor = Color.White;
                //pictureBox1.Visible = true;
                //pictureBox2.Visible = true;
            }
            else
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.Red;
                //pictureBox1.Visible = false;
                //pictureBox2.Visible = false;
            }
        }

        private void formAlertDialog_VisibleChanged(object sender, EventArgs e)
        {
                        if (this.Visible)
                            timer1.Enabled = true;
                        else
                            timer1.Enabled = false;
        }
    }
}

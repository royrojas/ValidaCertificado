using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidaCertificado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog;  
            openFileDialog = new System.Windows.Forms.OpenFileDialog();

            openFileDialog.Title = "Buscar Certificado";

            openFileDialog.ShowDialog();

            this.txtCertificado.Text = openFileDialog.FileName;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(txtCertificado.Text, txtPin.Text);

                if (cert.NotAfter > DateTime.Now)

                {
                    //Console.WriteLine(cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - VÁLIDO");
                    lblFechaVencimiento.Text = cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - VÁLIDO";
                }
                else
                {
                    //Console.WriteLine(cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - INVÁLIDO");
                    lblFechaVencimiento.Text = cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - INVÁLIDO";
                }

                //Console.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

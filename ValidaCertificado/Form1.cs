using FirmaXadesNet;
using FirmaXadesNet.Signature.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

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

                //var data = cert.RawData;

                var stringOfCertWithPrivateKey = Convert.ToBase64String(cert.Export(X509ContentType.Cert));
                this.txtRawData.Text = stringOfCertWithPrivateKey;

                var certBytes = Convert.FromBase64String(this.txtRawData.Text);
                var cert2 = new X509Certificate2(certBytes);

                txtCripto1.Text = cert.Thumbprint;
                txtCripto2.Text = cert.FriendlyName;
                txtCripto3.Text = cert.SerialNumber;

                MessageBox.Show(cert2.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - " + cert2.Subject);

                //----
                //this.txtRawData.Text = System.Text.Encoding.UTF8.GetString(cert.RawData);
                //byte[] bytes = Encoding.ASCII.GetBytes(this.txtRawData.Text);
                //X509Certificate2 cert2 = new X509Certificate2(bytes);
                //----





                string prueba = "";


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

        private void btnObtienePin_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert;
                for (int i = 0; i < 10000; i++)
                {
                    string testPin = i.ToString().PadLeft(4, '0');
                    lblPin.Text = testPin;
                    try
                    {
                        cert = new X509Certificate2(txtCertificado.Text, testPin);
                        txtPin.Text = i.ToString().PadLeft(4, '0');
                        btnValidar_Click(sender,e);
                        Application.DoEvents();
                        MessageBox.Show("Pin: " + testPin);
                        break;
                    }
                    catch (Exception exception)
                    {
                        txtPin.Text = "";
                        Application.DoEvents();
                        Console.WriteLine(exception);
                    }
                    Application.DoEvents();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnCripto_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCripto2.Text = Cripto.EncryptString(this.txtCripto1.Text);

                this.txtCripto4.Text = Cripto.DecryptString(this.txtCripto3.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public string FirmaXML_Xades(string xmlDocSf, X509Certificate2 cert)
        {
            try
            {
                //X509Certificate2 cert2 = new X509Certificate2();
                //X509Certificate2 cert = new X509Certificate2(certificadoPath, certificadoClave);

                //var certBytes = Convert.FromBase64String(certificadoRawData);
                //X509Certificate2 cert = new X509Certificate2(certBytes);

                if (cert.NotAfter < DateTime.Now)
                {
                    throw new Exception("Certificado inválido, fecha de vencimiento es menor a la fecha actual");
                }

                XadesService xadesService = new XadesService();
                SignatureParameters parametros = new SignatureParameters();

                parametros.SignaturePolicyInfo = new SignaturePolicyInfo();
                parametros.SignaturePolicyInfo.PolicyIdentifier = "https://tribunet.hacienda.go.cr/docs/esquemas/2016/v4.1/Resolucion_Comprobantes_Electronicos_DGT-R-48-2016.pdf";
                // 'La propiedad PolicyHash es la misma para todos, es un cálculo en base al archivo pdf indicado en PolicyIdentifier
                parametros.SignaturePolicyInfo.PolicyHash = "Ohixl6upD6av8N7pEvDABhEL6hM=";
                parametros.SignaturePackaging = SignaturePackaging.ENVELOPED;
                parametros.DataFormat = new DataFormat();
                parametros.Signer = new FirmaXadesNet.Crypto.Signer(cert);

                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlDocSf));
                FirmaXadesNet.Signature.SignatureDocument docFirmado = xadesService.Sign(ms, parametros);

                return docFirmado.Document.OuterXml;
            }
            catch (Exception ex)
            {
                throw new Exception($"FirmaXML_Xades: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("C:\\Temp\\xmlSF.xml");

            X509Certificate2 cert2 = new X509Certificate2(this.txtCertificado.Text, this.txtPin.Text);
            X509Certificate2 cert3 = GetCertificado2(0, "000001-110130265/Pruebas/011013026531.p12", "1224");
            
            string xmlFirmado = FirmaXML_Xades(xmlDocument.OuterXml, cert2);

            System.IO.File.WriteAllText("C:\\Temp\\xmlFirmado.xml", xmlFirmado);
            
            string xmlFirmado2 = FirmaXML_Xades(xmlDocument.OuterXml, cert3);

            System.IO.File.WriteAllText("C:\\Temp\\xmlFirmado2.xml", xmlFirmado2);
        }


        private X509Certificate2 GetCertificado2(int codigoCompania, string path, string password)
        {
            try
            {
                BlobContainerClient container =
                    new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=apifecrdocumentos;AccountKey=jfG4JLxT70Upk7kLWwxRDM0nKicqUC71YblvQmJliy+s4S3MGFrnfp3Hva+noBRhQFdkNlwSmN/DHZvm5gNPAw==;EndpointSuffix=core.windows.net",
                        "certificados");

                BlobClient blob = container.GetBlobClient(path);
                BlobDownloadInfo download = blob.Download();

                var requestStream = new MemoryStream();
                //download.Content.CopyTo(requestStream);
                
                byte[] bytes = requestStream.ToArray();

                return new X509Certificate2(bytes, password);



                ////var fileLength = bytes.PostedFile.ContentLength;
                ////var certdata = new byte[fileLength];

                ////file.FileContent.Read(certData, 0, fileLength);

                ////var cert = new X509Certificate2(certData);


                //----------------------------------------------------------------
                //X509Certificate2 cert = new X509Certificate2(bytes, password);

                //var stringOfCertWithPrivateKey = Convert.ToBase64String(cert.Export(X509ContentType.Pfx));

                //DotNetcr.AZF.DataBusiness.Compania iCompania = new Compania();
                //iCompania.ActualizaCertificadoCompania(codigoCompania,
                //    stringOfCertWithPrivateKey,
                //    cert.NotAfter);

                //return stringOfCertWithPrivateKey;

            }
            catch (Exception e)
            {
                throw new Exception($"GetCertificado: {e.Message}");
            }
        }
    }
}

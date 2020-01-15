# Valida Certificado
Función para validar la fecha de vencimiento de un certificado

    X509Certificate2 cert = new X509Certificate2(txtCertificado.Text, txtPin.Text);

    if (cert.NotAfter > DateTime.Now)

    {
        Console.WriteLine(cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - VÁLIDO");
    }
    else
    {
        Console.WriteLine(cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - INVÁLIDO");                    
    }

    Console.Read();

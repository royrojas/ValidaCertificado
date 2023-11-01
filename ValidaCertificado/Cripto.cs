using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCertificado
{
    public class Cripto
    {
        private static string SecretKey = "DNCR API@FE@CR 78";

        public static string EncryptString(string InputString)
        {
            try
            {
               CipherMode CyphMode = CipherMode.ECB;

                TripleDESCryptoServiceProvider Des = new TripleDESCryptoServiceProvider();
                // Put the string into a byte array
                byte[] InputbyteArray = Encoding.UTF8.GetBytes(InputString);
                // Create the crypto objects, with the key, as passed in
                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                Des.Key = hashMD5.ComputeHash(Encoding.ASCII.GetBytes(SecretKey));
                Des.Mode = CyphMode;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, Des.CreateEncryptor(), CryptoStreamMode.Write);
                // Write the byte array into the crypto stream
                // (It will end up in the memory stream)
                cs.Write(InputbyteArray, 0, InputbyteArray.Length);
                cs.FlushFinalBlock();
                // Get the data back from the memory stream, and into a string
                StringBuilder ret = new StringBuilder();
                byte[] b = ms.ToArray();
                ms.Close();
                int I;

                for (I = 0; I <= b.GetUpperBound(0); I++)
                    // Format as hex
                    ret.AppendFormat("{0:X2}", b[I]);

                return ret.ToString();
            }
            catch (CryptographicException ex)
            {
                // ExceptionManager.Publish(ex)
                throw ex;
            }
        }

        public static string DecryptString(string InputString)
        {
            try
            {
                CipherMode CyphMode = CipherMode.ECB;

                if (InputString == string.Empty)
                    return "";

                TripleDESCryptoServiceProvider Des = new TripleDESCryptoServiceProvider();
                // Put the string into a byte array
                byte[] InputbyteArray = new byte[System.Convert.ToInt32(InputString.Length / (double)2 - 1) + 1];
                // Create the crypto objects, with the key, as passed in
                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();

                Des.Key = hashMD5.ComputeHash(Encoding.ASCII.GetBytes(SecretKey));
                Des.Mode = CyphMode;
                // Put the input string into the byte array

                int X;

                for (X = 0; X <= InputbyteArray.Length - 1; X++)
                {
                    Int32 IJ = (Convert.ToInt32(InputString.Substring(X * 2, 2), 16));
                    ByteConverter BT = new ByteConverter();
                    InputbyteArray[X] = new byte();
                    InputbyteArray[X] = System.Convert.ToByte(BT.ConvertTo(IJ, typeof(byte)));
                }

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, Des.CreateDecryptor(), CryptoStreamMode.Write);

                // Flush the data through the crypto stream into the memory stream
                cs.Write(InputbyteArray, 0, InputbyteArray.Length);
                cs.FlushFinalBlock();

                // //Get the decrypted data back from the memory stream
                StringBuilder ret = new StringBuilder();
                byte[] B = ms.ToArray();

                ms.Close();
                    
                int I;

                for (I = 0; I <= B.GetUpperBound(0); I++)
                    ret.Append((char)(B[I]));

                return ret.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al identificar la configuracion de acceso");
            }
        }
    }
}


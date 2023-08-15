using System;
using System.Security.Cryptography;
using Com.Avataryug.Client;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// This class is used to decrypt the model on given key
    /// </summary>
    public class ModelDecryptionHandler
    {
        //Get glb bytes
        public static byte[] GetGlbByte(byte[] data)
        {
            byte[] outdata = GetGlbDecryptByte(data);
            return outdata;
        }

        //Convert key string to bytes 
        static byte[] StringToByteKey(string _key)
        {
            byte[] byteArray = new byte[_key.Length / 2];
            for (int i = 0; i < _key.Length; i += 2)
            {
                byteArray[i / 2] = Convert.ToByte(_key.Substring(i, 2), 16);
            }
            return byteArray;
        }

        //Get GLB bytes
        public static byte[] GetGlbDecryptByte(byte[] data)
        {
            byte[] inputkey = StringToByteKey(Configuration.SecretKey);
            byte[] inputiv = StringToByteKey(Configuration.IVSecretKey);
            var dta = Decrypt(data, inputkey, inputiv);
            return dta;
        }

        //Decrypt the file
        static byte[] Decrypt(byte[] data, byte[] kye, byte[] ive)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = kye;
                aesAlg.IV = ive;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] plainBytes = decryptor.TransformFinalBlock(data, 0, data.Length);
                return plainBytes;
            }
        }
    }
}
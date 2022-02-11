using System;
using System.Security.Cryptography;
using System.Text;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PasswordHandler'
    public static class PasswordHandler
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PasswordHandler'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PasswordHandler.EncriptarPassword(string, string)'
        public static string EncriptarPassword(string password,string  salt)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PasswordHandler.EncriptarPassword(string, string)'
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(password);

            // Get the key from config file

            
#pragma warning disable CS1587 // XML comment is not placed on a valid language element
///Aqui va el salt del usuario
            //string key = ConfigurationManager.AppSettings[Constants.SALT_KEY];

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(salt));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();


            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PasswordHandler.Decrypt(string, string)'
        public static string Decrypt(string passwordEncriptado,string salt)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PasswordHandler.Decrypt(string, string)'
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(passwordEncriptado);

            //Get your key from config file to open the lock!
            //string key = ConfigurationManager.AppSettings[Constants.SALT_KEY];

                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(salt));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
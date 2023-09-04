using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EasyCriptografia
{
    public class EasyCriptografia
    {
        private EasyCriptografia.ServiceProviderEnum mAlgorithm;
        private SymmetricAlgorithm mCryptoService;

        public EasyCriptografia()
        {
            this.mCryptoService = (SymmetricAlgorithm)new RijndaelManaged();
            this.mAlgorithm = EasyCriptografia.ServiceProviderEnum.Rijndael;
        }

        public EasyCriptografia(
          EasyCriptografia.ServiceProviderEnum serviceProvider)
        {
            switch (serviceProvider)
            {
                case EasyCriptografia.ServiceProviderEnum.Rijndael:
                    this.mCryptoService = (SymmetricAlgorithm)new RijndaelManaged();
                    this.mAlgorithm = EasyCriptografia.ServiceProviderEnum.Rijndael;
                    break;
                case EasyCriptografia.ServiceProviderEnum.RC2:
                    this.mCryptoService = (SymmetricAlgorithm)new RC2CryptoServiceProvider();
                    this.mAlgorithm = EasyCriptografia.ServiceProviderEnum.RC2;
                    break;
                case EasyCriptografia.ServiceProviderEnum.DES:
                    this.mCryptoService = (SymmetricAlgorithm)new DESCryptoServiceProvider();
                    this.mAlgorithm = EasyCriptografia.ServiceProviderEnum.DES;
                    break;
                case EasyCriptografia.ServiceProviderEnum.TripleDES:
                    this.mCryptoService = (SymmetricAlgorithm)new TripleDESCryptoServiceProvider();
                    this.mAlgorithm = EasyCriptografia.ServiceProviderEnum.TripleDES;
                    break;
            }
        }

        public virtual byte[] GetLegalKey(string key)
        {
            if (this.mCryptoService.LegalKeySizes.Length > 0)
            {
                int num1 = key.Length * 8;
                int minSize = this.mCryptoService.LegalKeySizes[0].MinSize;
                int maxSize = this.mCryptoService.LegalKeySizes[0].MaxSize;
                int skipSize = this.mCryptoService.LegalKeySizes[0].SkipSize;
                if (num1 > maxSize)
                    key = key.Substring(0, maxSize / 8);
                else if (num1 < maxSize)
                {
                    int num2 = num1 <= minSize ? minSize : num1 - num1 % skipSize + skipSize;
                    if (num1 < num2)
                        key = key.PadRight(num2 / 8, '*');
                }
            }
            return Encoding.ASCII.GetBytes(key);
        }

        private void SetLegalIV()
        {
            if (this.mAlgorithm == EasyCriptografia.ServiceProviderEnum.Rijndael)
                this.mCryptoService.IV = new byte[16]
                {
          (byte) 11,
          (byte) 110,
          (byte) 19,
          (byte) 46,
          (byte) 49,
          (byte) 210,
          (byte) 205,
          (byte) 247,
          (byte) 5,
          (byte) 54,
          (byte) 156,
          (byte) 234,
          (byte) 168,
          (byte) 76,
          (byte) 99,
          (byte) 204
                };
            else
                this.mCryptoService.IV = new byte[8]
                {
          (byte) 11,
          (byte) 110,
          (byte) 19,
          (byte) 46,
          (byte) 49,
          (byte) 210,
          (byte) 205,
          (byte) 247
                };
        }

        public virtual string Encriptar(string plainText, string key)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(plainText);
            this.mCryptoService.Key = this.GetLegalKey(key);
            this.SetLegalIV();
            ICryptoTransform encryptor = this.mCryptoService.CreateEncryptor();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array = memoryStream.ToArray();
            return Convert.ToBase64String(array, 0, array.GetLength(0));
        }

        public virtual string Desencriptar(string cryptoText, string key)
        {
            byte[] buffer = Convert.FromBase64String(cryptoText);
            this.mCryptoService.Key = this.GetLegalKey(key);
            this.SetLegalIV();
            ICryptoTransform decryptor = this.mCryptoService.CreateDecryptor();
            try
            {
                return new StreamReader((Stream)new CryptoStream((Stream)new MemoryStream(buffer, 0, buffer.Length), decryptor, CryptoStreamMode.Read)).ReadToEnd();
            }
            catch (Exception ex)
            {
                return (string)null;
            }
        }

        public enum ServiceProviderEnum
        {
            Rijndael,
            RC2,
            DES,
            TripleDES,
        }
    }
}

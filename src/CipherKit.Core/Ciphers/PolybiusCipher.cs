using System;
using System.Text;
using CipherKit.Core.Interfaces;
using CipherKit.Core.Exceptions;

namespace CipherKit.Core.Ciphers
{
    public class PolybiusCipher : ICipher
    {
        private readonly char[,] _polybiusSquare = {
            {'A', 'B', 'C', 'D', 'E'},
            {'F', 'G', 'H', 'I', 'K'},
            {'L', 'M', 'N', 'O', 'P'},
            {'Q', 'R', 'S', 'T', 'U'},
            {'V', 'W', 'X', 'Y', 'Z'}
        };

        public string Encrypt(string plaintext)
        {
            if (plaintext == null)
                throw new CipherParameterException("Plaintext cannot be null.");
            var sb = new StringBuilder();
            plaintext = plaintext.ToUpper().Replace("J", "I");

            foreach (char ch in plaintext)
            {
                if (char.IsLetter(ch))
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            if (_polybiusSquare[row, col] == ch)
                            {
                                sb.Append(row + 1);
                                sb.Append(col + 1);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            if (ciphertext == null)
                throw new CipherParameterException("Ciphertext cannot be null.");
            var sb = new StringBuilder();

            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                if (char.IsDigit(ciphertext[i]) && char.IsDigit(ciphertext[i + 1]))
                {
                    int row = int.Parse(ciphertext[i].ToString()) - 1;
                    int col = int.Parse(ciphertext[i + 1].ToString()) - 1;
                    sb.Append(_polybiusSquare[row, col]);
                }
                else
                {
                    sb.Append(ciphertext[i]);
                    i--;
                }
            }
            return sb.ToString();
        }
    }
}

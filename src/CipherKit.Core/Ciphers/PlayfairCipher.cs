using System;
using System.Collections.Generic;
using System.Text;
using CipherKit.Core.Interfaces;
using CipherKit.Core.Exceptions;

namespace CipherKit.Core.Services
{
    public class PlayfairCipher : ICipher
    {
        private readonly string _key;
        private readonly char[,] _matrix;

        public PlayfairCipher(string key)
        {
            _key = key;
            _matrix = GenerateMatrix(key);
        }

        private char[,] GenerateMatrix(string key)
        {
            key = key.ToUpper().Replace("J", "I");
            var seen = new HashSet<char>();
            var matrixList = new List<char>();

            // Process key
            foreach (char c in key)
            {
                if (char.IsLetter(c) && !seen.Contains(c))
                {
                    seen.Add(c);
                    matrixList.Add(c);
                }
            }
            // Add remaining letters (exclude J)
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c == 'J') continue;
                if (!seen.Contains(c))
                {
                    seen.Add(c);
                    matrixList.Add(c);
                }
            }

            var matrix = new char[5, 5];
            int index = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    matrix[row, col] = matrixList[index++];
                }
            }
            return matrix;
        }

        // Helper: Get row and col of a letter
        private void GetPosition(char letter, out int row, out int col)
        {
            letter = (letter == 'J') ? 'I' : letter;
            for (row = 0; row < 5; row++)
            {
                for (col = 0; col < 5; col++)
                {
                    if (_matrix[row, col] == letter)
                        return;
                }
            }
            throw new ArgumentException($"Letter '{letter}' not found in matrix.");
        }

        // Preprocess text: remove spaces, replace J with I, split into digraphs inserting X between identical letters or at end if needed.
        private List<string> PrepareText(string input, bool forEncryption = true)
        {
            input = input.ToUpper().Replace("J", "I").Replace(" ", "");
            var digraphs = new List<string>();
            int i = 0;
            while (i < input.Length)
            {
                char first = input[i];
                char second = (i + 1 < input.Length) ? input[i + 1] : 'X';
                if (first == second)
                {
                    digraphs.Add($"{first}X");
                    i++;
                }
                else
                {
                    digraphs.Add($"{first}{second}");
                    i += 2;
                }
            }
            // If odd, last digraph is padded already in loop.
            return digraphs;
        }

        public string Encrypt(string plaintext)
        {
            if (plaintext == null) 
                throw new CipherParameterException("Plaintext cannot be null.");
            var digraphs = PrepareText(plaintext);
            var ciphertext = new StringBuilder();

            foreach (var pair in digraphs)
            {
                char a = pair[0], b = pair[1];
                GetPosition(a, out int row1, out int col1);
                GetPosition(b, out int row2, out int col2);

                if (row1 == row2)
                {   // Same row: shift right
                    ciphertext.Append(_matrix[row1, (col1 + 1) % 5]);
                    ciphertext.Append(_matrix[row2, (col2 + 1) % 5]);
                }
                else if (col1 == col2)
                {   // Same column: shift down
                    ciphertext.Append(_matrix[(row1 + 1) % 5, col1]);
                    ciphertext.Append(_matrix[(row2 + 1) % 5, col2]);
                }
                else
                {   // Rectangle: swap columns
                    ciphertext.Append(_matrix[row1, col2]);
                    ciphertext.Append(_matrix[row2, col1]);
                }
            }
            return ciphertext.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            if (ciphertext == null) 
                throw new CipherParameterException("Ciphertext cannot be null.");
            // Assume ciphertext already in digraphs form
            var sb = new StringBuilder();
            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                char a = ciphertext[i];
                char b = ciphertext[i + 1];
                GetPosition(a, out int row1, out int col1);
                GetPosition(b, out int row2, out int col2);

                if (row1 == row2)
                {   // Same row: shift left
                    sb.Append(_matrix[row1, (col1 + 4) % 5]);
                    sb.Append(_matrix[row2, (col2 + 4) % 5]);
                }
                else if (col1 == col2)
                {   // Same column: shift up
                    sb.Append(_matrix[(row1 + 4) % 5, col1]);
                    sb.Append(_matrix[(row2 + 4) % 5, col2]);
                }
                else
                {   // Rectangle: swap columns
                    sb.Append(_matrix[row1, col2]);
                    sb.Append(_matrix[row2, col1]);
                }
            }
            return sb.ToString();
        }
    }
}

namespace CipherKit.Core.Interfaces
{
    public interface ICipher
    {
        string Encrypt(string plaintext);
        string Decrypt(string ciphertext);
    }
}

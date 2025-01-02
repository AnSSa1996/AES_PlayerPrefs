using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class AESCryptoHelper
{
    // 예시 키(16바이트 = 128bit). 실제론 외부에서 받거나 더 안전하게 관리해야 함.
    private static readonly byte[] Key; 
    // 예시 IV(16바이트). 실제론 고정 IV는 보안에 취약할 수 있으므로, 상황에 맞춰 다르게 구성.
    private static readonly byte[] IV; 
    
    static AESCryptoHelper()
    {
        // 키와 IV 생성
        var sha256 = SHA256.Create();
        Key = sha256.ComputeHash(Encoding.UTF8.GetBytes("MySecretKey"));
        var fullIv = sha256.ComputeHash(Encoding.UTF8.GetBytes("MySecretIV"));
        IV = new byte[16];
        Array.Copy(fullIv, IV, IV.Length);
    }
    
    /// <summary>
    /// AES로 문자열을 암호화하여 Base64 문자열로 반환
    /// </summary>
    public static string EncryptString(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return "";
        
        // 문자열 → 바이트
        var plainBytes = Encoding.UTF8.GetBytes(plainText);

        using var aes = Aes.Create();
        aes.Mode    = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = Key;
        aes.IV  = IV;

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        cs.Write(plainBytes, 0, plainBytes.Length);
        cs.FlushFinalBlock();
        var encryptedData = ms.ToArray();
        // 암호화된 바이트 → Base64 인코딩
        return Convert.ToBase64String(encryptedData);
    }

    /// <summary>
    /// AES로 암호화된 Base64 문자열을 복호화
    /// </summary>
    public static string DecryptString(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return "";

        var cipherBytes = Convert.FromBase64String(cipherText);

        using Aes aes = Aes.Create();
        aes.Mode    = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = Key;
        aes.IV  = IV;

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
        cs.Write(cipherBytes, 0, cipherBytes.Length);
        cs.FlushFinalBlock();
        var decryptedData = ms.ToArray();
        return Encoding.UTF8.GetString(decryptedData);
    }
}

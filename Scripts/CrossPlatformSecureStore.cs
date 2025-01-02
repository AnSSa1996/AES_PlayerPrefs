using UnityEngine;

public class CrossPlatformSecureStore : ISecureStore
{
    public void SaveSecret(string key, string value)
    {
        // 1) AES 암호화
        var encrypted = AESCryptoHelper.EncryptString(value);
        // 2) PlayerPrefs에 암호문 저장
        PlayerPrefs.SetString(key, encrypted);
        PlayerPrefs.Save();
    }

    public string LoadSecret(string key)
    {
        if (PlayerPrefs.HasKey(key) == false)
        {
            return string.Empty;
        }

        // 1) 암호문(문자열) 가져오기
        var encrypted = PlayerPrefs.GetString(key);
        // 2) AES 복호화
        var decrypted = AESCryptoHelper.DecryptString(encrypted);
        return decrypted;
    }

    public void DeleteSecret(string key)
    {
        if (PlayerPrefs.HasKey(key) == false) return;
        PlayerPrefs.DeleteKey(key);
    }
}
public interface ISecureStore
{
    void SaveSecret(string key, string value);
    string LoadSecret(string key);
    void DeleteSecret(string key);
}

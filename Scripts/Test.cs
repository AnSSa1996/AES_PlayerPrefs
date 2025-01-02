using UnityEngine;

public class Test : MonoBehaviour
{
    ISecureStore store;

    private void Awake()
    {
        // CrossPlatformSecureStore 사용
        store = new CrossPlatformSecureStore();
    }

    private void Start()
    {
        // 저장
        store.SaveSecret("user_password", "myP@ssw0rd!");
        
        // 불러오기
        var loaded = store.LoadSecret("user_password");
        Debug.Log($"Loaded password: {loaded}");
    }
}
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public static DebugManager Instance { get; private set; }

    [SerializeField] private bool _isDebugMode;
    public static bool IsDebugMode { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        IsDebugMode = _isDebugMode;
    }

    public void ToggleDebugMode()
    {
        IsDebugMode = !IsDebugMode;
    }
}

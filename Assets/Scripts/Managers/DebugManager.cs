using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public static DebugManager Instance { get; private set; }

    [SerializeField] private bool _isDebugMode;
    public static bool IsDebugMode => Instance != null && Instance._isDebugMode;
    [SerializeField] private bool _skipDialogues;
    public static bool SkipDialogues => Instance != null && Instance._isDebugMode && Instance._skipDialogues;
    [SerializeField] private bool _skipAnimations;
    public static bool SkipAnimations => Instance != null && Instance._isDebugMode && Instance._skipAnimations;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ToggleDebugMode() => _isDebugMode = !_isDebugMode;
}

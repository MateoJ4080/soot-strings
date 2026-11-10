using System.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public IEnumerator PlaySequence(DialogueSequence dialogue)
    {
        _playerController.enabled = false;
        foreach (var line in dialogue.Lines)
        {
            yield return UIManager.Instance.ShowDialogue(line);
        }
        _playerController.enabled = true;
    }
}

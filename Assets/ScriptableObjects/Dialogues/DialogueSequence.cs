using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSequence", menuName = "Dialogue/DialogueSequence")]
public class DialogueSequence : ScriptableObject
{
    [SerializeField] private DialogueLine[] lines;
    public DialogueLine[] Lines => lines;
}
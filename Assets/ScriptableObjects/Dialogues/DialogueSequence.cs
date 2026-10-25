using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSequence", menuName = "Dialogue/DialogueSequence")]
public class DialogueSequence : ScriptableObject
{
    [SerializeField] private DialogueLine[] lines;
    [SerializeField] private float duration;

    public DialogueLine[] Lines => lines;
    public float Duration => duration;
}
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string Text;
    public Characters Speaker;
    // Placeholder to set a custom background for each character. An alternative is doing it from UIManager or DialogueManager taking "Speaker" as parameter
    // public Sprite Background;
}

public enum Characters
{
    MainCharacter,
    Wife,
    Daughter
}
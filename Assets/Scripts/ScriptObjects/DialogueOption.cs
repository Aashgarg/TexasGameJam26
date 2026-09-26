using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOption", menuName = "Scriptable Objects/DialogueOption")]
public class DialogueOption : ScriptableObject
{
    public string text;
    public int nextNodeID;
    public float stressDelta;
    public ClueData clue;
}

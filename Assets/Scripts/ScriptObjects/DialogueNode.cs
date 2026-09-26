using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Scriptable Objects/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public int nodeID;
    public bool endNode;
    public string dialogue;
    public DialogueOption[] options;
}

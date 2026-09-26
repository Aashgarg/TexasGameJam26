using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NPCData", menuName = "Scriptable Objects/NPCData")]
public class NPCData : ScriptableObject
{
    public string NPCName;
    public Sprite portrait;
    public float startingStress;
    public float targetStress;
    public float currentStress;

    public List<DialogueNode> nodes;
}

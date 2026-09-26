using UnityEngine;

[CreateAssetMenu(fileName = "ClueData", menuName = "Scriptable Objects/ClueData")]
public class ClueData : ScriptableObject
{
    public string clueName;
    public string description;
    public Sprite picture;
}

using UnityEngine;

[CreateAssetMenu(fileName = "ShopOption", menuName = "Scriptable Objects/ShopOption")]
public class ShopOption : ScriptableObject
{
    public int cost;
    public string displayName;
    public GameObject ballPrefab;
    public bool bought = true;
}

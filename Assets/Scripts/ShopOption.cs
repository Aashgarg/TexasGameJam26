using UnityEngine;

[CreateAssetMenu(fileName = "ShopOption", menuName = "Scriptable Objects/ShopOption")]
public class ShopOption : ScriptableObject
{
    public int cost;
    public string displayName;
    public GameObject ballPrefab; //contains different sprites
    public bool bought = true;
}

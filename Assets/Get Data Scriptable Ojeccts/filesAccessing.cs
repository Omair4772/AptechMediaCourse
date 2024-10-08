using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayerDataHealth", menuName = "ScriptableObjectsNew/PlayerData", order = 1)]

public class filesAccessing : ScriptableObject
{
    public string playerName = "Omair";
    public int playerLevel = 2;
    public float health = 100f;
    public float mana = 4.4f;
}

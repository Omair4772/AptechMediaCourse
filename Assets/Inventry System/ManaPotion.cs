
using UnityEngine;
using UnityEngine.UI;

public class ManaPotion : MonoBehaviour, IItem
{
    private Inventory inventory;
    public PlayerInteraction interaction;
    public string Name { get; private set; }


    public ManaPotion()
    {
        Name = "Mana Potion";
    }

    public void UseItem()
    {
        Debug.Log("You have used a Mana Potion.");

        interaction.presentHealth = (interaction.presentHealth - interaction.damage < 0 ) ? 0 : interaction.presentHealth -= interaction.damage;
        interaction.healthShow.text = interaction.presentHealth.ToString();
    }

    public string GetDescription()
    {
        return "Restores mana when used.";
    }
}

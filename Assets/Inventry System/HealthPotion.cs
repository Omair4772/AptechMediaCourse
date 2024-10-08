using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : MonoBehaviour, IItem
{

    public string Name { get; private set; }
    public PlayerInteraction interaction;

    public HealthPotion()
    {
        Name = "Health Potion";
    }
    public void UseItem()
    {
        Debug.Log("You have used a Health Potion.");

       interaction.presentHealth = ( interaction.presentHealth + interaction.healthToGive > interaction.maxHealth) ? interaction.maxHealth : interaction.presentHealth += interaction.healthToGive;
        interaction.healthShow.text = interaction.presentHealth.ToString();
        
    }

    public string GetDescription()
    {
        return "Restores health when used.";
    }
}

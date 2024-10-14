using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunSwitcherAnimatorController : MonoBehaviour
{
    public int id;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemNameUI;
    public Image selectedItem;
    private bool isSelected = false;
    public Sprite icon;


    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        if (isSelected)
        {
            selectedItem.sprite = icon;
            itemNameUI.text = itemName;
        }
    }

    public void Selected()
    {
        isSelected = true;
        WeaponWheelController.weaponID = id;
    }
    public void DeSelected()
    {
        isSelected = false;
        WeaponWheelController.weaponID = 0;
    }

    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
        itemNameUI.text = itemName;
    }
    public void HoverExit()
    {
        anim.SetBool("Hover", false);
        itemNameUI.text = "";
    }
}

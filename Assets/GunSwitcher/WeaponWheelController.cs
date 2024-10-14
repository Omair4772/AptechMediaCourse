using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour
{
    public Animator anim;
    private bool weaponWheelSelected = false;
    public Image selecetedItem;
    public Sprite noImage;
    public static int weaponID;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelSelected = !weaponWheelSelected;
        }

        if (weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
        }


        switch (weaponID)
        {

            case 0: // Nothing is selected
                Debug.Log("NOTHING");
                selecetedItem.sprite = noImage;
                break;

            case 1: // Pistol is Selected
                Debug.Log("PUNCH");
                break;

            case 2: // M4 is Selected
                Debug.Log("M4");
                break;

            case 3: // Granade is selected
                Debug.Log("Granade");
                break;

            case 4: // Knife is selected
                Debug.Log("Knife");
                break;
            
            case 5: // PUNCH is Seleted
                Debug.Log("PISTOL");
                break;
        }
    }
}

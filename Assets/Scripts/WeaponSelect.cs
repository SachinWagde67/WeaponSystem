using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    [SerializeField] private List<WeaponSO> weaponSO = new List<WeaponSO>();

    public void OnWeaponSlect(int selectedWeapon)
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.GetComponent<Image>().color = Color.green;
                WeaponManager.instance.getWeaponData(weaponSO[selectedWeapon]);
            }
            else
            {
                weapon.GetComponent<Image>().color = Color.white;
            }
            i++;
        }
    }
}

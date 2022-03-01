using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scripts/Weapons/newWeapon")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public int TotalAmmo;
    public int oneMagizineAmmo;
    public int currentAmmo;
    public float fireRate;
    public bool isAutoGun;
}

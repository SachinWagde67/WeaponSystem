using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager: MonoBehaviour
{
    #region Singleton

    public static WeaponManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnFireClick();
    public OnFireClick onFireClickCallback;
    public delegate void OnReloadClick();
    public OnReloadClick onReloadClickCallback;

    [SerializeField] private WeaponSelect weaponSelect;
    [SerializeField] private Button pistolBtn;
    [SerializeField] private Button smgBtn;
    [SerializeField] private Button RifleBtn;
    [SerializeField] private TextMeshProUGUI totalAmmoTxt;
    [SerializeField] private TextMeshProUGUI currentAmmoTxt;
    [SerializeField] private TextMeshProUGUI weaponNameTxt;

    private int totalAmmo;
    private int oneMagAmmo;
    private int currentAmmo;
    private string weaponName;
    private float fireRate;
    private bool isAutoGun;
    private float nextFire = 0f;

    private void Start()
    {
        pistolBtn.onClick.AddListener(delegate { weaponSelect.OnWeaponSlect(0); });
        smgBtn.onClick.AddListener(delegate { weaponSelect.OnWeaponSlect(1); });
        RifleBtn.onClick.AddListener(delegate { weaponSelect.OnWeaponSlect(2); });
        onFireClickCallback += onFire;
        onReloadClickCallback += onReload;
    }

    private void Update()
    {
        if (isAutoGun)
        {
            if (Input.GetKey(KeyCode.F) && Time.time > nextFire)
            {
                onFireClickCallback?.Invoke();
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            onFireClickCallback?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            onReloadClickCallback?.Invoke();
        }
    }

    public void getWeaponData(WeaponSO  _weaponSO)
    {
        totalAmmo = _weaponSO.TotalAmmo;
        currentAmmo = _weaponSO.currentAmmo;
        oneMagAmmo = _weaponSO.oneMagizineAmmo;
        weaponName = _weaponSO.weaponName;
        fireRate = _weaponSO.fireRate;
        isAutoGun = _weaponSO.isAutoGun;
        showWeaponData();
    }

    private void showWeaponData()
    {
        totalAmmoTxt.text = totalAmmo.ToString();
        currentAmmoTxt.text = currentAmmo.ToString();
        weaponNameTxt.text = weaponName;
    }

    private void onFire()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            nextFire = Time.time + fireRate;
        }
        showWeaponData();
    }

    private void onReload()
    {
        if(totalAmmo > 0)
        {
            int remainingAmmo = oneMagAmmo - currentAmmo;
            currentAmmo = oneMagAmmo;
            totalAmmo = (totalAmmo - remainingAmmo) < 0 ? 0 : (totalAmmo - remainingAmmo);
            showWeaponData();
        }
    }
}

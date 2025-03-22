using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateWeapon(); //enable weapon at start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length > 1) SwitchWeapon(1);
        
        //add mousewheel input here

    }

    //switch with keys
    void SwitchWeapon(int index)
    {
        if (index == currentWeaponIndex) return;

        currentWeaponIndex = index;
        UpdateWeapon();
    }

    //switch with mouse wheel
    void NextWeapon()
    {

    }

    void PreviousWeapon()
    {

    }

    void UpdateWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }
    }
}

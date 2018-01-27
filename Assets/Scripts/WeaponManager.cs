using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField]
    private Weapons[] weapons;

    private static WeaponManager instance;
    public static WeaponManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }    
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddWeapon(ObjectInformation weapon)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].enabled = false;
        }
        switch (weapon.objectType)
        {
            case GSJEnums.objectType.syringe:

                weapons[3].enabled = true;
                break;
        }
    }


}

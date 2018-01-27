using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField]
    private Weapons[] weapons;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void AddWeapon(ObjectInformation weapon)
    {
        switch (weapon.objectType)
        {
            case GSJEnums.objectType.syringe:

                weapons[0].enabled = true;

                break;
        }
    }


}

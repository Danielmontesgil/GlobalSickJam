using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField] public ObjectsData objectsData; //Scriptable

    [SerializeField] private List<Weapons> weapons = new List<Weapons>();
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
            weapons.Add(gameObject.AddComponent<PushPin>());
            weapons.Add(gameObject.AddComponent<GasGrenade>());
            weapons.Add(gameObject.AddComponent<Soap>());
            weapons.Add(gameObject.AddComponent<Syringe>());
            weapons.Add(gameObject.AddComponent<Dust>());
            weapons.Add(gameObject.AddComponent<Settlement>());
        for(int i = 0; i < objectsData.objectsInformation.Count; i++)
        {
            weapons[i].data = objectsData.objectsInformation[i].data;
            weapons[i].enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddWeapon(Weapons weapon)
    {

        weapon.gameObject.SetActive(false);

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].enabled = false;
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapon.data.index == weapons[i].data.index)
            {
                weapons[i].enabled = true;
				UIManager.Instance.ChangeObjectCanvas (weapons [i].data.sprite, weapons [i].data.name);
            }

        }
    }
}

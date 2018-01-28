using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mono : Weapons {

    [SerializeField]
    LayerMask layerMask;

    // Use this for initialization
    void Start()
    {

    }
    public override void Attack(InteractResponse response, List<GameObject> targets = null)
    {
        print(response.canInteract);
        if (!response.canInteract)
        {
            Debug.Log("moriste");
        }
    }
}

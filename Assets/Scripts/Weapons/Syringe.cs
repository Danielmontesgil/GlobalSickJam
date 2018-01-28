using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Weapons {

    [SerializeField]
    LayerMask layerMask;

    // Use this for initialization
    void Start () {
		
	}
	

	public override void Attack(InteractResponse response, List<GameObject> targets=null)
    {
        print(response.canInteract);
        if (response.canInteract)
        {
            Debug.Log(targets.Count);
            if (targets.Count < 2)
            {
               GameManagers.Instance.UpdateScore(response.score);
                Debug.Log(GameManagers.Instance.puntajeGlobal);
            }else
            {
                GameManagers.Instance.UpdateScore(-2);
            }

        }
        else
        {
           GameManagers.Instance.UpdateScore(response.score);
        }
    }
}

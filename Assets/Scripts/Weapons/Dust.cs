using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : Weapons {

    [SerializeField]
    LayerMask layerMask;

    // Use this for initialization
    void Start()
    {

    }


    public override void Attack(InteractResponse response, List<GameObject> targets = null)
    {
        print(response.canInteract);
        if (response.canInteract)
        {
            GameManagers.Instance.UpdateScore(response.score);
        }
        else
        {
            GameManagers.Instance.UpdateScore(response.score);
        }
		UIManager.Instance.FeedBackText (response.message);
    }
}

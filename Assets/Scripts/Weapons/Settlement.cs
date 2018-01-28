using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : Weapons {

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

        if (response.killYou)
        {
            GameManagers.Instance.GameOver(true);
        }
		UIManager.Instance.FeedBackText (response.message);
		if (response.loseObject) {
			UIManager.Instance.ChangeObjectCanvas (null);
			this.enabled = false;

		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soap : Weapons {

    [SerializeField]
    LayerMask layerMask;

    // Use this for initialization
    void Start()
    {
		vision = FindObjectOfType<Vision> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = sound;
    }


    public override void Attack(InteractResponse response, List<GameObject> targets = null)
    {
		audioSource.Play ();
        print(response.canInteract);
        if (response.canInteract)
        {
               GameManagers.Instance.UpdateScore(response.score);
        }
        else
        {
               GameManagers.Instance.UpdateScore(response.score);
        }

        if (response.killYou)
        {
            GameManagers.Instance.GameOver(true);
        }
		UIManager.Instance.FeedBackText (response.message);
		if (response.loseObject) {
			UIManager.Instance.ChangeObjectCanvas (null);
			//vision.LoseWeapon ();
			Vision.Instance.LoseWeapon ();
			for (int i = 0; i < WeaponManager.Instance.weapons.Count; i++) {
				if (data.index == WeaponManager.Instance.weapons [i].data.index) {
					WeaponManager.Instance.weapons [i].enabled = false;
				}
			}

		}
    }
}

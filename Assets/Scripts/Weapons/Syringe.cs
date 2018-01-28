using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Weapons {

    [SerializeField]
    LayerMask layerMask;

    // Use this for initialization
    void Start () {
		vision = FindObjectOfType<Vision> ();
		audioSource = GetComponent<AudioSource> ();
	}
	

	public override void Attack(InteractResponse response, List<GameObject> targets=null)
    {
        print(response.canInteract);
        if (response.canInteract)
        {
			audioSource.clip = sound;
			audioSource.Play ();
            Debug.Log(targets.Count);
            if (targets.Count < 2)
            {
               GameManagers.Instance.UpdateScore(response.score);
            }else
            {
                GameManagers.Instance.UpdateScore(-2);
            }

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

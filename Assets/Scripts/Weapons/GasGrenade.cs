using System.Collections.Generic;
using UnityEngine;

public class GasGrenade : Weapons {

    [SerializeField] private ParticleSystem Gas;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip estallar;
	void Awake()
    {
		vision = FindObjectOfType<Vision> ();
    }
	void Start(){
	}
		

    public override void Attack(InteractResponse response, List<GameObject> targets = null)
    {
        if (response.canInteract)
        {
            if (Gas != null)
                Gas.Play();
            if (audioSource != null)
            {
                if (estallar != null)
                    audioSource.PlayOneShot(estallar);
            }
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

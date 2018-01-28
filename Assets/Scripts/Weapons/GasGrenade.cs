using System.Collections.Generic;
using UnityEngine;

public class GasGrenade : Weapons {

    [SerializeField] private ParticleSystem Gas;
	void Awake()
    {
		vision = FindObjectOfType<Vision> ();
		audioSource = GetComponent<AudioSource> ();
		if(audioSource != null)
		audioSource.clip = sound;

    }
	void Start(){
	}
		

    public override void Attack(InteractResponse response, List<GameObject> targets = null)
    {
		if(audioSource != null)
		audioSource.Play ();
        if (response.canInteract)
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

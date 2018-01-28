using System.Collections.Generic;
using UnityEngine;

public class GasGrenade : Weapons {

    [SerializeField] private ParticleSystem Gas;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip estallar;
    void Start()
    {

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
			this.enabled = false;

		}
    }
}

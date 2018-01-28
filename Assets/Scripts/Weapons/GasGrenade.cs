using System.Collections.Generic;
using UnityEngine;

public class GasGrenade : Weapons {

    [SerializeField] private ParticleSystem Gas;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip estallar;

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
        }

        if (response.killYou)
        {
            GameManagers.Instance.GameOver(true);
        }
    }
}

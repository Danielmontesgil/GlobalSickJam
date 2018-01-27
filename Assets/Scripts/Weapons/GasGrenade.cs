using System.Collections;
using UnityEngine;

public class GasGrenade : Weapons {

    [SerializeField] private ParticleSystem Gas;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip estallar;

    public override void Attack(InteractResponse response)
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
    }
}

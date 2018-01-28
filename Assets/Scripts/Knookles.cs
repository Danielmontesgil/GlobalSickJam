using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knookles : MonoBehaviour {


    [SerializeField]
    private AudioSource sound;
    private bool canSound;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("so");
            sound.Play();
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}

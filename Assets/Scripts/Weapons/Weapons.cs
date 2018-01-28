using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Weapons : MonoBehaviour {

    [SerializeField] public ObjectInformation data;
	[SerializeField] protected AudioSource audioSource;
	public AudioSource sendAudioSource {
		set{ audioSource = value; }
	}
	[SerializeField] protected AudioClip sound;
	public AudioClip sendAudio {
		get{ return sound; }
		set{ sound = value;}
	}
	protected  Vision vision;
    public virtual void Attack(InteractResponse response,List<GameObject> targets=null)
    {

    }
}

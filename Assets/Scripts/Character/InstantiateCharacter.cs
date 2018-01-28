using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCharacter : MonoBehaviour {

	[SerializeField] private CharactersData characters;
	private int indexPlayerToUse;
	private GameObject spawnPoint;
	// Use this for initialization

	void Awake()
	{
		spawnPoint = GameObject.FindGameObjectWithTag ("spawn");
	}

	void OnEnable()
	{
	}

	void Start () 
	{
		indexPlayerToUse = PlayerPrefs.GetInt ("player");
		for (int i = 0; i < characters.characters.Count; i++) {
			if (characters.characters [i].index == indexPlayerToUse)
				UIManager.Instance.ChangeCharactersCanvas (characters.characters [i].icon);
		}
		SpawnCharacter ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SpawnCharacter()
	{
		for (int i = 0; i < characters.characters.Count; i++) {
			if (characters.characters [i].index == indexPlayerToUse)
				Instantiate(characters.characters [i].playerObject, spawnPoint.transform.position, characters.characters [i].playerObject.transform.rotation);
		}
	}
}

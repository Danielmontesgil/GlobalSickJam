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
	}

	void OnEnable()
	{
		SceneController.onLoadAdd += SpawnCharacter;
	}
	void OnDisable()
	{
		SceneController.onLoadAdd -= SpawnCharacter;
	}

	void Start () 
	{
		indexPlayerToUse = PlayerPrefs.GetInt ("player");
		for (int i = 0; i < characters.characters.Count; i++) {
			if (characters.characters [i].index == indexPlayerToUse)
				UIManager.Instance.ChangeCharactersCanvas (characters.characters [i].icon);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SpawnCharacter()
	{
		spawnPoint = GameObject.FindGameObjectWithTag ("spawn");
		for (int i = 0; i < characters.characters.Count; i++) {
			if (characters.characters [i].index == indexPlayerToUse)
				Instantiate(characters.characters [i].playerObject, spawnPoint.transform.position, characters.characters [i].playerObject.transform.rotation);
		}
	}
}

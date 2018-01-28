using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelected : MonoBehaviour {

	[SerializeField] private Button[] characterButtons;
	[SerializeField] private GameObject startButton;

	// Use this for initialization
	void Start () {
		startButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCharacterSelected(int i)
	{
		for(int y = 0; y<characterButtons.Length; y++)
		{
			characterButtons [y].enabled = false;
			characterButtons [y].GetComponent<ChangeSpritesCharcaterSelection>().isSelected = true;
		}
		startButton.SetActive (true);
		PlayerPrefs.SetInt ("player", i);
	}

	public void OnCancelSelection()
	{
		for(int y = 0; y<characterButtons.Length; y++)
		{
			characterButtons [y].enabled = true;
			characterButtons [y].GetComponent<ChangeSpritesCharcaterSelection>().isSelected = false;
		}
		startButton.SetActive (false);
	}
}

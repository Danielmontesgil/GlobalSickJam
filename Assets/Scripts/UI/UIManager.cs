using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private static UIManager instance;
	public static UIManager Instance
	{
		get{ return instance;}
	}

	[SerializeField] private Image characterImage;
	[SerializeField] private Image objectImage;
	[SerializeField] private Text feedBackText;


	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeObjectCanvas(Sprite objectSprite)
	{
		objectImage.sprite = objectSprite;
	}

	public void ChangeCharactersCanvas(Sprite characterSprite)
	{
		characterImage.sprite = characterSprite;
	}

	public void FeedBackText(string message)
	{
		feedBackText.text = message;
	}
}

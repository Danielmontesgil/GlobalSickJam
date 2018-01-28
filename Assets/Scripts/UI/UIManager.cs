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
	[SerializeField] private Text objectName;
	[SerializeField] private Text feedBackText;
	[SerializeField] private Sprite voidObject;


	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start () {
		objectName.text = string.Format ("Object: \n");
		feedBackText.text = string.Format ("LastAction: \n ");
		objectImage.sprite = voidObject;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeObjectCanvas(Sprite objectSprite, string objectName = "")
	{
		if (objectSprite == null) {
			objectImage.sprite = voidObject;
		} else {
			objectImage.sprite = objectSprite;
		}

		if(objectName.Equals(""))
			this.objectName.text = string.Format ("Object: \n");
		else
			this.objectName.text = string.Format ("Object: \n {0}", objectName);
	}

	public void ChangeCharactersCanvas(Sprite characterSprite)
	{
		characterImage.sprite = characterSprite;
	}

	public void FeedBackText(string message)
	{
		feedBackText.text = string.Format ("LastAction: \n {0}", message);
	}
}

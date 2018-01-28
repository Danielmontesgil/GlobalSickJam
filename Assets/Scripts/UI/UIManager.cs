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
    [SerializeField] private Text timeText;

    string minutes;
    string seconds;


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
        UpdateTimeCanvas();
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

    public void UpdateTimeCanvas()
    {
        minutes = ((int)GameManagers.Instance.t / 60).ToString();
        seconds = (GameManagers.Instance.t % 60).ToString("f0");

        timeText.text = minutes + " : " + seconds;
    }

	public void ChangeCharactersCanvas(Sprite characterSprite)
	{
		characterImage.sprite = characterSprite;
	}

	public void FeedBackText(string message)
	{
		feedBackText.text = string.Format ("LastAction: {0}", message);
	}
}

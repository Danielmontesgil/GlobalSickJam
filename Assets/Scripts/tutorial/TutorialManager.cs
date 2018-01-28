using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {
    
	public GameObject Instrucciones;
	public Text TxtInstrucciones;

	public Button BtnSig;

	public GameObject[] Fades;
    public GameObject[] Pantallas;
    private int sequence;
	// Use this for initialization
	void Start () {
		sequence=0;
		Sequence();	
	}
	
	// Update is called once per frame
	public void Sequence(){
		StartCoroutine(SequenceEnum(sequence));
		sequence++;
	}

	public IEnumerator SequenceEnum(int sequence){
        switch (sequence)
		{
			case 0:
			    Pantallas[0].SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(0f,0f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(0f,0f,0f);
				TxtInstrucciones.text="Mueve el personaje con las teclas WASD";
                yield return new WaitForSeconds(0.1f);
			break;
			case 1:
			    Pantallas[1].SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(0f,0f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(0f,0f,0f);
				TxtInstrucciones.text="Mueve el personaje con las teclas WASD";
                yield return new WaitForSeconds(0.1f);
			break;
			
		}   
			
	}
	void Update () {
		
	}
}

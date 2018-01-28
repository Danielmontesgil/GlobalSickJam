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
				Instrucciones.SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(507.6f,0f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(459.3f,230f,0f);
				TxtInstrucciones.text="Mueve el personaje con las teclas WASD.";
                yield return new WaitForSeconds(0.1f);
			break;
			case 1:
			    Pantallas[0].SetActive(false);
			    Pantallas[1].SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(74.8f,37.2f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(459.3f,230f,0f);
				TxtInstrucciones.text="Deveras Buscar items en el mapa para usarlos.";
                yield return new WaitForSeconds(0.1f);
			break;
			case 2:
			    Pantallas[1].SetActive(false);
			    Pantallas[2].SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(32.03f,40f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(626.4f,317.1f,0f);
				TxtInstrucciones.text="Estando al lado de un item presiona <b>F</b> para obtener el item, este aparecera en el recuadro de item abajo a la derecha.";
                yield return new WaitForSeconds(0.1f);
			break;
			case 3:
			    Pantallas[2].SetActive(false);
			    Pantallas[3].SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(-266.96f,40f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(650f,319.6f,0f);
				TxtInstrucciones.text="Teniendo un item debes analizar donde este deve ser usado, al usar un item aparecera un retroalimentación sobre su resultado.";
                yield return new WaitForSeconds(0.1f);
			break;
			case 4:
			    Pantallas[3].SetActive(false);
			    Pantallas[4].SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(-0.5f,185.5f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(601.8f,265.2f,0f);
				TxtInstrucciones.text="<b>All In</b> aparecerá en el mapa patrullando para preguntar sobre como esta tu juego, evitalo o perderás vida.";
                yield return new WaitForSeconds(0.1f);
			break;
			case 5:
			    Pantallas[4].SetActive(false);
			    Pantallas[5].SetActive(true);
				Instrucciones.transform.localPosition = new Vector3(-0.5f,185.5f,0f);
				Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(459.3f,230f,0f);
				TxtInstrucciones.text="Ten cuidado con el tiempo, solo tienes 48 horas.";
                yield return new WaitForSeconds(0.1f);
                break;
             case 6:
                Pantallas[5].SetActive(false);
                Pantallas[1].SetActive(true);
                Instrucciones.transform.localPosition = new Vector3(-41f, 94.14f, 0f);
                Instrucciones.GetComponent<RectTransform>().sizeDelta = new Vector3(595.7f, 322.8f, 0f);
                TxtInstrucciones.text = "El Objetivo de juego es enfermar a todos los otros equipos para que tu equipo sea el unico que termine su juego en el jam.";
                yield return new WaitForSeconds(0.1f);
                break;
            case 7:
			    BtnSig.interactable=false;
				Fades[1].SetActive(true);
                yield return new WaitForSeconds(1.2f);
				SceneManager.LoadScene("UI");
			break;
			
		}   
			
	}
	void Update () {
		
	}
}

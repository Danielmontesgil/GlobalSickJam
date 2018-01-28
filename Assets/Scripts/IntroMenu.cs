using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroMenu : MonoBehaviour {
    public GameObject[] pantallas;

	public GameObject[] Fades;

	public AudioSource audio;
	// Use this for initialization
	void Start () {
		StartCoroutine(SecuenciaMenu());
		StartCoroutine(fadeinAudio());
	}

	public IEnumerator SecuenciaMenu(){
	   yield return new WaitForSeconds(1.2f);	
	   Fades[0].SetActive(false);
       yield return new WaitForSeconds(5f);
	   Fades[1].SetActive(true);
	   yield return new WaitForSeconds(2f);
	   pantallas[0].SetActive(false);
	   pantallas[1].SetActive(true);
	   Fades[1].SetActive(false);
	   Fades[0].SetActive(true);
	   yield return new WaitForSeconds(1.2f);	
	   Fades[0].SetActive(false);
	   pantallas[2].SetActive(true);
	}


	public IEnumerator fadeinAudio(){
		yield return new WaitForSeconds(7f);
		while(audio.volume<=0.6f){
			audio.volume += 0.0025f;
			yield return null;
		}
	}

	public void irSeleccion(){
       StartCoroutine(IrSeleccion());
	}

	public IEnumerator IrSeleccion(){
		Fades[1].SetActive(true);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("ChacraterSlection");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Creditos : MonoBehaviour {
    public GameObject[] fades;
	// Use this for initialization
	void Start () {
		fades[0].SetActive(true);
	}
	
	// Update is called once per frame
    public void ActivarCoroutina(){
         StartCoroutine(ActivarFadeYpasarEscena());
	}

	public IEnumerator ActivarFadeYpasarEscena(){
		fades[1].SetActive(true);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("IntroMenu");
	}
}

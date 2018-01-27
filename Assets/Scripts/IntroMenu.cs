using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMenu : MonoBehaviour {
    public GameObject[] pantallas;

	public GameObject[] Fades;
	// Use this for initialization
	void Start () {
		StartCoroutine(SecuenciaMenu());
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
}

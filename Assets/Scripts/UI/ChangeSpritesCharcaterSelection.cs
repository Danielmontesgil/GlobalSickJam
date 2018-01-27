using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeSpritesCharcaterSelection : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler {

	[SerializeField] private Animator animator;
	[SerializeField] private GameObject buttonToCancel;
	private bool isSelected;

	void Awake()
	{
		animator = GetComponent<Animator> ();
		isSelected = false;
		buttonToCancel.SetActive (false);
	}

	public void OnPointerEnter (PointerEventData ped) {
		if (!isSelected) {
			animator.SetTrigger ("Highlighted");
		}
	}

	public void OnPointerDown (PointerEventData ped) {
		animator.SetTrigger ("Pressed");
		isSelected = true;
		buttonToCancel.SetActive (true);
	} 

	public void OnPointerExit (PointerEventData ped) {
		if (!isSelected) {
			animator.SetTrigger ("Normal");
		}
	} 

	public void SelectedAgain()
	{
		isSelected = false;
		buttonToCancel.SetActive (false);
		animator.SetTrigger ("Highlighted");
	}
}

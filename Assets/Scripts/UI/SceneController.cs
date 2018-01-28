﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	private static SceneController instance;
	public static SceneController Instance
	{
		get{ return instance;}
	}


	public delegate void ScenesBehaviour();
	public static event ScenesBehaviour onLoadAdd;
	public static event ScenesBehaviour onUnload;
	public Camera menuCamera;
	[SerializeField] private string levelName;
	[SerializeField] private float timeToLoadLevel;
	[SerializeField] private bool changeInStart;

	private AsyncOperation loadLevel;

	// Use this for initialization
	void Start () {
		if (changeInStart) {
			LoadLevel ();
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}    
	}

	public void OnPlayAgain()
	{
		Scene level = SceneManager.GetSceneAt (1);
		SceneManager.UnloadSceneAsync (level);
		SceneManager.LoadScene (level.name, LoadSceneMode.Additive);
	}

	public void RemoveScene()
	{
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt (1));
		if (onUnload != null)
			onUnload ();
	}

	public void LoadLevel()
	{
		StartCoroutine (ChangeSceneAdd ());
	}

	IEnumerator ChangeSceneAdd()
	{
		yield return new WaitForSeconds (timeToLoadLevel);
		loadLevel = SceneManager.LoadSceneAsync (levelName, LoadSceneMode.Additive);
		while (!loadLevel.isDone) {
			yield return null;
		}
		if (onLoadAdd != null)
			onLoadAdd ();
	}

	public void LoadScene()
	{
		StartCoroutine (ChangeScene ());
	}

	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds (timeToLoadLevel);
		SceneManager.LoadScene (levelName);
	}
	
	public void OnExitGame()
	{
		Application.Quit ();
	}
}

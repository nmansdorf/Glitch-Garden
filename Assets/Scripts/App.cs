using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour {

	private static App Instance;
	public float LoadTime = 2.5f;
	public LevelManager LManagerPrefab;
	private AudioSource _audioSource;

	
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
		if (Instance == null && Instance != this)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}	
		Invoke("StartGame", LoadTime);
	}

	private void StartGame()
	{
		LevelManager LMInstance = Instantiate(LManagerPrefab);
		LMInstance.LoadNextLevel();
	}

}

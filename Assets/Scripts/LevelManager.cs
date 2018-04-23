using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void LoadLevel(int sceneReference)
	{
		SceneManager.LoadScene(sceneReference);
	}

	public void LoadNextLevel()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		LoadLevel(currentScene+1);
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

}

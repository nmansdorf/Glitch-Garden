using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour {

	// Use this for initialization
	private void Awake()
	{
		MusicManager manager = FindObjectOfType<MusicManager>();
		if (manager != null)
		{
			manager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
		}
	}
	
	
}

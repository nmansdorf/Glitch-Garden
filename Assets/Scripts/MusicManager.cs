using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] AudioClips;
	private AudioSource Player;

	void Start ()
	{
		DontDestroyOnLoad(gameObject);
		Player = GetComponent<AudioSource>();
		PlayTrack(SceneManager.GetActiveScene());
		SceneManager.sceneLoaded += OnNewLevelLoaded;
		

	}

	void OnNewLevelLoaded(Scene scene, LoadSceneMode mode)
	{
		PlayTrack(scene);
	}

	void PlayTrack(Scene scene)
	{
		int buildIndex = scene.buildIndex;
		if (buildIndex < AudioClips.Length && buildIndex != -1)
		{
			int audioIndex = buildIndex;
			
			if (AudioClips[audioIndex] != null && AudioClips[audioIndex] != Player.clip)
			{
				Player.clip = AudioClips[audioIndex];
				Player.loop = true;
				Player.Play();	
			}	
		}
	}

	public void ChangeVolume(float newVolume)
	{
		Player.volume = newVolume;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

	public Slider VolumeSlider, DifficultySlider;
	public Text DifficultyText;

	private int difficulty;
	private float volume;
	private string difficultyString;
	private MusicManager musicManager;
	
	public float DEFAULT_VOLUME = 0.8f;
	public int DEFAULT_DIFFICULTY = 1;

	void Start()
	{
		musicManager = FindObjectOfType<MusicManager>();
		VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
		SetDifficultyString((int)DifficultySlider.value);

	}

	void Update()
	{
		musicManager.ChangeVolume(VolumeSlider.value);
		SetDifficultyString((int)DifficultySlider.value);
	}

	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(VolumeSlider.value);
		PlayerPrefsManager.SetDifficulty((int)DifficultySlider.value);
		LevelManager levelManager = FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Scenes/Main");
	}

	void SetDifficultyString(int difficulty)
	{
		switch (difficulty)
		{
			case 0:
				difficultyString = "Easy";
				break;
			case 1:
				difficultyString = "Normal";
				break;
			case 2:
				difficultyString = "Hard";
				break;
			case 3:
				difficultyString = "Very Hard";
				break;
		}

		DifficultyText.text = difficultyString;
	}

	public void SetDefaults()
	{
		PlayerPrefsManager.SetMasterVolume(DEFAULT_VOLUME);
		VolumeSlider.value = DEFAULT_VOLUME;
		
		PlayerPrefsManager.SetDifficulty(DEFAULT_DIFFICULTY);
		DifficultySlider.value = DEFAULT_DIFFICULTY;
	}


}

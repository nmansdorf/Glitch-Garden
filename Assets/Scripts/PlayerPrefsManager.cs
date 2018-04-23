using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

	private const string MASTER_VOLUME_KEY = "master_volume";
	private const string DIFFICULTY_KEY = "difficulty";
	private const string LEVEL_KEY = "level_unlocked_";
	public static int MaxDifficulty = 3;


	public static void SetMasterVolume(float volume)
	{
		if (volume >= 0f && volume <= 1f)
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else
		{
			Debug.LogError("Master volume" + volume + " out of range");
		}
	}

	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void SetDifficulty(int difficulty)
	{
		if (difficulty >= 0 && difficulty < MaxDifficulty)
		{
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		}
		else
		{
			Debug.LogError("Difficulty "+ difficulty +" out of range");
		}
	}

	public static int GetDifficulty()
	{
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);
	}
	
	public static void UnlockLevel(int level)
	{
		if (level > 0 && level < SceneManager.sceneCount - 1)
		{
			PlayerPrefs.SetInt(LEVEL_KEY + level, 1); //Set 1 for true
		}
		else
		{
			Debug.LogError("Level unlock " + level + " out of range");
		}
	}

	public static bool IsLevelUnlocked(int level)
	{
		if (PlayerPrefs.GetInt(LEVEL_KEY + level) == 1)
		{
			return true;
		}
		else 
		{
			Debug.LogError("Level unlock " + level + "not in build order" );
			return false;
		}
	}
}

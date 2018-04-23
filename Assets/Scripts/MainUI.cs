using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {
	
	public float FadeInRate = 0.1f;
	public float FadeInDuration = 1f;

	public GameObject panel;
	// Use this for initialization
	void Start ()
	{
		Image image = panel.GetComponent<Image>();
		StartCoroutine("FadeOut", image);
	}

	IEnumerator FadeIn(CanvasRenderer renderer)
	{
		for (float f = 0f; f <= 1; f += FadeInRate)
		{
			renderer.SetAlpha(f);
			yield return new WaitForSeconds(FadeInDuration*FadeInRate);
		}
	}

	IEnumerator FadeOut(CanvasRenderer renderer)
	{
		for (float f = 1f; f >= 0; f -= FadeInRate)
		{
			renderer.SetAlpha(f);
			yield return new WaitForSeconds(FadeInDuration*FadeInRate);
		}
	}

	IEnumerator FadeOut(Image image)
	{
		for (float f = 1f; f >= 0; f -= FadeInRate)
		{
			Color color = image.color;
			color.a = f;
			image.color = color;
			yield return new WaitForSeconds(FadeInDuration* FadeInRate);
		}
		panel.SetActive(false);
		
	}

}

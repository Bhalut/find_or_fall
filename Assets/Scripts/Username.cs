using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Username : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
	[SerializeField] private TextMeshProUGUI username;
	[SerializeField] private GameObject startButton;

	private void Awake()
	{
		if(PlayerPrefs.GetString("username") == "") // if key doesn't exist
		{
			PlayerPrefs.SetString("username", username.text);
		}
		username.text = PlayerPrefs.GetString("username");
	}

	public void OpenKeyboard() 
	{
		keyboard = TouchScreenKeyboard.Open(username.text, TouchScreenKeyboardType.Default);
		keyboard.characterLimit = 25;
	}

	void LateUpdate()
	{
		if(keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
		{
			PlayerPrefs.SetString("username", keyboard.text);
			username.text = PlayerPrefs.GetString("username");
			startButton.SetActive(true);
			keyboard = null;
		}
	}
}
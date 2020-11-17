using UnityEngine;
using TMPro;
using SocketIO;
using UnityEngine.SceneManagement;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Contains the methods to manage both players names
/// </summary>
public class Username : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
	[SerializeField] private TextMeshProUGUI username;
	[SerializeField] private GameObject startButton;
	public SocketIOComponent socketIOComponent;
	public Connection connection;

	private void Awake()
	{
		connection = FindObjectOfType<Connection>();
		socketIOComponent = FindObjectOfType<SocketIOComponent>();

		if(string.IsNullOrWhiteSpace(PlayerPrefs.GetString("username"))) // if key doesn't exist
		{
			PlayerPrefs.SetString("username", "username");
		}

		username.text = PlayerPrefs.GetString("username");

		socketIOComponent.url = $"ws://backend-find-or-fall.herokuapp.com/socket.io/?EIO=3&transport=websocket&username={PlayerPrefs.GetString("username")}";
	}

	void UpdateURL()
	{
		socketIOComponent.url = $"ws://backend-find-or-fall.herokuapp.com/socket.io/?EIO=3&transport=websocket&username={PlayerPrefs.GetString("username")}";
		Destroy(connection.gameObject);
		SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
	}

	/// <summary>
    /// Opens the device keyboard
    /// </summary>
	public void OpenKeyboard() 
	{
		keyboard = TouchScreenKeyboard.Open(username.text, TouchScreenKeyboardType.Default);
		keyboard.characterLimit = 25;
	}

	/// <summary>
    /// Sets the name and hide the device's keyboard
    /// </summary>
	void LateUpdate()
	{
		if(keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
			SetUsername(keyboard.text);
	}

	void SetUsername(string name)
	{
		name = ValidUsername(name);

		PlayerPrefs.SetString("username", name);

		username.text = PlayerPrefs.GetString("username");

		UpdateURL();

		startButton.SetActive(true);

		keyboard = null;
	}

	string ValidUsername(string name)
	{
		name = name.Trim();
		name = name.Replace("&", "");
		name = name.Replace("'", "");
		name = name.Replace("\"", "");

		if (string.IsNullOrWhiteSpace(name))
			name = "username";

		return name;
	}
}
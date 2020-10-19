using UnityEngine;
using SocketIO;
using UnityEngine.SceneManagement;
using System.Collections;

public class Connection : MonoBehaviour
{
	public SocketIOComponent socket;
	public SocketFeedback SocketFeedbackInstance;
	public static int button1;
	public static int button2;

	private void Awake()
    {
		DontDestroyOnLoad(gameObject);
    }
    private void Start()
	{
		socket.On("open", OnOpen);
		socket.On("error", OnError);
		socket.On("close", OnClose);
		socket.On("opponent disconnected", OnOpponentDisconnected);
		socket.On("start game", OnStartGame);
		socket.On("my turn", OnMyTurn);
		socket.On("opponent username", OnOpponentUsername);
	}

	public void OnOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
		SocketFeedbackInstance.SetSocketID(socket.sid.ToString());
	}

	public void OnError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}

	public void OnClose(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
		SocketFeedbackInstance.CleanData();
	}

	public void OnOpponentDisconnected(SocketIOEvent e)
    {
		Debug.Log("Opponent Disconnected");
		socket.Close();
		//Notification on screen and stop the game
    }

	public void OnStartGame(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Match complete: " + e.name + " " + e.data);

		SocketFeedbackInstance.SetPlayersID(e.data.GetField("player1_id").str, e.data.GetField("player2_id").str);
		if (socket.sid == e.data.GetField("player1_id").str)
			SocketFeedbackInstance.buttonSendTurn.SetActive(true);

		button1 = int.Parse(e.data.GetField("button_1").str);
		button2 = int.Parse(e.data.GetField("button_2").str);

		StartCoroutine(LoadingGame());
		EmitUsername();
	}

	IEnumerator LoadingGame() {
		Debug.Log("entraaaaaaaaa");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(1);
	}

	public void OnMyTurn(SocketIOEvent e)
    {
		Debug.Log("My Turn, the opponent send: " + e.data.GetField("button"));
		//Allow to click the buttons
    }

	public void OnOpponentUsername(SocketIOEvent e)
	{
		Debug.Log("Opponent username: " + e.data.GetField("username"));
	}


	// =======================================================================
	public void EmitUsername()
    {
		var username = "name" + Random.Range(100, 999);
		socket.Emit("emit username", JSONObject.CreateStringObject(username));
    }
}

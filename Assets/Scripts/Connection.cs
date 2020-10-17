using UnityEngine;
using SocketIO;

public class Connection : MonoBehaviour
{
	public SocketIOComponent socket;
	public SocketFeedback SocketFeedbackInstance;

	private void Start()
	{
		socket.On("open", OnOpen);
		socket.On("error", OnError);
		socket.On("close", OnClose);
		socket.On("opponent disconnected", OnOpponentDisconnected);
		socket.On("start game", OnStartGame);
		socket.On("my turn", OnMyTurn);
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
        {
			SocketFeedbackInstance.buttonSendTurn.SetActive(true);
		}
	}

	public void OnMyTurn(SocketIOEvent e)
    {
		Debug.Log("My Turn");
		//Allow to click the buttons
    }


	// =======================================================================
	public void EmitTurn(string value)
	{
		socket.Emit("emit turn", JSONObject.CreateStringObject(value));
		Debug.Log("Emit turn by player");
		//Wait for response
	}
}

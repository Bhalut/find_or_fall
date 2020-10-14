using UnityEngine;
using SocketIO;

public class Connection : MonoBehaviour
{
	public SocketIOComponent socket;
	public SocketFeedback SocketFeedbackInstance;

	public void Start()
	{
		socket.On("open", OnOpen);
		socket.On("error", OnError);
		socket.On("close", OnClose);
		socket.On("start game", OnStartGame);
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

	public void OnStartGame(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Match complete: " + e.name + " " + e.data);

		if(e.data == null) { return; }

		SocketFeedbackInstance.SetPlayersID(e.data.GetField("player1_id").str, e.data.GetField("player2_id").str);
	}

	// =======================================================================
	public void EmitClose(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}
}

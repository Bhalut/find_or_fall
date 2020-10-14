using UnityEngine;
using TMPro;

public class SocketFeedback : MonoBehaviour
{
	public TextMeshProUGUI socketIDTxt;
	public TextMeshProUGUI player1IDTxt;
	public TextMeshProUGUI player2IDTxt;
	public string socketID;
	public string player1ID;
	public string player2ID;

	public void SetSocketID(string id)
	{
		socketID = id;
	}
	public void SetPlayersID(string id1, string id2)
	{
		player1ID = id1;
		player2ID = id2;
	}

	public void CleanData()
	{
		socketID = null;
		player1ID = null;
		player2ID = null;
	}

	public void LateUpdate()
	{
		socketIDTxt.text = $"socket ID: {socketID}";
		player1IDTxt.text = $"player 1 id: {player1ID}";
		player2IDTxt.text = $"player 2 id: {player2ID}";
	}
}

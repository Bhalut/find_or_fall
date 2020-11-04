using TMPro;
using UnityEngine;

/// <summary>
/// Contains the methods for send feedback about the connection status
/// </summary>
public class SocketFeedback : MonoBehaviour
{
    public TextMeshProUGUI socketIDTxt;
    public TextMeshProUGUI player1IDTxt;
    public TextMeshProUGUI player2IDTxt;
    public string socketID;
    public string player1ID;
    public string player2ID;
    public GameObject buttonSendTurn;

    public void LateUpdate()
    {
        socketIDTxt.text = $"socket ID: {socketID}";
        player1IDTxt.text = $"player 1 id: {player1ID}";
        player2IDTxt.text = $"player 2 id: {player2ID}";
    }

    /// <summary>
    /// Sets the id value
    /// </summary>
    /// <param name="id"></param>
    public void SetSocketID(string id)
    {
        socketID = id;
    }

    /// <summary>
    /// Sets the plasyer's id
    /// </summary>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    public void SetPlayersID(string id1, string id2)
    {
        player1ID = id1;
        player2ID = id2;
    }

    /// <summary>
    /// Sets the values to null
    /// </summary>
    public void CleanData()
    {
        socketID = null;
        player1ID = null;
        player2ID = null;
    }
}
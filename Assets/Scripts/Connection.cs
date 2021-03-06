﻿using UnityEngine;
using UnityEngine.SceneManagement;
using SocketIO;

/// <summary>
/// Contains all the methods for performing connection between two players
/// </summary>
public class Connection : MonoBehaviour
{
    public static int Button1;
    public static int Button2;
    public string player1ID;
    public string player1Name;
    public string player2Name;

    public static ButtonManager Buttons;
    public static TurnManager TurnManager;
    public static OpponentDisconnected OpponentDisconnected;

    public SocketIOComponent socket;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        socket.On("open", OnOpen);
        socket.On("error", OnError);
        socket.On("close", OnClose);
        socket.On("opponent disconnected", OnOpponentDisconnected);
        socket.On("start game", OnStartGame);
        socket.On("my turn", OnMyTurn);
    }

    /// <summary>
    /// Triggers an event when disabled
    /// </summary>
    private void OnDisable()
    {
        socket.Off("open", OnOpen);
        socket.Off("error", OnError);
        socket.Off("close", OnClose);
        socket.Off("opponent disconnected", OnOpponentDisconnected);
        socket.Off("start game", OnStartGame);
        socket.Off("my turn", OnMyTurn);
    }

    /// <summary>
    /// Log to check everything is fine
    /// </summary>
    /// <param name="e"></param>
    private void OnOpen(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
#endif
    }

    /// <summary>
    /// Log to check errors
    /// </summary>
    /// <param name="e"></param>
    private void OnError(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
#endif
    }

    /// <summary>
    /// Log to check the correct close
    /// </summary>
    /// <param name="e"></param>
    private void OnClose(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
#endif
    }

    /// <summary>
    /// When other player is disconnected closes the connection
    /// </summary>
    /// <param name="e"></param>
    private void OnOpponentDisconnected(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("Opponent Disconnected");
#endif

        socket.Close();

        //Notification on screen and stop the game
        OpponentDisconnected.ShowScreenOpponentDisconnected();
    }

    /// <summary>
    /// Sets the data on the beggining of the game
    /// </summary>
    /// <param name="e"></param>
    private void OnStartGame(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Match complete: " + e.name + " " + e.data);
#endif

        Button1 = int.Parse(e.data.GetField("button1").str);

        Button2 = int.Parse(e.data.GetField("button2").str);

        player1ID = e.data.GetField("player1Id").str;

        player1Name = e.data.GetField("player1Name").str;

        player2Name = e.data.GetField("player2Name").str;

        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
    }

    /// <summary>
    /// Checks the events on each player turn
    /// </summary>
    /// <param name="e"></param>
    private void OnMyTurn(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("My Turn, the opponent send: " + e.data.GetField("button"));
#endif
        TurnManager.ShowMyTurnText();
        var button = int.Parse(e.data.GetField("button").str);
        Buttons.DisableButton(button);
        Buttons.ButtonPressed(button);
        Buttons.CheckConditionToWin(button, false);
    }
}
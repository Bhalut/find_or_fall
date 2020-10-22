using SocketIO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviour
{
    public static int Button1;

    public static int Button2;

    public static ButtonManager buttons;

    public static TurnManager turnManager;

    public static OpponentDisconnected opponentDisconnected;

    public string player1_id;

    public SocketIOComponent socket;

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

    private void OnDisable()
    {
        socket.Off("open", OnOpen);
        socket.Off("error", OnError);
        socket.Off("close", OnClose);
        socket.Off("opponent disconnected", OnOpponentDisconnected);
        socket.Off("start game", OnStartGame);
        socket.Off("my turn", OnMyTurn);
        socket.Off("opponent username", OnOpponentUsername);
    }

    public void OnOpen(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
#endif
    }

    public void OnError(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
#endif
    }

    public void OnClose(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
#endif
    }

    public void OnOpponentDisconnected(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("Opponent Disconnected");
#endif

        socket.Close();

        opponentDisconnected.ShowScreenOpponentDisconnected();
        //Notification on screen and stop the game
    }

    private void OnStartGame(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("[SocketIO] Match complete: " + e.name + " " + e.data);
#endif

        Button1 = int.Parse(e.data.GetField("button_1").str);

        Button2 = int.Parse(e.data.GetField("button_2").str);

        player1_id = e.data.GetField("player1_id").str;

        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);

        EmitUsername();
    }

    private void OnMyTurn(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("My Turn, the opponent send: " + e.data.GetField("button"));
#endif
        var button = int.Parse(e.data.GetField("button").str);
        buttons.DisableButton(button);
        buttons.ButtonPressed(button);
        buttons.CheckConditionToWin(button);
        turnManager.ShowMyTurnText();
    }

    private void OnOpponentUsername(SocketIOEvent e)
    {
#if UNITY_EDITOR
        Debug.Log("Opponent username: " + e.data.GetField("username"));
#endif
    }

    private void EmitUsername()
    {
        var username = "name" + Random.Range(100, 999);

        socket.Emit("emit username", JSONObject.CreateStringObject(username));
    }
}
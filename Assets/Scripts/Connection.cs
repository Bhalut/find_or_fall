using SocketIO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviour
{
    public static int button1;
    
    public static int button2;
    
    public SocketIOComponent socket;
    
    public SocketFeedback socketFeedbackInstance;

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
        socketFeedbackInstance.SetSocketID(socket.sid);
    }

    public void OnError(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
    }

    public void OnClose(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
        socketFeedbackInstance.CleanData();
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

        socketFeedbackInstance.SetPlayersID(e.data.GetField("player1_id").str, e.data.GetField("player2_id").str);

        if (socket.sid == e.data.GetField("player1_id").str)
            socketFeedbackInstance.buttonSendTurn.SetActive(true);

        button1 = int.Parse(e.data.GetField("button_1").str);

        button2 = int.Parse(e.data.GetField("button_2").str);

        SceneManager.LoadSceneAsync("Scenes/Main", LoadSceneMode.Single);
        
        EmitUsername();
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
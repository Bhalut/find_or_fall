using UnityEngine;
using SocketIO;

public class EmitPlayerTurn : MonoBehaviour
{
    private Connection connection;
    [SerializeField] TurnManager turnManager;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
    }

    public void EmitTurn(string value)
	{
		connection.socket.Emit("emit turn", JSONObject.CreateStringObject(value));
        turnManager.ShowNotMyTurnText();
#if UNITY_EDITOR
		Debug.Log("Emit turn by player");
#endif
		
		//Wait for response
	}
}

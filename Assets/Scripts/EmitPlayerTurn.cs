using UnityEngine;
using SocketIO;

public class EmitPlayerTurn : MonoBehaviour
{
    private Connection connection;
    [SerializeField] TurnManager turnManager;
    [SerializeField] RandomButtons randomButtons;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
    }

    public void EmitTurn(string value)
	{
        randomButtons.ButtonPressed(int.Parse(value));
		connection.socket.Emit("emit turn", JSONObject.CreateStringObject(value));
        turnManager.ShowNotMyTurnText();
#if UNITY_EDITOR
		Debug.Log("Emit turn by player");
#endif
	}
}

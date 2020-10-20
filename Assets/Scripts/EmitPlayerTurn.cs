using UnityEngine;

public class EmitPlayerTurn : MonoBehaviour
{
    [SerializeField] private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
    }

    public void EmitTurn(string value)
	{
		connection.socket.Emit("emit turn", JSONObject.CreateStringObject(value));
#if UNITY_EDITOR
		Debug.Log("Emit turn by player");
#endif
		
		//Wait for response
	}
}

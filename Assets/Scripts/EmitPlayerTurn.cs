using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitPlayerTurn : MonoBehaviour
{
    [SerializeField] Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
    }

    public void EmitTurn(string value)
	{
		connection.socket.Emit("emit turn", JSONObject.CreateStringObject(value));
		Debug.Log("Emit turn by player");
		//Wait for response
	}
}

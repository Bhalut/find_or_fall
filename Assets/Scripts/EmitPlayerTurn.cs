using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

public class EmitPlayerTurn : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private ButtonManager randomButtons;
    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
    }

    public void EmitTurn(string value)
    {
        randomButtons.CheckConditionToWin(int.Parse(value));
        
        randomButtons.ButtonPressed(int.Parse(value));
        
        connection.socket.Emit("emit turn", JSONObject.CreateStringObject(value));
        
        turnManager.ShowNotMyTurnText();

#if UNITY_EDITOR
        Debug.Log("Emit turn by player");
#endif
    }
}
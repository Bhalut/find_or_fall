using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Contains the methods for establish each player turn
/// </summary>
public class EmitPlayerTurn : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private ButtonManager buttons;
    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
    }

    /// <summary>
    /// Emits events on player turn
    /// </summary>
    /// <param name="value"></param>
    public void EmitTurn(string value)
    {
        turnManager.ShowNotMyTurnText();

        buttons.CheckConditionToWin(int.Parse(value), true);

        buttons.ButtonPressed(int.Parse(value));

        connection.socket.Emit("emit turn", JSONObject.CreateStringObject(value));

#if UNITY_EDITOR
        Debug.Log("Emit turn by player");
#endif
    }
}
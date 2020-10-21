using UnityEngine;
using UnityEngine.UI;


#pragma warning disable 618
#pragma warning disable 649

public class RandomButtons : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
 
    [SerializeField] private GameObject gateOne;
    
    [SerializeField] private GameObject gateTwo;

	private void Start()
	{
        Connection.buttons = this;
	}

    private static void OpenGate(Behaviour collider2D)
    {
        collider2D.enabled = false;
    }

    public void ButtonPressed(int buttonPressed)
    {
        if(buttonPressed == Connection.Button1)
        {
            gateOne.GetComponent<Collider2D>().enabled = false;
        }
        else if (buttonPressed == Connection.Button2)
        {
            gateTwo.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void DisableButton(int button)
    {
        buttons[button].interactable = false;
    }
}

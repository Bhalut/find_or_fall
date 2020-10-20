using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


#pragma warning disable 618
#pragma warning disable 649

public class RandomButtons : MonoBehaviour
{
    //[SerializeField] private List<Button> buttons;

    [SerializeField] private Button[] buttons;
 
    [SerializeField] private GameObject gateOne;
    
    [SerializeField] private GameObject gateTwo;

	private void Start()
	{
        AssignButtonAction();
        Connection.buttons = this;
	}

    private void AssignButtonAction()
    {
        //foreach (var button in buttons)
        //{
        //    button.onClick.AddListener(() => DisableButton(button));
        //}

        for (int i = 0; i < buttons.Length - 1; i++)
        {
            if (i == Connection.Button1)
            {
                buttons[i].onClick.AddListener(() => OpenGate(gateOne.GetComponent<Collider2D>()));
            }

            if (i == Connection.Button2)
            {
                buttons[i].onClick.AddListener(() => OpenGate(gateTwo.GetComponent<Collider2D>()));
            }
        }

    }

    private static void OpenGate(Behaviour collider2D)
    {
        collider2D.enabled = false;
    }

    //public void DisableButton(Button button)
    //{
    //    button.interactable = false;
    //}
    public void DisableButton(int button)
    {
        buttons[button].interactable = false;
    }
}

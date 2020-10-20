using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 618
#pragma warning disable 649

public class RandomButtons : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons = new GameObject[8];
    
    [SerializeField] private GameObject gateOne;
    
    [SerializeField] private GameObject gateTwo;

	private void Start()
	{
        AssignButtonAction();
	}

    private void AssignButtonAction()
    {
        for (int i = 0; i < buttons.Length - 1; i++)
        {
            if (i == Connection.Button1)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(() => OpenGate(gateOne.GetComponent<Collider2D>()));
            }

            if (i == Connection.Button2)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(() => OpenGate(gateTwo.GetComponent<Collider2D>()));
            }
        }
    }

    private static void OpenGate(Behaviour collider2D)
    {
        collider2D.enabled = false;
    }

    public void DisableButton(int button)
    {
        buttons[button].GetComponent<Button>().interactable = false;
    }
}

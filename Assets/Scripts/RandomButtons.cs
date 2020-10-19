using UnityEngine;
using UnityEngine.UI;

public class RandomButtons : MonoBehaviour
{
    [SerializeField] GameObject[] buttons = new GameObject[8];
    [SerializeField] GameObject gate1;
    [SerializeField] GameObject gate2;

	private void Start()
	{
        AssignButtonAction();
	}

	public void AssignButtonAction()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == Connection.button1)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(OpenGate1);
            }

            if (i == Connection.button2)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(OpenGate2);
            }
        }
    }

    void OpenGate1()
    {
        gate1.GetComponent<Collider2D>().enabled = false;
    }

    void OpenGate2()
    {
        gate2.GetComponent<Collider2D>().enabled = false;
    }
}

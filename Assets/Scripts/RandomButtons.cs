using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomButtons : MonoBehaviour
{
    int button1 = 0;
    int button2 = 0;
    [SerializeField] GameObject[] buttons = new GameObject[8];
    [SerializeField] GameObject gate1;
    [SerializeField] GameObject gate2;

    // Start is called before the first frame update
    void Start()
    {
        RandomValue();
    }

    // Verifies if the random number is not taken yet
    void RandomValue()
    {
        button1 = Random.Range(0, 8);
        button2 = Random.Range(0, 8);

        while (button1 == button2)
        {
            button2 = Random.Range(0, 8);
        }
        AssignButtonAction();
    }

    void AssignButtonAction()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == button1)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(OpenGate1);
            }

            if (i == button2)
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

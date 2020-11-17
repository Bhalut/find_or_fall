using TMPro;
using UnityEngine;

public class DisplayCountdown : MonoBehaviour
{
    [SerializeField] TMP_Text countdown;
    LTDescr anim;
    Connection connection;
    [SerializeField] GameObject displayMenuButton;

	private void Start()
	{
        connection = FindObjectOfType<Connection>();
	}

	public void StartCountdown()
    {
        anim = LeanTween.value(countdown.gameObject, a => countdown.text = Mathf.CeilToInt(a).ToString(), 10, 0, 10f)
                 .setOnComplete(() => {
                     countdown.text = "your time's up!";
                     connection.socket.Close();
                     displayMenuButton.SetActive(true);
                 });
    }

    public void StopCountdown()
    {
        if (anim != null)
            LeanTween.cancel(anim.id);
        countdown.text = "";
    }
}

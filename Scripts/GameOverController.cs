using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{	
	public Text ScoreText;
	public Text TimeText;

    private void Start () 
	{
        ScoreText.text = Controller.score.ToString();

        if (Controller.minute >= 10)
        {
            if (Controller.timePlayed >= 10)
            {
                TimeText.text = Controller.minute + ": " + Controller.timePlayed;
            }
            else
            {
                TimeText.text = Controller.minute + ":0" + Controller.timePlayed;
            }
        }
        else
        {
            if (Controller.timePlayed >= 10)
            {
                TimeText.text = "0" + Controller.minute + ": " + Controller.timePlayed;
            }
            else
            {
                TimeText.text = "0" + Controller.minute + ":0" + Controller.timePlayed;
            }
        }
    }

	public void ReturnButton()
	{
        SceneManager.LoadScene("Menu");
    }
}

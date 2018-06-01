using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static GameObject player;
    public static float timePlayed;
    public static float velocity;
    public static int minute;
    public static int score;
    public static int life;

    public GameObject[] lifeUI;
    public GameObject DeathEffect;
    public GameObject PlayerModel;
    public GameObject TouchButton;
    public AudioSource CatchSound;
    public AudioSource DeathSound;
    public Text TimeText;
    public Text ScoreText;

    private bool IsGameOver = false;

    private void Start ()
	{
        timePlayed = 0;
        velocity = 10;
        minute = 0;
        score = 0;
        life = 5;
        player = gameObject;
		StartCoroutine ("GameTime");
	}

    private void Update ()
	{
        ScoreText.text = score.ToString();

        Camera.main.transform.Translate(0, 0, velocity * Time.deltaTime, Space.World);
        transform.Translate (0, 0, velocity * Time.deltaTime);

        if (life == 0)
        {
            velocity = 0;
            lifeUI[0].SetActive(false);
            DeathEffect.SetActive(true);
            TouchButton.SetActive(false);
            PlayerModel.SetActive(false);
            StartCoroutine("GameOver");
        }
        else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                RunLeft();
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                RunRight();
            }

            for (int i = 0; i < lifeUI.Length; i++)
            {
                if (i < life)
                {
                    lifeUI[i].SetActive(true);
                }
                else
                {
                    lifeUI[i].SetActive(false);
                }
            }
        }

        if (timePlayed == 60)
        {
            minute += 1;
            timePlayed = 0;
        }

        if (minute >= 10)
        {
            if(timePlayed >= 10)
            {
                TimeText.text = minute + ": " + timePlayed;
            }
            else
            {
                TimeText.text = minute + ":0" + timePlayed;
            }
        }
        else
        { 
            if (timePlayed >= 10)
            {
                TimeText.text = "0" + minute + ": " + timePlayed;
            }
            else
            {
                TimeText.text = "0" + minute + ":0" + timePlayed;
            }
        }
    }

    public void RunLeft()
    {
        if (transform.position.x > -2.4f)
        {
            transform.Translate(15 * -Time.deltaTime, 0, 0);
        }
    }

    public void RunRight()
    {
        if (transform.position.x < 2.4f)
        {
            transform.Translate(15 * Time.deltaTime, 0, 0);
        }
    }

    public void CatchObject(GameObject sphere)
    {
        Destroy(sphere);
        CatchSound.Play();
    }

    private IEnumerator GameTime()
	{
		while (life > 0)
		{
			yield return new WaitForSeconds(1);
            timePlayed += 1;
		}
	}

    private IEnumerator GameOver()
	{
		if (IsGameOver == false) 
		{
            DeathSound.Play ();
            IsGameOver = true;
		}
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("End");
	}
}
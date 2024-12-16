using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    [SerializeField]
    private GameObject gameoverPanel;
    [SerializeField]
    private GameObject victoryPanel;
    [SerializeField]
    private GameObject player;

    private bool timeStopped;

    void Start()
    {
        timeStopped = false;

        Time.timeScale = 1.0f;

        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(false);
        }
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!timeStopped)
        {
            if (remainingTime > 0)
            {

                remainingTime -= Time.deltaTime;

            }
            else if (remainingTime < 0)
            {
                GameOver();
                remainingTime = 0;
                timerText.color = Color.red;
                timeStopped = true;
            }


            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }        
    }

    public void GameOver()
    {
        if(gameoverPanel != null)
        {
            gameoverPanel.SetActive(true);
            player.GetComponent<PlayerMovement>().OnDialogueStart();
            Invoke("ToMainMenu", 3.0f);
        }
    }

    public void Victory()
    {
        if (victoryPanel != null)
        {
            timeStopped = true;
            victoryPanel.SetActive(true);
            player.GetComponent<PlayerMovement>().OnDialogueStart();
            Invoke("ToMainMenu", 5.0f);
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void MainGame()
    {
        SceneManager.LoadScene("MainScene");
    }

       public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


      public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

      public void Exit()
    {
        Application.Quit();
    }
}
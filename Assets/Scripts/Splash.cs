using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("ToMenu", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

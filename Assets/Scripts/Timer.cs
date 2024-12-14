using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
   
    void Start()
    {
        
    }

    void Update()
    {
        if(remainingTime > 0){

            remainingTime -= Time.deltaTime;  

        }else if(remainingTime < 0){
            //GameOver();
            remainingTime = 0;
            timerText.color =  Color.red;
        }

       
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt (remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController SharedInstance;

    public int timeLeft = 30;
    public Text scoreLabel;
    public Text timerLabel;
	private int currentScore = 0;

    void Start ()
    {
        StartCoroutine(CountDown());
        Time.timeScale = 1;
    }
    
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit(); 
        }
        if( timeLeft >= 0 )
        {
            timerLabel.text = ("00:" + timeLeft.ToString().PadLeft(2,'0'));
        }
        if(timeLeft == 0)
        {
            Time.timeScale = 0f;
            AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject javaObject = javaClass.GetStatic<AndroidJavaObject>("currentActivity");
            javaObject.Call("onGameEnded",currentScore);
        }
        
    }
    
    IEnumerator CountDown()
    {
        while (true) 
        {
            yield return new WaitForSeconds (1);
            timeLeft--; 
        }
    }
    
    void Awake () 
    {
		SharedInstance = this;
	}

    public void IncrementScore(int increment) 
    {
        currentScore += increment;
        scoreLabel.text = currentScore.ToString().PadLeft(3,'0');
	}
}

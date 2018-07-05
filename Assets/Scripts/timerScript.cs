using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerScript : MonoBehaviour {
    
    public GameObject timeText;

    public System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    public long currentTime;

    private long lastSavedTime;

    public long fastestTimeScore;

    public long finalRunTime;

    [SerializeField]
    private GameObject optionsScreen;
	
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        fastestTimeScore = ArrayPrefs2.GetLong("highScoreTime");
        lastSavedTime = ArrayPrefs2.GetLong("savedTime");
    }

    private void Start()
    {
        timeText.GetComponent<TextMeshProUGUI>().SetText("Time: " + currentTime / 1000);
        stopWatch.Start();
    }

    void Update()
    {
        if (timeText == null || optionsScreen == null)
        {
            Destroy(this.gameObject);
        }
        if(optionsScreen == null)
        {
            optionsScreen = GameObject.FindGameObjectWithTag("OptionsMenu");
        }
        if (timeText == null)
        {
            timeText = GameObject.FindGameObjectWithTag("TheTimerText");
        }
        currentTime = stopWatch.ElapsedMilliseconds + lastSavedTime;
        if(timeText != null)
        {
            timeText.GetComponent<TextMeshProUGUI>().SetText("Time: " + currentTime / 1000);
        }
        if (Input.GetButtonDown("Restart"))
        {
            ArrayPrefs2.SetLong("savedTime", currentTime);
            stopWatch.Start();
        }
        if(finalRunTime > 0)
        {
            ArrayPrefs2.SetLong("finalCurrentRunTime", finalRunTime);
        }
        if(finalRunTime <= ArrayPrefs2.GetLong("highScoreTime") || 
           ArrayPrefs2.GetLong("highScoreTime") <= 0)
        {
            ArrayPrefs2.SetLong("highScoreTime", finalRunTime);
        }
    }

}

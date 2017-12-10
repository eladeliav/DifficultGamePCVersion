using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerScript : MonoBehaviour {
    
    public GameObject timeText;

    public System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    public long currentTime;

    private long lastSavedTime;

    [SerializeField]
    private GameObject optionsScreen;
	
    private void Awake()
    {
        UnityEngine.Debug.Log(PlayerPrefs.GetString("savedTime"));

        long.TryParse(PlayerPrefs.GetString("savedTime"), out lastSavedTime);
        UnityEngine.Debug.Log(lastSavedTime);
    }

    private void Start()
    {

        timeText.GetComponent<TextMeshProUGUI>().SetText("Time: " + currentTime / 1000);
        stopWatch.Start();
    }

    void Update()
    {
        currentTime = stopWatch.ElapsedMilliseconds + lastSavedTime;
        timeText.GetComponent<TextMeshProUGUI>().SetText("Time: " + currentTime / 1000);
        if (Input.GetButtonDown("Restart"))
        {
            PlayerPrefs.SetString("savedTime", currentTime.ToString());
        }
        if (Input.GetButtonDown("Cancel") && optionsScreen.active == false)
        {
            stopWatch.Stop();
        }
    }

}

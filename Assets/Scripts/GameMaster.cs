using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;

public class GameMaster : MonoBehaviour {

    public GameObject theFinishLine;

    public GameObject pauseScreen;

    public GameObject optionsScreen;

    public GameObject theTimer;


    private void Start()
    {
        if (theTimer == null)
        {
            theTimer = GameObject.FindGameObjectWithTag("TheTimer");
        }

        // = PlayerPrefs.GetString("savedTime");
        if (theFinishLine == null)
        {
            theFinishLine = GameObject.FindGameObjectWithTag("FinishLine");
        }
    }

    // Update is called once per frame
    void Update () {
        if (theTimer == null)
        {
            theTimer = GameObject.FindGameObjectWithTag("TheTimer");
        }
        if (theFinishLine == null)
        {
            theFinishLine = GameObject.FindGameObjectWithTag("FinishLine");
            if(theFinishLine == null)
            {
                theFinishLine = GameObject.Find("invisFinishLine");
            }
        }
        if (Input.GetButtonDown("Restart"))
        {
            restartLevel();
        }
        if (theFinishLine.GetComponent<finishLine>().didBeatLevel && Input.GetButtonDown("Jump"))
        {
            loadNextLevel();
        }
        if (Input.GetButtonDown("Cancel") && optionsScreen.active == false)
        {
            Toggle();
        }
	}

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadNextLevel()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) > SceneManager.sceneCountInBuildSettings)
        {

            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        theTimer.GetComponent<timerScript>().stopWatch.Start();
    }

    public void Toggle()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);

        if (pauseScreen.activeSelf)
        {
            Time.timeScale = 0f;
            theTimer.GetComponent<timerScript>().stopWatch.Stop();
        }else
        {
            Time.timeScale = 1f;
            theTimer.GetComponent<timerScript>().stopWatch.Start();
        }
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

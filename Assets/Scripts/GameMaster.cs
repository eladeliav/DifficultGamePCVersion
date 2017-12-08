using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public GameObject theFinishLine;

    public GameObject pauseScreen;

    public GameObject optionsScreen;

    private void Start()
    {
        if (theFinishLine == null)
        {
            theFinishLine = GameObject.FindGameObjectWithTag("FinishLine");
        }
    }

    // Update is called once per frame
    void Update () {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Toggle()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);

        if (pauseScreen.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour {

    private int currentProgressLevel;

    public bool playedBefore;

    private void Awake()
    {
        playedBefore = ArrayPrefs2.GetBool("PlayedBefore");
        if(playedBefore == false)
        {
            playedBefore = true;
            ArrayPrefs2.SetBool("PlayedBefore", true);
            ResetProgress();
        }
        currentProgressLevel = PlayerPrefs.GetInt("CurrentLevelProgress");
    }

    public void startGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentProgressLevel);
    }

    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void ResetProgress(){
        PlayerPrefs.SetInt("CurrentLevelProgress",1);
        ArrayPrefs2.SetLong("finalCurrentRunTime", 0);
        PlayerPrefs.SetInt("TotalDeaths",0);
        ArrayPrefs2.SetLong("savedTime", 0);
        currentProgressLevel = PlayerPrefs.GetInt("CurrentLevelProgress");
    }

    public void toScorePage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

}

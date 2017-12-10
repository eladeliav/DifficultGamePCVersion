using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour {

    private int currentProgressLevel;

    private void Awake()
    {
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
        PlayerPrefs.SetInt("TotalDeaths",0);
        currentProgressLevel = PlayerPrefs.GetInt("CurrentLevelProgress");
    }

}

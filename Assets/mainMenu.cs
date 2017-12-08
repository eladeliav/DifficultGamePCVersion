using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour {

	public void startGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}

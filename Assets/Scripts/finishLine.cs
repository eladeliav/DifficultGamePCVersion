using UnityEngine.SceneManagement;
using UnityEngine;

public class finishLine : MonoBehaviour {

    public bool didBeatLevel = false;

    public int currentProgressLevel;

    private void Awake()
    {
        currentProgressLevel = PlayerPrefs.GetInt("CurrentLevelProgress");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().beatCurrentLevel();
            didBeatLevel = true;
            if ((SceneManager.GetActiveScene().buildIndex + 1) >= SceneManager.sceneCountInBuildSettings)
            {
                currentProgressLevel = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("CurrentLevelProgress", currentProgressLevel);
            }else
            {
                currentProgressLevel = SceneManager.GetActiveScene().buildIndex + 1;
                PlayerPrefs.SetInt("CurrentLevelProgress", currentProgressLevel);
            }
                

        }
    }

}

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
            currentProgressLevel = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("CurrentLevelProgress",currentProgressLevel);
        }
    }

}

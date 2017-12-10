using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject deathParticles;

    public GameObject gameOverScreen;

    public GameObject winScreen;

    private AudioManager audioM;

    public GameObject deathsCounter;

    public GameObject theTimer;

    [SerializeField]
    private GameObject gameMaster;

    // Use this for initialization
    void Start () {
        if (theTimer == null)
        {
            theTimer = GameObject.FindGameObjectWithTag("TheTimer");
        }
        if(deathsCounter == null){
            Debug.Log("don't have a deaths counter set on " + gameObject.name);
        }

		if(deathParticles == null)
        {
            Debug.LogWarning("no death particles for player");
        }
        if (gameOverScreen == null)
        {
            Debug.LogWarning("no game over screen for player script");
        }
        if(gameMaster != null)
        {
            audioM = gameMaster.GetComponent<AudioManager>();
        }else
        {
            Debug.LogWarning("no game master object set to palyer script");
        }
    }

    private void Update()
    {
        if (theTimer == null)
        {
            theTimer = GameObject.FindGameObjectWithTag("TheTimer");
        }
    }

    public void GameOver()
    {
        theTimer.GetComponent<timerScript>().stopWatch.Stop();
        Debug.Log("Game Over");
        GetComponent<SpriteRenderer>().enabled = false;
        audioM.PlaySound("Explosion");
        Transform newParticles = Instantiate(deathParticles.transform, transform.position, Quaternion.identity);
        Destroy(newParticles.gameObject, 3f);
        Destroy(this.gameObject);
        deathsCounter.GetComponent<DeathsCounter>().addToTotalDeaths();
        gameOverScreen.SetActive(true);
    }

    public void beatCurrentLevel()
    {
        theTimer.GetComponent<timerScript>().stopWatch.Stop();
        ArrayPrefs2.SetLong("savedTime",theTimer.GetComponent<timerScript>().currentTime);
        Debug.Log("Beat Level");
        GetComponent<SpriteRenderer>().enabled = false;
        audioM.PlaySound("Explosion");
        Transform newParticles = Instantiate(deathParticles.transform, transform.position, Quaternion.identity);
        Destroy(newParticles.gameObject, 3f);
        Destroy(this.gameObject);
        winScreen.SetActive(true);
        if ((SceneManager.GetActiveScene().buildIndex + 1) >= SceneManager.sceneCountInBuildSettings - 1)
        {
            theTimer.GetComponent<timerScript>().stopWatch.Stop();
            theTimer.GetComponent<timerScript>().finalRunTime = theTimer.GetComponent<timerScript>().currentTime;
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject deathParticles;

    public GameObject gameOverScreen;

    public GameObject winScreen;

    private AudioManager audioM;

    [SerializeField]
    private GameObject gameMaster;

    // Use this for initialization
    void Start () {
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

    public void GameOver()
    {
        Debug.Log("Game Over");

        GetComponent<SpriteRenderer>().enabled = false;
        audioM.PlaySound("Explosion");
        Transform newParticles = Instantiate(deathParticles.transform, transform.position, Quaternion.identity);
        Destroy(newParticles.gameObject, 3f);
        Destroy(this.gameObject);

        gameOverScreen.SetActive(true);
    }

    public void beatCurrentLevel()
    {
        Debug.Log("Beat Level");

        GetComponent<SpriteRenderer>().enabled = false;
        audioM.PlaySound("Explosion");
        Transform newParticles = Instantiate(deathParticles.transform, transform.position, Quaternion.identity);
        Destroy(newParticles.gameObject, 3f);
        Destroy(this.gameObject);
        winScreen.SetActive(true);
    }

}

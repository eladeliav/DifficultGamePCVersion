using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scoresPage : MonoBehaviour {

    public GameObject playerCurrentScoreText;

    public GameObject highScoreText;

    // Use this for initialization
    void Start () {
        playerCurrentScoreText.GetComponent<TextMeshProUGUI>().SetText(" Time: " + (ArrayPrefs2.GetLong("finalCurrentRunTime")/1000));
        highScoreText.GetComponent<TextMeshProUGUI>().SetText("Time " + (ArrayPrefs2.GetLong("highScoreTime") / 1000));
	}
	
	public void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}

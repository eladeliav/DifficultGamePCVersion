using UnityEngine;
using TMPro;

public class DeathsCounter : MonoBehaviour {
    private TextMeshProUGUI deathCounter;

    public int numOfDeaths;

    private void Awake()
    {
        deathCounter = this.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        numOfDeaths = PlayerPrefs.GetInt("TotalDeaths");
        deathCounter.SetText("TOTAL DEATHS: " + numOfDeaths);
    }

    private void Update()
    {
        numOfDeaths = PlayerPrefs.GetInt("TotalDeaths");
        deathCounter.SetText("TOTAL DEATHS: " + numOfDeaths);
    }

    public void addToTotalDeaths(){
        PlayerPrefs.SetInt("TotalDeaths",PlayerPrefs.GetInt("TotalDeaths") + 1);
        numOfDeaths = PlayerPrefs.GetInt("TotalDeaths");
    }

}

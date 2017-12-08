using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public GameObject theFinishLine;

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
	}

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}

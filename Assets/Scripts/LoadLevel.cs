using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    [SerializeField]
    GameObject updateText;

    public void loadLevel(int sceneIndex)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (updateText != null)
        {
            updateText.SetActive(false);
        }
        Time.timeScale = 1;
        //GameMaster.RemainingLives = 3;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        if(loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            if (slider != null)
            {
                slider.value = progress;
            }
            if (progressText != null)
            {
                progressText.text = Mathf.Round(slider.value * 100) + "%";
            }
            yield return null;
        }
    }
}

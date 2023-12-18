using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    GameObject highscoreText;
    private void Start()
    {
        highscoreText = GameObject.Find("HighScore");
        highscoreText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameController gameCont = GameObject.Find("GameController").GetComponent<GameController>();
        
        if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))//FIRST TIME
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, gameCont.timer);
            highscoreText.SetActive(true);
            highscoreText.GetComponent<TextMeshProUGUI>().text = "New HighScore: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name).ToString("00:00");
        }
        else
        {
            if (gameCont.timer < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name))//NEW HIGHSCORE
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, gameCont.timer);
                
                highscoreText.SetActive(true);
                highscoreText.GetComponent<TextMeshProUGUI>().text = "New HighScore: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name).ToString("00:00");
            }
                

            gameCont.Win();
        }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name) == 0)
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, 9999f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameController.Instance.timer < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name))
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, GameController.Instance.timer);
        GameController.Instance.Win();
    }
}

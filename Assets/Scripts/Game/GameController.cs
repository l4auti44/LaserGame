using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject pauseMenu;
    [HideInInspector] public static GameController Instance;
    [HideInInspector] public bool isPaused = false;
    public float timer;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

       
    }
    private void Start()
    {
        
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //GENERAL TIMER
        timer += Time.deltaTime;


        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TriggerPause();
        }   
    }

    public void TriggerPause()
    {
        pauseMenu.transform.GetChild(2).gameObject.SetActive(true);
        pauseMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "GAME PAUSED";
        if (Time.timeScale == 0)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Die()
    {
        TriggerPause();
        if (pauseMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>())
        {
            pauseMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "YOU DIED";
        }
        pauseMenu.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void QuitToMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Destroy(CanvasController.Instance.gameObject);
        Destroy(this.gameObject);

    }

    public void Win()
    {
        TriggerPause();
        pauseMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "YOU WIN!";
        pauseMenu.transform.GetChild(2).gameObject.SetActive(false);
    }
}

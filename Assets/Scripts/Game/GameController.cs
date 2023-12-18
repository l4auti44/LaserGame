
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private GameObject pauseMenu;
    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public float timer;
    private Slider sensibility, fov, music;

    [HideInInspector] public GameObject player;
    private CinemachineVirtualCamera virtualCamera;
    private AudioSource audioSource;
    private TextMeshProUGUI sensNum, fovNum, musicNum;
    // Start is called before the first frame update

    private void Start()
    {
        player = GameObject.Find("Player");
        virtualCamera = GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>();
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();

        pauseMenu = GameObject.Find("PauseMenu");
        music = pauseMenu.transform.Find("Music").GetComponent<Slider>();
        fov = pauseMenu.transform.Find("Fov").GetComponent<Slider>();
        sensibility = pauseMenu.transform.Find("Sensibility").GetComponent<Slider>();
        sensNum = pauseMenu.transform.Find("Sensibility Number").GetComponent<TextMeshProUGUI>();
        fovNum = pauseMenu.transform.Find("Fov Number").GetComponent<TextMeshProUGUI>();
        musicNum = pauseMenu.transform.Find("Music Number").GetComponent<TextMeshProUGUI>();


        
        if (PlayerPrefs.GetFloat("sensibility") == 0)
        {
            PlayerPrefs.SetFloat("sensibility", player.GetComponent<FirstPersonController>().RotationSpeed);
        }
        else
        {
            player.GetComponent<FirstPersonController>().RotationSpeed = PlayerPrefs.GetFloat("sensibility");
        }
        sensibility.value = player.GetComponent<FirstPersonController>().RotationSpeed;
        sensNum.text = sensibility.value.ToString("00.0");
        
        if (PlayerPrefs.GetFloat("fov") == 0)
        {
            PlayerPrefs.SetFloat("fov", virtualCamera.m_Lens.FieldOfView);
        }
        else
        {
            virtualCamera.m_Lens.FieldOfView = PlayerPrefs.GetFloat("fov");
        }
        fov.value = virtualCamera.m_Lens.FieldOfView;
        fovNum.text = fov.value.ToString("00.0");

        audioSource.volume = PlayerPrefs.GetFloat("music");
        
        music.value = audioSource.volume;
        musicNum.text = (music.value * 100).ToString("000");

        
        pauseMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageSliders();
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


    private void ManageSliders()
    {

        player.GetComponent<FirstPersonController>().RotationSpeed = sensibility.value;
        virtualCamera.m_Lens.FieldOfView = fov.value;
        audioSource.volume = music.value;
        PlayerPrefs.SetFloat("sensibility", player.GetComponent<FirstPersonController>().RotationSpeed);
        PlayerPrefs.SetFloat("fov", virtualCamera.m_Lens.FieldOfView = fov.value);
        PlayerPrefs.SetFloat("music", audioSource.volume);
        fovNum.text = fov.value.ToString("00.0");
        sensNum.text = sensibility.value.ToString("00.0");
        musicNum.text = (music.value * 100).ToString("000");
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


    }



    public void Win()
    {
        TriggerPause();
        pauseMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "YOU WIN!";
        pauseMenu.transform.GetChild(2).gameObject.SetActive(false);
    }


}

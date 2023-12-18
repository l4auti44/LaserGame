using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigurationManager : MonoBehaviour
{
    [SerializeField] private Slider music;
    [SerializeField] private Slider fov;
    [SerializeField] private Slider sensibility;
    [SerializeField] private AudioSource audio;
    [SerializeField] private TextMeshProUGUI sensNum;
    [SerializeField] private TextMeshProUGUI fovNum;
    [SerializeField] private TextMeshProUGUI musicNum;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetFloat("music", 0.7f);
        }
        music.value = PlayerPrefs.GetFloat("music");
        if (!PlayerPrefs.HasKey("fov"))
        {
            PlayerPrefs.SetFloat("fov", 60f);
        }
        fov.value = PlayerPrefs.GetFloat("fov");
        if (!PlayerPrefs.HasKey("sensibility"))
        {
            PlayerPrefs.SetFloat("sensibility", 3f);
        }
        sensibility.value = PlayerPrefs.GetFloat("sensibility");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("music", music.value);
        audio.volume = music.value;
        PlayerPrefs.SetFloat("fov", fov.value);
        PlayerPrefs.SetFloat("sensibility", sensibility.value);
        musicNum.text = (PlayerPrefs.GetFloat("music") * 100).ToString("00");
        fovNum.text = PlayerPrefs.GetFloat("fov").ToString("00.0");
        sensNum.text = PlayerPrefs.GetFloat("sensibility").ToString("00.0");
    }
}

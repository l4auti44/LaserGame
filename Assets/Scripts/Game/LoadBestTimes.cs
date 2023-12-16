using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadBestTimes : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level1;
    [SerializeField] private TextMeshProUGUI level2;
    [SerializeField] private TextMeshProUGUI level3;

    private void Start()
    {
        float text1 = PlayerPrefs.GetFloat("Level 1");
        level1.text = PlayerPrefs.GetFloat("Level 1").ToString("00:00");
        level2.text = PlayerPrefs.GetFloat("Level 2").ToString("00:00");
        level3.text = PlayerPrefs.GetFloat("Level 3").ToString("00:00");
    }
}
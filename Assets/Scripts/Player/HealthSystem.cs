using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private  bool DEBUG = false;
    [SerializeField] private  float playerHealth = 100f;
    private  Slider healthBar;
    private bool isTakingDamage = false;
    [SerializeField] private float invincibilityTime = 1f;
    private float _invicibilityTime;
    public static HealthSystem instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    
    public void TakeDamage(float damage)
    {
        if (!isTakingDamage)
        {
            if (DEBUG) Debug.Log("taking damage");
            playerHealth -= damage;
            isTakingDamage = true;
            UpdateText();
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                UpdateText();
                Die();
            }
        }
    }
    
    public void Heal(float amount)
    {
        playerHealth += amount;
        UpdateText();
    }
    
    private void Die()
    {
        if (DEBUG) Debug.Log("Player Died!");

    }

    private void UpdateText()
    {
        healthBar.value = (playerHealth/100f);
    }

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        _invicibilityTime = invincibilityTime;
    }
    private void Update()
    {
        if (isTakingDamage)
        {
            _invicibilityTime -= Time.deltaTime;
            if (_invicibilityTime <= 0)
            {
                isTakingDamage = false;
                _invicibilityTime = invincibilityTime;
            }
        }
    }
}

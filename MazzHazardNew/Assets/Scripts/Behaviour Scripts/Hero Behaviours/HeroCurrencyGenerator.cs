using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCurrencyGenerator : MonoBehaviour
{
    [SerializeField] private AudioSource pingEffect;

    public CurrencySystem currencySystem;

    private HealthController healthController;
    public float addedCooldownTime;
    public float removedCooldownTime;



    //public Animator anim;

    private void Start()
    {
        healthController = GetComponent<HealthController>();
        currencySystem = GameObject.Find("Hero Selection").GetComponent<CurrencySystem>();
    }


    private void Update()
    {

        var currentHealth = healthController.currentHealth;

        if (currentHealth > 0) 
        { 
            currencySystem.DecreaseCooldown(removedCooldownTime);
        }

        if (currentHealth <= 0) 
        {
            currencySystem.IncreaseCooldown(addedCooldownTime);
        }

    }


}

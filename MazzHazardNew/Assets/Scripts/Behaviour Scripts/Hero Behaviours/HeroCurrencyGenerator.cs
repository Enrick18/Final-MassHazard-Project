using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCurrencyGenerator : MonoBehaviour
{
    [SerializeField] AudioSource generateEffect;
    public CurrencySystem currencySystem;

    private HealthController healthController;
    public float addedCooldownTime;
    public float removedCooldownTime;

    public float timeBetweenCapsules;
    [SerializeField]private float generateCounter = 8;

    public int amount;



    //public Animator anim;

    private void Start()
    {
        healthController = GetComponent<HealthController>();
        currencySystem = GameObject.Find("Hero Selection").GetComponent<CurrencySystem>();
    }


    private void Update()
    {
        var currentHealth = healthController.currentHealth;

        generateCounter -= Time.deltaTime;

        if (generateCounter <= 0) 
        {
            generateEffect.Play();
            generateCounter = timeBetweenCapsules;
            Debug.Log("Yes");
            currencySystem.GainCurrency(amount);
        }

        if (currentHealth <= 0) 
        {
            currencySystem.IncreaseCooldown(addedCooldownTime);
        }

    }


}

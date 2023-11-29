using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    //currency Text UI
    public Text txtCurrency;
    //default currency value
    public int defaultCurency;
    //current currency value
    public int currentCurrency;

    public float cooldownCounter = 2.5f;
    public float cooldownReset;
    
    [SerializeField]public int currencyRegenAmount = 1;

    int maxCurrency = 99;

    //Methods
    //Init (Set def values)
    public void Awake()
    {
        currentCurrency = defaultCurency;
        UpdateUi();
    }

    private void Start() {
        cooldownReset = cooldownCounter;
    }

    private void Update() {

        cooldownCounter -= Time.deltaTime;

        if (currentCurrency > maxCurrency)
        {
            currentCurrency = maxCurrency;
        }

        

        if (cooldownCounter <= 0)
        {
            CurrencyIncome();
            cooldownCounter = cooldownReset;
        }


    }

    public void IncreaseCooldown(float cooldownIncrement) 
    {
        cooldownCounter += cooldownIncrement;
        cooldownReset = cooldownCounter;
    }

    public void DecreaseCooldown(float cooldownDecrement) 
    {
        cooldownCounter -= cooldownDecrement;
        cooldownReset = cooldownCounter;
    }

    void CurrencyIncome()
    {
        GainCurrency(currencyRegenAmount);
    }
    //Gain Currency (input value)
    public void GainCurrency(int val)
    {
        currentCurrency+=val;
        UpdateUi();
    }
    //Lose Currency (input value)
    public void UseCurrency(int val)
    { 
        currentCurrency-=val;
        UpdateUi();
    }
    //Check availability of currency
    public bool EnoughCurrency(int val)
    {
        //check if the val is equal or less than currency
        if(val<=currentCurrency)
        {
            return true;
        }
        else{
            Debug.Log("Try again");
            return false;
        }
    }
    //Update text ui
    void UpdateUi()
    {
        txtCurrency.text = currentCurrency.ToString();
    }

}

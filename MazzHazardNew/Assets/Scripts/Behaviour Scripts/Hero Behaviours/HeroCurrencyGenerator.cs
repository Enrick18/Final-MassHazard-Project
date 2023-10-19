using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCurrencyGenerator : MonoBehaviour
{
    public CurrencySystem currencySystem;
    //Income value
    public int incomeValue;
    //Interval of income
    public float incomeInterval;
    private float incomeCounter;

    bool isCooldown = true;

    // public Button myButton;

    public Animator anim;

    private void Start()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isGenerating", false);
    }

    public void IncomeIncrease()
    {
        currencySystem.GainCurrency(incomeValue);
    }

    private void Update()
    {
        
        incomeCounter -= Time.deltaTime;

        if (isCooldown)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isGenerating", false);
        }
        else
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isGenerating", true);
        }

        if(incomeCounter<=0)
        {
            IncomeIncrease();
            incomeCounter = incomeInterval;
        }

    }

    // IEnumerator IncomeCoolDownCoroutine()
    // {  
    //     isCooldown = false;
    //     Debug.Log("Generating");
    //     IncomeIncrease();
    //     yield return new WaitForSeconds(incomeInterval);

    // }

    // IEnumerator CooldownCoroutine()
    // {
    //     yield return new WaitForSeconds(incomeInterval);
    //     isCooldown = false;
    //     myButton.interactable = true;
    //     anim.SetBool("isIdle", true);
    //     anim.SetBool("isGenerating", false);
    // }

    // public void ButtonClicked()
    // {
    //     if (isCooldown)
    //     {
    //         return;
    //     }
    //     else
    //     {

    //         isCooldown = true;
    //         myButton.interactable = false;
    //         StartCoroutine(CooldownCoroutine());
    //         anim.SetBool("isIdle", false);
    //         anim.SetBool("isGenerating", true);
    //         IncomeIncrease();
    //     }
    // }

}

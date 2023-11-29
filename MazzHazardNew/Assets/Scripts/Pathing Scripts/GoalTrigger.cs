using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]private EnemyCounter enemyCounter;
    [SerializeField]private GameObject gameOverUi;
    [SerializeField] private Text lifeCountText;

    public int maxLife;
    public int currentLife;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start() 
    {
        lifeCountText = GameObject.Find("HealthText").GetComponent<Text>();
        gameOverUi = GameObject.Find("GameOverUi");
        enemyCounter = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>();
        currentLife = maxLife;
        lifeCountText.text = currentLife.ToString();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            audioManager.PlaySFX(audioManager.enterGoal);
            Destroy(other.gameObject);
            Debug.Log("Destroyed");
            LoseHealth();
            enemyCounter.DecreaseEnemy();
        }    
    }

    private void LoseHealth()
    {
        if(currentLife<1)//For Sanity Check only
            return;

        currentLife--;
        lifeCountText.text = currentLife.ToString(); 
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(currentLife<1)
        {
            gameOverUi.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

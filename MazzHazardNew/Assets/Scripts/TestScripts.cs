using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    public float cooldown = 10f;
    public float reset;
    // Start is called before the first frame update
    void Start()
    {
        reset = cooldown;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0) 
        { 
            TestCooldown();

            cooldown = reset;
        }
    }


    void TestCooldown() 
    {
        Debug.Log("Yo");
    }
}

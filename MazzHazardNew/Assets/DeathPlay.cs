using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlay : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isDead", true);
        Invoke(nameof(CancelDeath), 0.1f);
    }

    public void CancelDeath() 
    {
        anim.SetBool("isDead", false);
    }

}

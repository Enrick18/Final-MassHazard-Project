using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEvent : MonoBehaviour
{
    public static event Action OnAttackStartAnimation;
    public static event Action OnAttackEndAnimation;

    public void AttackStart() 
    {
        Debug.Log("AttackStart");
        OnAttackStartAnimation?.Invoke();    
    }

    public void AttackEnd() 
    {
        Debug.Log("AttackEnd");
        OnAttackEndAnimation?.Invoke();
    }
}

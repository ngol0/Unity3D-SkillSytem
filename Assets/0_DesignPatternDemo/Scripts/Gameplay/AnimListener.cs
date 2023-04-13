using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimListener : MonoBehaviour
{
    System.Action onAttack;
    System.Action onDoneAnim;
    public void SetAttackEffect(System.Action attackEffect)
    {
        onAttack = attackEffect;
    }

    public void SetOnDoneAnimAction(System.Action onDone)
    {
        onDoneAnim = onDone;
    }
    
    public void OnAttack()
    {
        onAttack?.Invoke();
    }

    public void OnDoneAnim()
    {
        onDoneAnim?.Invoke();
    }
}

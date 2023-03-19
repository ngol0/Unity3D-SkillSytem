using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimListener : MonoBehaviour
{
    System.Action action;
    public void SetAction(System.Action OnNextMove)
    {
        action = OnNextMove;
    }
    
    public void OnJumpSlash()
    {
        action();
    }
}

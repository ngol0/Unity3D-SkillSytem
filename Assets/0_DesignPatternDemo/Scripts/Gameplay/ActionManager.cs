using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    IAction curAction;
    public void StartAction(IAction action)
    {
        if (curAction == action) return;
        if (curAction != null) { curAction.Cancel();}
            
        curAction = action;
        //Debug.Log(":::starting action: " + curAction);
    }

    public void CancelAction(IAction action)
    {
        StartAction(null);
    }
}

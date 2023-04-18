using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : IAction
{
    public GameObject user;
    public IEnumerable<GameObject> targets;
    public Vector3 targetedPoint;
    private bool isCanceled = false;
    public bool IsCanceled => isCanceled;

    public SkillData(GameObject user)
    {
        this.user = user;
    }

    public Animator GetUserAnim()
    {
        return user.GetComponent<PlayerController>().Anim;
    }

    public void Cancel()
    {
        isCanceled = true;
    }

    public void StartingCoroutine(IEnumerator coroutineToStart)
    {
        user.GetComponent<MonoBehaviour>().StartCoroutine(coroutineToStart);
    }
}

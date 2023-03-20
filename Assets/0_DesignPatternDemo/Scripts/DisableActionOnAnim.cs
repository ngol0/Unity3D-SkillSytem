using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DisableActionOnAnim", menuName = "Skill/Effect/DisableActionOnAnim")]
public class DisableActionOnAnim : IEffect
{
    Animator anim;
    public IEffect effectToDecorate;
    public override void ApplyEffect(SkillData data, Action OnComplete = null)
    {
        data.user.GetComponent<PlayerController>().enabled = false;
        effectToDecorate.ApplyEffect(data);
        
        anim = data.user.GetComponent<PlayerController>().Anim;
        anim.GetComponent<AnimListener>().SetOnDoneAnimAction
            (() => EnablePlayerController(data, OnComplete));
    }

    private void EnablePlayerController(SkillData data, Action OnComplete = null)
    {
        data.user.GetComponent<PlayerController>().enabled = true;
    }
}

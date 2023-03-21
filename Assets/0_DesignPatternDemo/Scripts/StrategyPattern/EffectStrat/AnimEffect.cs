using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimEffect", menuName = "Skill/Effect/AnimEffect")]
public class AnimEffect : IEffect
{
    Animator anim;
    [SerializeField] public string triggerAnimaName;
    public override void ApplyEffect(SkillData data, Action OnComplete)
    {
        anim = data.GetUserAnim();
        anim.SetTrigger(triggerAnimaName);

        OnComplete?.Invoke();
    }
}

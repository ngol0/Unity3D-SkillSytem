using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriggerActionAnimEffect", menuName = "Skill/Effect/TriggerActionAnimEffect")]
public class TriggerActionAnimEffect : IEffect
{
    Animator anim;
    public IEffect[] effects;

    public override void ApplyEffect(SkillData data, Action OnComplete)
    {
        anim = data.user.GetComponent<PlayerController>().Anim;
        anim.GetComponent<AnimListener>().SetAction(() => TriggerEffect(data, OnComplete));
    }

    void TriggerEffect(SkillData data, Action OnComplete)
    {
        foreach (var effect in effects)
        {
            effect.ApplyEffect(data, () => OnDoneCompositeEffect(effect.name));
        }
        OnComplete?.Invoke();
    }

    void OnDoneCompositeEffect(string name ="")
    {
        Debug.Log(":::Complete effect " + name);
    }
}

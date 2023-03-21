using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DisableAnim", menuName = "Skill/Effect/DisableAnim")]
public class DisableAnim : IEffect
{
    public IEffect effect;
    Animator anim;
    public override void ApplyEffect(SkillData data, Action OnComplete = null)
    {
        effect.ApplyEffect(data);
        anim = data.GetUserAnim();
        var animToDisable = effect as AnimEffect;
        data.StartingCoroutine(CancelAnimWhenClick(animToDisable, data));
    }

    private IEnumerator CancelAnimWhenClick(AnimEffect animToDisable, SkillData data)
    {
        while (true)
        {
            if (data.IsCanceled)
            {
                anim.ResetTrigger(animToDisable.triggerAnimaName);
                anim.SetTrigger("stopAttack");

                yield break;
            }
            yield return null;
        }
    }
}

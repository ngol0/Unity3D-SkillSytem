using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LookAtEffect", menuName = "Skill/Effect/LookAtEffect")]
public class LookAtTargetEffect : IEffect
{
    public override void ApplyEffect(SkillData data, Action OnComplete)
    {
        data.user.transform.LookAt(data.clickPoint);

        OnComplete?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthEffect", menuName = "Skill/Effect/HealthEffect")]
public class HealthDamageEffect : IEffect
{
    public override void ApplyEffect(SkillData data, Action onComplete)
    {
        foreach (var target in data.targets)
        {
            //target.GetComponent<Health>();
            Debug.Log(data.user.name + "has attacked " + target.name);
        }

        onComplete?.Invoke();
    }
}

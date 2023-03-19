using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlastEffect", menuName = "Skill/Effect/BlastEffect")]
public class BlastEffect : IEffect
{
    [SerializeField] Transform effectPrefab;

    public override void ApplyEffect(SkillData data, Action OnComplete)
    {
        var effect = Instantiate(effectPrefab, data.clickPoint, Quaternion.identity);
        if (OnComplete!= null) effect.GetComponent<StopParticleSystem>().SetAction(OnComplete);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SequenceEffect", menuName = "Skill/Effect/SequenceEffect")]
public class SequenceEffect : IEffect
{
    public IEffect[] effects;

    Queue<IEffect> effectQueue = new Queue<IEffect>();

    public override void ApplyEffect(SkillData data, Action OnComplete)
    {
        foreach (var effect in effects)
        {
            effectQueue.Enqueue(effect);
        }

        StartSequence(data, OnComplete);
    }

    public void StartSequence(SkillData data, Action OnComplete)
    {
        if (effectQueue.Count > 0)
        {
            var effect = effectQueue.Dequeue();
            effect.ApplyEffect(data, () => StartSequence(data, OnComplete));
        }
        else 
        {
            OnComplete?.Invoke();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireSwordEffect", menuName = "Skill/Effect/FireSwordEffect")]
public class FireSwordEffect : IEffect
{
    [SerializeField] Transform fireVFX;

    public override void ApplyEffect(SkillData data, Action OnComplete = null)
    {
        Vector3 firePos = data.user.transform.forward;
        var fire = Instantiate(fireVFX, firePos, Quaternion.identity);
        // fire.transform.LookAt(data.clickPoint);
        //if (OnComplete!= null) fire.GetComponent<StopParticleSystem>().SetAction(OnComplete);
    }
}

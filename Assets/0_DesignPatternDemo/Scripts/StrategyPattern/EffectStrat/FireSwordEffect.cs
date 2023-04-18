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
        Vector3 firePos = data.user.transform.position;
        var fire = Instantiate(fireVFX, firePos, Quaternion.identity);
        fire.GetComponent<Projectile>().SetTarget(data.instantPoint, data.user);
        //if (OnComplete!= null) fire.GetComponent<StopParticleSystem>().SetAction(OnComplete);
    }
}

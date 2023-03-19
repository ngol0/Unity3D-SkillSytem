using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public ListSkillItem skillSO;
    Dictionary<SkillItem, float> skillDict = new Dictionary<SkillItem, float>();
    
    public void StartCoolingDown(SkillItem skill, float coolDownTime)
    {
        skillDict[skill] = coolDownTime;
    }

    public float GetCoolDownTime(SkillItem skill)
    {
        if (!skillDict.ContainsKey(skill)) skillDict[skill] = 0;
        return skillDict[skill];
    }

    public float GetRemainingTime(SkillItem skill)
    {
        if (!skillDict.ContainsKey(skill) || skill == null) skillDict[skill] = 0;
        return skillDict[skill]/skill.cooldownTime;
    }

    private void Update() 
    {
        foreach (var skill in skillDict.Keys.ToList())
        {
            skillDict[skill] -= Time.deltaTime;
            if (skillDict[skill] < 0)
            {
                skillDict.Remove(skill);
            }
        }
    }
}

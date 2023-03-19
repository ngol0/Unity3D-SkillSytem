using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListSkillItem", menuName = "SkillSO/ListSkillItem")]
public class ListSkillItem : ScriptableObject 
{
    public List<SkillItem> skillList;
}

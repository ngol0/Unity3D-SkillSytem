using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TagFilter", menuName = "Skill/Filter/Tag")]
public class TagFilter : IFilter
{
    [SerializeField] string tagName;
    public override IEnumerable<GameObject> Filter(IEnumerable<GameObject> targetsToFilter)
    {
        foreach (var target in targetsToFilter)
        {
            if (target.CompareTag(tagName))
            {
                yield return target;
            }
        }
    }
}

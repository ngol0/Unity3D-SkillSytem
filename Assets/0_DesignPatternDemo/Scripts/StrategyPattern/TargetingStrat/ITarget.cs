using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ITarget : ScriptableObject
{
    public abstract void StartTarget(SkillData data, Action OnComplete);
}

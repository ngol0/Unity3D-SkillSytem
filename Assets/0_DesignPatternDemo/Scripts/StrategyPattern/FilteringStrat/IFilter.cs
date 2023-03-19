using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IFilter : ScriptableObject 
{
    public abstract IEnumerable<GameObject> Filter(IEnumerable<GameObject> targetsToFilter);
}

    


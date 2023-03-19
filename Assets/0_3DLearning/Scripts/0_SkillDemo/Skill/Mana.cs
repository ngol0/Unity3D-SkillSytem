using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mana : MonoBehaviour
{
    [SerializeField] float maxMana;

    float curMana; 
    public float CurMana => curMana;
    public float MaxMana => maxMana;

    private void Awake() 
    {
        curMana = maxMana;
    }

    public bool UseMana(float manaToUse)
    {
        if (manaToUse > curMana) return false;
        curMana -= manaToUse;
        return true;
    }

    private void Update() 
    {
        if (curMana < maxMana)
        {
            curMana += Time.deltaTime;
        }
    }
}

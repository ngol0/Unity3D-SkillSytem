using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    [SerializeField] Mana manaLogic;

    [Header("UI element")]
    [SerializeField] Text curMana;

    private void DisplayMana()
    {
        curMana.text = String.Format("{0:0}/{1:0}", manaLogic.CurMana, manaLogic.MaxMana);
    }

    private void Update() 
    {
        DisplayMana();
    }
}

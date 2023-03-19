using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHolderUI : MonoBehaviour
{
    [SerializeField] Image skillLoadingUI;
    [SerializeField] SkillItem item;
    [SerializeField] SkillManager manager;

    private void Start() 
    {
        skillLoadingUI.fillAmount = 0f;
    }

    private void Update() 
    {
        skillLoadingUI.fillAmount = manager.GetRemainingTime(item);
    }
}

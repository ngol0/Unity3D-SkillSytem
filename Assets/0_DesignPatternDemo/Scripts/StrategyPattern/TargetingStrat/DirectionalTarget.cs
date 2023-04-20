using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DirectionalTarget", menuName = "Skill/Target/DirectionalTarget")]
public class DirectionalTarget : ITarget
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 cursorHotspot;
    public override void StartTarget(SkillData data, Action OnComplete)
    {
        data.targetedPoint = data.user.GetComponent<PlayerController>().CurPoint;
        OnComplete?.Invoke();
    }
}

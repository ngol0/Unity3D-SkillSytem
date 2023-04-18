using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum CursorType
    {
        None,
        Movement,
        Combat,
    }

    //[SerializeField] Animator unitAnimator;
    [SerializeField] SkillManager skillManager;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] Animator unitAnimator;
    public Animator Anim => unitAnimator;

    ListSkillItem skillListSO;

    [System.Serializable]
    struct CursorMapping
    {
        public CursorType type;
        public Texture2D texture;
        public Vector2 hotspot;
    }

    [SerializeField] CursorMapping[] cursorMappings = null;

    SkillItem curSkill;

    private void Start() 
    {
        skillListSO = skillManager.skillSO;
    }

    private void Update()
    {
        UseAbilities();

        if (CanCombat()) return;
        if (CanMove()) return;

        SetCursor(CursorType.None);
    }

    private bool CanCombat()
    {
        int enemyMask  = 1 << 9;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, float.MaxValue, enemyMask))
        {
            if (hitData.transform.GetComponent<EnemyTarget>().HandleRaycast(this))
            {
                SetCursor(CursorType.Combat);
                return true;
            }
        }
        return false;
    }

    private bool CanMove()
    {
        int layerMask  = 1 << 7;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, float.MaxValue, layerMask))
        {
            //Debug.Log(hitData);
            if (Input.GetMouseButtonDown(0)) { playerMove.StartMoveAction(hitData.point); }
            SetCursor(CursorType.Movement);
            return true;
        }
        return false;
    }

    private void SetCursor(CursorType type)
    {
        CursorMapping mapping = GetCursorMapping(type);
        Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
    }

    private CursorMapping GetCursorMapping(CursorType type)
    {
        foreach (CursorMapping mapping in cursorMappings)
        {
            if (mapping.type == type)
            {
                return mapping;
            }
        }
        return cursorMappings[0];
    }

    private void UseAbilities()
    {
        for (int i = 0; i < skillListSO.skillList.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                curSkill = skillListSO.skillList[i];
                curSkill.Use(this.gameObject);

                //todo: trigger ui

            }
        }
    }
}

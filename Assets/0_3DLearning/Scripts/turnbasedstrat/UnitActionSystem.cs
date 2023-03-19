using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitActionSystem : Singleton<UnitActionSystem> 
{
    [SerializeField] Unit selectedUnit;
    [SerializeField] LayerMask groundLayerMask;
    public Unit SelectedUnit { get => selectedUnit; }
    public event EventHandler<OnUnitSelectedArgs> OnSelectedUnitChanged;

    public class OnUnitSelectedArgs : EventArgs {
        public Unit onSelectedUnit;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleSelection()) return;

            Vector3 target = WorldPosition.GetWorldPosOnGround();
            //selectedUnit.Move(target);
        }
    }

    private bool TryHandleSelection()
    {
        int characterLayerMask = 1 << 8; //bit shift syntax

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, float.MaxValue, characterLayerMask))
        {
            if (hitData.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SelectUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void SelectUnit(Unit unit) {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, 
            new OnUnitSelectedArgs { onSelectedUnit = selectedUnit });
    }
}

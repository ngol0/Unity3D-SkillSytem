using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectVisual : MonoBehaviour
{
    [SerializeField] Unit unit;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual(UnitActionSystem.instance.SelectedUnit);
    }

    void UnitActionSystem_OnSelectedUnitChanged(object sender, UnitActionSystem.OnUnitSelectedArgs e)
    {
        UpdateVisual(e.onSelectedUnit);
    }

    private void UpdateVisual(Unit selectedUnit)
    {
        if (selectedUnit == unit)
            meshRenderer.enabled = true;
        else
            meshRenderer.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] TextMeshPro gridText;
    GridObject gridObject;
    GridPosition gridPosition;
    //TextMeshPro textMeshPro;

    public void SetGridObject(GridObject gridObject) {
        this.gridObject = gridObject;
    }

    private void Update() {
        gridText.text = gridObject.ToString();
    }
}

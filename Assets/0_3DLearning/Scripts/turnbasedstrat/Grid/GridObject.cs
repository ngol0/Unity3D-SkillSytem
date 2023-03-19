using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;

    public GridPosition GridPosition { get => gridPosition; }
    public List<Unit> UnitList { get => unitList; }

    public GridObject(GridSystem gridSystem, GridPosition gridPosition) 
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public override string ToString()
    {
        string unitString = "";
        foreach (Unit unit in unitList)
        {
            unitString+=unit + "\n";
        }
        return gridPosition.ToString() + "\n" + unitString;
    }
}

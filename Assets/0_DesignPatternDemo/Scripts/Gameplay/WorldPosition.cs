using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPosition : MonoBehaviour
{
    public static Vector3 GetWorldPosOnGround()
    {
        int layerMask  = 1 << 7;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, float.MaxValue, layerMask))
            return(hitData.point);
        else 
            return new Vector3(-1,-1,-1);
    }

    public static Vector3 GetEnemyPosInWorld()
    {
        int enemyMask  = 1 << 9;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, float.MaxValue, enemyMask))
            return(hitData.point);
        else 
            return new Vector3(-1,-1,-1);
    }
}

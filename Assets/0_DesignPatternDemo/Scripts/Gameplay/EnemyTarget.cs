using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    PlayerFight playerFight;

    public bool HandleRaycast(PlayerController playerController)
    {
        playerFight = playerController.GetComponent<PlayerFight>();

        if (!enabled) return false;
        if (!playerFight.CanAttack(gameObject)) return false;

        if (Input.GetMouseButton(0))
        {
            playerFight.Attack(gameObject);
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;

    [SerializeField] Animator unitAnimator;

    private void Awake() {
        targetPosition = transform.position;
    }
}

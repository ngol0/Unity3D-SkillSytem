using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 targetedPoint;
    GameObject user;
    float speed = 7f;
    float maxLifeTime = 10;

    public void SetTarget(Vector3 targetedPoint, GameObject user)
    {
        this.targetedPoint = targetedPoint;
        this.user = user;
        transform.LookAt(targetedPoint);
        Destroy(gameObject, maxLifeTime);
    }

    private void Update() 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
    }
}

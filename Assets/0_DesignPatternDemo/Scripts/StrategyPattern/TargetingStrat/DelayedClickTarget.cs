using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DelayedTarget", menuName = "Skill/Target/DelayedClickTarget")]
public class DelayedClickTarget : ITarget
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 cursorHotspot;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float areaOfAffect;
    [SerializeField] GameObject summonCircle;
    
    GameObject summonCircleObj;

    public override void StartTarget(SkillData data, Action onComplete)
    {
        PlayerController skillController = data.user.GetComponent<PlayerController>();
        skillController.StartCoroutine(Targeting(skillController, data, onComplete));
    }

    private IEnumerator Targeting(PlayerController unit, SkillData data, Action onComplete)
    {
        unit.enabled = false;

        //update every frame with yield return null
        while (!data.IsCanceled)
        {
            Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
            var hitpoint = WorldPosition.GetWorldPosOnGround();

            if (summonCircleObj == null)
            { summonCircleObj = Instantiate(summonCircle, hitpoint, Quaternion.identity); }
            else { summonCircleObj.SetActive(true); }

            summonCircleObj.transform.localScale = new Vector3(areaOfAffect*2, 1, areaOfAffect*2);
            
            if (hitpoint.y != -1)
            {
                summonCircleObj.transform.position = hitpoint;

                if (Input.GetMouseButtonDown(0))
                {
                    //those two lines below do the exact same thing: wait until the mouse button is up > enable unit script
                    //to prevent unit from running after click
                    yield return new WaitWhile(() => Input.GetMouseButton(0));
                    //while (Input.GetMouseButton(0)) yield return null;

                    //when release mouse btn > get all targets
                    data.targets = GetTargetsInRadius(hitpoint);
                    data.clickPoint = hitpoint;

                    break;
                }
                
                yield return null;
            }
        }
        unit.enabled = true;
        summonCircleObj.SetActive(false);
        onComplete?.Invoke();
    }

    private IEnumerable<GameObject> GetTargetsInRadius(Vector3 point)
    {
        // //Input.MousePosition() is the 2d position on the screen.  
        // //In order to know where that actually is in the scene, we need to use the Raycast and hit.point.
        RaycastHit[] targets = Physics.SphereCastAll(point, areaOfAffect, Vector3.up, 0, enemyLayerMask);
        foreach (var target in targets)
        {
            yield return target.collider.gameObject;
        }
    }
}

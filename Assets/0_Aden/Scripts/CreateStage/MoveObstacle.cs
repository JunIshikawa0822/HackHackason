using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : CreateStageManager
{
    

    protected override void MoveObject()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
        Vector3 objPoint = Camera.main.ScreenToWorldPoint (a);

        gameObject.transform.position = objPoint;
    }
}

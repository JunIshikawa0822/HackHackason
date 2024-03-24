using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : CreateStageManager
{
    private bool canMove = false;

    public void ChangeBool()
    {
        Debug.Log("on");
        if (canMove)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }
    
    protected override void MoveObject()
    {
        if (canMove)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 objPoint;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                objPoint = new Vector3(hit.point.x,hit.point.y,hit.point.z);
            }
            else
            {
                Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                objPoint = Camera.main.ScreenToWorldPoint(a);
            }


            gameObject.transform.position = objPoint;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0,1,0);
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0,1,0);
            }
        }
    }
}

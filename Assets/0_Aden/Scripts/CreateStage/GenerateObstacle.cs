using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    Vector3 screenPoint;
    public void OnImageClick()
    {
       
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x = 0;
        mousePosition.y = 0;
        mousePosition.z = 0;
       // screenPoint = Camera.main.WorldToScreenPoint(mousePosition);
         screenPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        // Vector3 a = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
        // Vector3 genePoint = Camera.main.ScreenToWorldPoint (a);
      GameObject obj = Instantiate(gameObject.GetComponent<IconStatus>().obstacle, screenPoint,Quaternion.identity);
      obj.AddComponent<MoveObstacle>();
    }
}

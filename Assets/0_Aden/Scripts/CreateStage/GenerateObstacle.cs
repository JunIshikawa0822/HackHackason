using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    Vector3 screenPoint;
    public void OnImageClick()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
        Vector3 genePoint = Camera.main.ScreenToWorldPoint (a);
      GameObject obj = Instantiate(gameObject.GetComponent<IconStatus>().obstacle, genePoint,Quaternion.identity);
      obj.AddComponent<MoveObstacle>();
    }
}

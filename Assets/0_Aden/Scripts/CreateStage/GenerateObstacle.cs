using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    public void OnImageClick()
    {
        Instantiate(gameObject.GetComponent<IconStatus>().obstacle, Input.mousePosition,Quaternion.identity);
    }
}

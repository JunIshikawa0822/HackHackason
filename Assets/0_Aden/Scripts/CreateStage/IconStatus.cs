using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconStatus : MonoBehaviour
{
    public GameObject obstacle;
    private GameObject thisGameObject;
    
   public IconStatus(GameObject obj, GameObject obs)
   {
       thisGameObject = obj;
       obstacle = obs;
   }
}

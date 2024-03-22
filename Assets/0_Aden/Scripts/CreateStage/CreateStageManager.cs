using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GenerateIcons();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    protected virtual void GenerateIcons(){}
    
    protected virtual void MoveObject(){}
}

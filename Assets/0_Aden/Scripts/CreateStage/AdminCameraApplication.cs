using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminCameraApplication : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        CameraRote();
        CameraZoom();
    }
    
    protected virtual void CameraMove(){}
    protected virtual void CameraRote(){}
    protected virtual void CameraZoom(){}
}

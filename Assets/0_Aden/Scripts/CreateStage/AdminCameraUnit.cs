using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminCameraUnit : AdminCameraApplication 
{
     private float defo;
    [SerializeField] private float speed;
    [SerializeField] private float dash;
    [SerializeField] private float roteSpeed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private GameObject camera;
    protected override void CameraMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            defo = speed;
            speed = dash;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = defo;
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position +=　gameObject.transform.forward * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -=　gameObject.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -=　gameObject.transform.right * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position +=　gameObject.transform.right * speed * Time.deltaTime;
        }
    }

    protected override void CameraRote()
    {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftCommand))
        {
            float rotateX = Input.GetAxis("Mouse X") * roteSpeed;
            float rotateY = Input.GetAxis("Mouse Y") * roteSpeed;
            gameObject.transform.Rotate(0, -rotateX, 0.0f);
            camera.transform.Rotate(rotateY,0,0);
        }

    }

    protected override void CameraZoom()
    {
        var scroll = Input.mouseScrollDelta.y;
        camera.transform.position += -camera.transform.forward * scroll * zoomSpeed;

    }
}

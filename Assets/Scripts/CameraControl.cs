using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{ 
    public GameObject parent;

    Vector3 defPosition;
    Quaternion defRotation;
    float defZoom;
    //왼쪽 드래그로 카메라 이동

    void Start()
    {
        parent = transform.parent.gameObject;

        //기본 위치 저장
        defPosition = transform.position; 
        defRotation = parent.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            transform.Translate(
                Input.GetAxis("Mouse X") / 10,
                Input.GetAxis("Mouse Y") / 10,
               0);
        }

        if (Input.GetMouseButton(1))
        {
            parent.transform.Rotate(
                -Input.GetAxis("Mouse Y") * 10,
                Input.GetAxis("Mouse X") * 10,
               0);
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0) //휠 회전 확대 추가
        {
            Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));
            if(Camera.main.fieldOfView < 10)
                Camera.main.fieldOfView = 10;
            else if(Camera.main.fieldOfView > 100)
                Camera.main.fieldOfView = 100;
        }

        if(Input.GetMouseButton(2))
        {
            transform.position = defPosition;
            parent.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }
}

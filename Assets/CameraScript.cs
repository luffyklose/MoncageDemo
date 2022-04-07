using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject rotatePoint;
    public float rotateSpeed = 5;

    public float angle;
    public float maxRotAngle;
    public float minRotAngle;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(1))
        {
            CameraRotate(mouseX, -mouseY);
        }
    }
    
    void CameraRotate(float _mouseX, float _mouseY)
    {
        //控制相机绕中心点水平旋转
        this.transform.RotateAround(rotatePoint.transform.position, Vector3.up, _mouseX * rotateSpeed);

        //记录相机绕中心点垂直旋转的总角度
        angle = transform.eulerAngles.x + _mouseY * rotateSpeed;
        if (angle > 270)
        {
            angle -= 360;
        }

        //控制相机绕中心点竖直旋转
        if (angle >= minRotAngle && angle <= maxRotAngle)
        {
            transform.RotateAround(rotatePoint.transform.position, transform.right, _mouseY * rotateSpeed);
        }

    }
}

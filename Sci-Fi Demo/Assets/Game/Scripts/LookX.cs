using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.3f;
    float xRot=0.0f;
    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        Vector3 myRotation = transform.localEulerAngles;
        xRot += _mouseX*_sensitivity;
        myRotation.y = xRot;
        transform.localEulerAngles = myRotation;
    }
}

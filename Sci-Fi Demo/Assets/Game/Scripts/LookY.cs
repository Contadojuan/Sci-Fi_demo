using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.01f;
    float yRot = 0.0f;
    void Update()
    {
        float _yMouse = Input.GetAxis("Mouse Y");
        yRot -= _yMouse * _sensitivity;
        yRot = Mathf.Clamp(yRot, -75.0f, 75.0f);
        Vector3 myRotation = transform.localEulerAngles;
        myRotation.x = yRot;
        transform.localEulerAngles = myRotation;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.3f;
    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        Vector3 myRotation = transform.localEulerAngles;
        myRotation.y += _mouseX*_sensitivity;
        transform.localEulerAngles = myRotation;
    }
}

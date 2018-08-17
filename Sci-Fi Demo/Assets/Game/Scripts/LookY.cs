using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.1f;
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
		Vector3 myRotation = transform.localEulerAngles;
		myRotation.x -= Mathf.Clamp((_mouseY*_sensitivity),-80.0f,80.0f);
		transform.localEulerAngles = myRotation;
    }
}

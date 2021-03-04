using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGameObject : MonoBehaviour
{
    private float rotationSpeed = 10f;

    private void OnMouseDrag() {
        transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * rotationSpeed, Space.World);
        transform.Rotate(-Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed, Space.World);
    }
}

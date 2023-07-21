using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player, cameraPosition;
    public float Velocity = 10f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPosition.transform.position, Velocity * Time.deltaTime);
    }
}

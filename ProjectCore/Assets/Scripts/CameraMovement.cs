using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 Angle;
    void Start()
    {
        player = GameObject.Find("MainCube");
    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, player.transform.position + Angle, Time.deltaTime);
    }
}

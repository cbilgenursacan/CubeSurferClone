using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float horizontalVelocity;

    private Vector3 position;
    private Vector3 lastPosition;
    // Update is called once per frame

    void Update()
    {
        transform.Translate(0, 0, velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            lastPosition = Input.mousePosition;
            float x = (lastPosition.x - position.x);
            transform.Translate(x * Time.deltaTime * horizontalVelocity / 100, 0, 0);
            if(transform.position.x > 7)
            {
                transform.position = new Vector3(7.0f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < 1.4)
            {
                transform.position = new Vector3(1.4f, transform.position.y, transform.position.z);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            position = Vector3.zero;
            lastPosition = Vector3.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float movement = speed * Time.deltaTime;
        transform.Translate(
            movement * Input.GetAxis("Horizontal"), 
            0, 
            movement * Input.GetAxis("Vertical")
        );

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    CubeNotificator cubeNotificator;
    GameObject targetObject;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        cubeNotificator = GameObject.FindWithTag("green_cube").GetComponent<CubeNotificator>();
        targetObject = GameObject.FindWithTag("blue_cylinder");
        if (tag == "group1") { cubeNotificator.OnColissionWithAny += AnyRespond; }
        if (tag == "group2") { cubeNotificator.OnColissionWithGroup1 += Group1Respond; }
        cubeNotificator.OnColissionWithCylinder += CylinderRespond;
    }

    void AnyRespond() { MoveToTarget(); }

    void Group1Respond() { Scalate(); }

    void CylinderRespond() {
        if (tag == "group1") { ChangeToRandomColor(); }
        else if (tag == "group2") { MoveToTarget(); }
    }

    void MoveToTarget() {
        Vector3 targetPosition = targetObject.transform.position;
        Vector3 movement = (targetPosition - transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(movement * speed, ForceMode.Impulse);               
    }

    void ChangeToRandomColor() {
        GetComponent<Renderer>().material.color = 
                new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);  
    }

    void Scalate() { transform.localScale += new Vector3(1, 1, 1); }

    void OnDestroy() {
        if (gameObject == null || cubeNotificator == null) { return; }
        if (tag == "group1") { cubeNotificator.OnColissionWithAny -= AnyRespond; }
        if (tag == "group2") { cubeNotificator.OnColissionWithGroup1 -= Group1Respond; }
        cubeNotificator.OnColissionWithCylinder -= CylinderRespond;    
    }
} 

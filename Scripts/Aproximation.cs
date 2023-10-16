using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aproximation : MonoBehaviour
{

    Vector3 previousPosition;
    GameObject[] group1Objects;
    GameObject[] group2Objects;
    public GameObject targetObject;
    public GameObject movingObject;
    // Start is called before the first frame update

    void Start()
    {
       group1Objects = GameObject.FindGameObjectsWithTag("group1");
       group2Objects = GameObject.FindGameObjectsWithTag("group2");
       previousPosition = movingObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = targetObject.transform.position;
        Vector3 movingPosition = movingObject.transform.position;
        float prevDistance = Vector3.Distance(targetPosition, previousPosition);
        float currentDistance = Vector3.Distance(targetPosition, movingPosition);
        if (currentDistance < prevDistance) {
            foreach(GameObject g1object in group1Objects) {
                if (g1object != null) {
                    Color currentColor = g1object.GetComponent<Renderer>().material.color;
                    g1object.GetComponent<Renderer>().material.color = 
                        Color.Lerp(currentColor, Color.green, Time.deltaTime);
                    if (g1object.transform.position.y <= 0.5) {
                        g1object.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse); 
                    }
                }
            }
            foreach(GameObject g2object in group2Objects) {
                if (g2object != null) { g2object.transform.LookAt(transform); }
            }
        }        
        previousPosition = movingPosition;
    }
}

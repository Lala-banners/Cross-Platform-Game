using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject ballObject;
    public float force;

    //Constant float to keep the maximum amount of force given to the object
    public const float maxForce = 100f;

    // Update is called once per frame
    void Update()
    {
        Camera mainCam = Camera.main;
        Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            //Mouse down, start force
            force += Time.deltaTime;
        }

        if(Input.GetMouseButtonUp(0))
        {
            //Mouse up = launch from camera //mainCam.ScreenToWorldPoint(mousePos) 
            GameObject clone = Instantiate(ballObject, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}

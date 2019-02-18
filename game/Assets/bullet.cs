using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void Awake()
    {
       // MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        //transform.Rotate(MainCamera.transform.rotation);
    }
    void Update()
    {
        //transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer meshRender;
    Rigidbody rigidBody;
    [SerializeField] float timeToWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.useGravity = false;
        meshRender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            rigidBody.useGravity = true;
            meshRender.enabled = true;
        }
        //Debug.Log("Elapsed Time " + Time.time);
    }
}

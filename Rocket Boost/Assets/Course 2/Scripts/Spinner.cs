using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xRValue = 0f;
    [SerializeField] float yRValue = 0f;
    [SerializeField] float zRValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRValue, yRValue, zRValue);
    }
}

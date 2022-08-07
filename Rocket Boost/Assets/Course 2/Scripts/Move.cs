using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Movement Speed
    [SerializeField] float moveSpeed = 0.10f;

    // Start is called before the first frame update
    void Start()
    {
        PrintSomething();
    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();
    }

    void MovementControl()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }

    void PrintSomething()
    {
        Debug.Log("Test print inside PrintSomething() method");
    }
}

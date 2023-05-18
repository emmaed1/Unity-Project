using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{

    public float speed = 30;
    public float steerSpeed = 30;
    public float jumpForce = 4000;
    public float moreSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        float steerValue = horizontal * steerSpeed * Time.deltaTime;
        float gasValue = vertical * speed * Time.deltaTime;
        float jumpValue = jump * jumpForce * Time.deltaTime;

        Vector3 positionChange = Vector3.forward * gasValue;

        transform.Rotate(Vector3.up, steerValue);
        transform.Translate(positionChange);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, jumpValue * Time.deltaTime, 0);
            Debug.Log("Jumping");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            steerSpeed *= moreSpeed;
            speed *= moreSpeed; 
            Debug.Log("This is fast speed");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            steerSpeed = steerSpeed / moreSpeed;
            speed = speed / moreSpeed;
            Debug.Log("This is normal speed");
        }
    }
}

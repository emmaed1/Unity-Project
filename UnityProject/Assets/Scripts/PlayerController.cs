using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour {

    public float speed = 30;
    public float steerSpeed = 60;
    public float jumpForce = 4000;
    public float moreSpeed = 2;

    private Vector3 startPosition;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        Debug.Log("Hello World!");
    }

    void HandleMovement() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        float steerValue = horizontal * steerSpeed * Time.deltaTime;
        float gasValue = vertical * speed * Time.deltaTime;
        float jumpValue = jump * jumpForce * Time.deltaTime;

        steerValue *= Mathf.Sign(gasValue);
        if(gasValue == 0) {
            steerValue = 0;
        }

        if (Input.GetKey(KeyCode.Space)) {
            transform.Translate(0, jumpValue * Time.deltaTime, 0);
            Debug.Log("Jumping");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            steerSpeed *= moreSpeed;
            speed *= moreSpeed;
            Debug.Log("This is fast speed");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            steerSpeed = steerSpeed / moreSpeed;
            speed = speed / moreSpeed;
            Debug.Log("This is normal speed");
        }
        Vector3 positionChange = Vector3.forward * gasValue;

        transform.Rotate(Vector3.up, steerValue);
        transform.Translate(positionChange);
    }

    void HandleResetPosition() {
        if (Input.GetKeyDown(KeyCode.R)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                ResetPosition(startPosition);
            } else {
                ResetPosition();
            }
        }
    }
    void ResetPosition(Vector3 newPosition) {
        transform.position = newPosition;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }

    void ResetPosition() {
        Vector3 newPos = transform.position;
        newPos.y = 10;
        ResetPosition(newPos);
    }

    // Update is called once per frame
    void Update() {
        HandleResetPosition();
        HandleMovement();
    }
}

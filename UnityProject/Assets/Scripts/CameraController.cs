using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MovebehindPlayer()
    {
        Vector3 newPosition = player.transform.position;
        newPosition.y = transform.position.y;
        newPosition.z -= 10;
        transform.position = newPosition;
    }

    void MoveOnTheSideOfPlayer() 
    { 
        Vector3 newPosition = transform.position;
        newPosition.z = player.transform.position.z;
        transform.position  = newPosition;
    }
    // Update is called once per frame
    void LateUpdate()
    {

    }
}

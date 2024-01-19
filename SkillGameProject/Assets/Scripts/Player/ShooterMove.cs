using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class ShooterMove : NetworkBehaviour
{
    public Vector3 mousePosition;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - player.position;
        //Changes direction variable to be towards the mouse.

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Uses direction to find the angle object needs to turn to.
        Quaternion rotation = Quaternion.AngleAxis((angle-90), Vector3.forward);
        //Makes rotation = the direction it needs to turn to.
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [Header("ship parameters")]
    [SerializeField] private float shipAcceleration = 10f;  
    [SerializeField] private float shipMaxVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 180f;
      [SerializeField] private float bulletSpeed = 8f;

      
    [Header("Object references")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;

    //Ship variables 
    private Rigidbody2D shipRigidbody;
    private bool isAlive = true;
    private bool isaccelerating = false;

    private void Start() {
        //get a reference to the attached RigidBody2D
        shipRigidbody = GetComponent<Rigidbody2D>();
        
    }
    
    private void Update() {
        if (isAlive) {
            HandleShipAcceleration();
            HandleShipRotation();
            HandleShooting();
        
        }

    }

    private void FixedUpdate() {
        if (isAlive && isaccelerating) {
            shipRigidbody.AddForce(shipAcceleration * transform.up);
            shipRigidbody.velocity = Vector2.ClampMagnitude(shipRigidbody.velocity, shipMaxVelocity);
        }
    }

    private void HandleShipAcceleration() {
        // Are we accelerating?
        isaccelerating = Input.GetKey(KeyCode.W);
    }

    private void HandleShipRotation() {
        // Ship rotation.
        if(Input.GetKey(KeyCode.A)) {
            transform.Rotate(shipRotationSpeed * Time.deltaTime * transform.forward);
        
        } else if(Input.GetKey(KeyCode.D)) {
         transform.Rotate(-shipRotationSpeed * Time.deltaTime * transform.forward);   
        }

    }
    private void HandleShooting() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
            Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

            Vector2 shipVelocity = shipRigidbody.velocity;
            Vector2 shipDirection = transform.up;
            float shipForwardSpeed = Vector2.Dot(shipVelocity, shipDirection);

            if(shipForwardSpeed < 0) {
                shipForwardSpeed = 0;

            }

            bullet.velocity = shipDirection * shipForwardSpeed;

            bullet.AddForce(bulletSpeed * transform.up, ForceMode2D.Impulse);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
//using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ShipControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float torque;
    public float speed;
    public float jumpForce;
    public float boostSpeed;
    public GameObject Booster;
    public GameObject Player;
    public GameObject death;
    public bool dead = false;
    public Vector3 spawnLoc;
    Texting texting;
    
    public GameObject shotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player.SetActive(false);
        Player.SetActive(true);
        Booster.SetActive(false);
        spawnLoc = transform.position;
        texting = GameObject.FindGameObjectWithTag("Text").GetComponent<Texting>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Speed: " + speed);   
        if(transform.position.x < -9){
            transform.position = new Vector2(transform.position.x+18, transform.position.y);
        }
        if(transform.position.x > 9){
            transform.position = new Vector2(transform.position.x-18, transform.position.y);
        }
        if(transform.position.y < -5){
            transform.position = new Vector2(transform.position.x, transform.position.y+10);
        }
        if(transform.position.y > 5){
            transform.position = new Vector2(transform.position.x, transform.position.y-10);
        }
        Player.SetActive(true);
        
    }

    void FixedUpdate() {
        rb.AddForce( transform.up * boostSpeed * 10 );
        
    }

    void OnTurnLeft (InputValue value) {
        Debug.Log("turning left?");
        torque = 200;
        rb.AddTorque (torque, ForceMode2D.Force);
        //transform.position = new Vector2(transform.position.x, transform.position.y + 5);
        //float turn = Input.GetAxis("Horizontal");
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z-30);
        
    }

    void OnTurnRight (InputValue value) {
        Debug.Log("turning right?");
        torque = -200;
        rb.AddTorque (torque, ForceMode2D.Force);
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z+30);
        //Mathf.MoveTowardsAngle
    }

    void OnThrust (InputValue value) {
        Debug.Log("thrusting!");
        //rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //rb.AddForce( transform.up * boostSpeed * 10 );
        if (boostSpeed == 0) {
            boostSpeed = 10;
            Booster.SetActive(true);
        }
        else {
            boostSpeed = 0;
            Booster.SetActive(false);
        }
        
    }

    void OnRespawn (InputValue value) {
        Debug.Log("Completing Respawn");
        boostSpeed = 0;
    }

    void OnShoot (InputValue value) {
        Instantiate(shotPrefab,Player.gameObject.transform.position, Player.gameObject.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Colliding with roid");
        if (other.gameObject.CompareTag("Astroid")) {
            transform.position = spawnLoc;
            
            Player.SetActive(false);
            Debug.Log("Should be dead as hell");
            dead = true;
            death.SetActive(true);
        }
    }

    
}

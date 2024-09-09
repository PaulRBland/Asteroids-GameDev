using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RoidBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float mSpeed;
    int dir;
    int spawnx, spawny;
    int clr;
    public GameObject Roid;
    Texting texting;
    
    // Start is called before the first frame update
    void Start()
    {
        texting = GameObject.FindGameObjectWithTag("Text").GetComponent<Texting>();
        rb = GetComponent<Rigidbody2D>();
        dir = Random.Range(1,8);
        clr = Random.Range(1,4);

        if (clr == 1) {
            Roid.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (clr == 2) {
            Roid.GetComponent<Renderer>().material.color = Color.red;
        }
        if (clr == 3) {
            Roid.GetComponent<Renderer>().material.color = Color.green;
        }
        if (clr == 4) {
            Roid.GetComponent<Renderer>().material.color = Color.cyan;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
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
        //rb.AddForce( transform.up * 2 * 10 );
        if (dir == 1) {
        transform.Translate(Vector2.up * mSpeed * Time.deltaTime);
        }
        if (dir == 2) {
        transform.Translate(Vector2.right * mSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * mSpeed * Time.deltaTime);
        }
        if (dir == 3) {
        transform.Translate(Vector2.right * mSpeed * Time.deltaTime);
        }
        if (dir == 4) {
        transform.Translate(Vector2.right * mSpeed * Time.deltaTime);
        transform.Translate(Vector2.down * mSpeed * Time.deltaTime);
        }
        if (dir == 5) {
        transform.Translate(Vector2.down * mSpeed * Time.deltaTime);
        }
        if (dir == 6) {
        transform.Translate(Vector2.left * mSpeed * Time.deltaTime);
        transform.Translate(Vector2.down * mSpeed * Time.deltaTime);
        }
        if (dir == 7) {
        transform.Translate(Vector2.left * mSpeed * Time.deltaTime);

        }
        if (dir == 8) {
        transform.Translate(Vector2.left * mSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * mSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.CompareTag("Shot")) {
            texting.IncreaseScore();
            Destroy(Roid.gameObject);
         }
    }

    

}

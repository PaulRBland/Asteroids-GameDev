using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float mSpeed;
    public GameObject shot;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.up * mSpeed * Time.deltaTime);

        if(transform.position.x < -12 || transform.position.x > 12 || transform.position.y < -5 || transform.position.y > 5) {
            Destroy(shot.gameObject);
        }

        
    }

    private void OnTrigger2D(Collision2D other) {
            Destroy(shot.gameObject);
        }
    
    
}

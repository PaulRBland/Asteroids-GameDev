using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorldControls : MonoBehaviour

{

    public GameObject Player;
    public GameObject death;
    public GameObject Booster;
    public Vector3 spawnLoc;
    public GameObject Roid;
    int spawnx, spawny;
    Vector3 pos;
    int cnt;
    Texting texting;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnLoc = transform.position;
        texting = GameObject.FindGameObjectWithTag("Text").GetComponent<Texting>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnx = Random.Range(1,2);
        spawny = Random.Range(1,2); 
        cnt = cnt+1;
        if (spawnx == 1) { spawnx = -5; }
        if (spawnx == 2) { spawnx = 5; }
        if (spawny == 1) { spawnx = -9; }
        if (spawny == 1) { spawnx = 9; }
        if (cnt % 250 == 0) {
            Debug.Log("Spawning new roid");
            pos = new Vector3 (spawnx,spawny,0);
            Instantiate(Roid, pos, Quaternion.identity );
        }
    }

    void OnRespawn(InputValue value) {
        if (Player.activeInHierarchy == false) {
            texting.ResetScore();
            Player.SetActive(true);
            death.SetActive(false);
            Debug.Log("Respawned!");
            Player.SetActive(false);
            Player.SetActive(true);
            Booster.SetActive(false);
            
        }
        
    }
}

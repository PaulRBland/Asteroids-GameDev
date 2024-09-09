using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Texting : MonoBehaviour
{
    // Start is called before the first frame update
     public TMP_Text scoretext;

    int score = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // scoretext.SetText("Score: " + test);
       // test++;
    }

    public void IncreaseScore() {
        score = score +20;
        scoretext.SetText("Score: " +score);
    }

    public void ResetScore () {
        score = 0;
        scoretext.SetText("Score: " +score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public int hits = 0;
    public int points = 10;

    public Material hitMat;
    Material tilesMat;
    Renderer prenderer;
    // Start is called before the first frame update
    void Start()
    {
        prenderer = GetComponent<Renderer>();
        tilesMat = prenderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionStay(Collision collision)
    {
        hits++;
        if (hits > 0 && hits < 2)
        {
            //update score in game manager
            print("NO POINTS???");
            gameManager.Instance.Score += points;
        }
        hits = 0;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        hits++;
        if (hits > 0 && hits < 2)
        {
            //update score in game manager
            print("NO POINTS???");
            gameManager.Instance.Score += points;
        }
        hits = 0;
        prenderer.sharedMaterial = hitMat;
        Invoke("RestoreMaterial", 0.05f);
    }
    
    void RestoreMaterial()
    {
        prenderer.sharedMaterial = tilesMat;
    }
}

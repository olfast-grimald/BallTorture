using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTile : MonoBehaviour
{
    public Material doneMAt;
    Material endMat;
    Renderer prend;

    public int slaps = 0;
    // Start is called before the first frame update
    void Start()
    {
        prend = GetComponent<Renderer>();
        endMat = prend.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //DelayAction(2);
        float delay = 1;
        
        slaps++;
        if(slaps > 0)
        {
            prend.sharedMaterial = doneMAt;
            StartCoroutine(After(delay));
            //gameManager.Instance.Levels++;
            //gameManager.Instance.SwitchState(gameManager.State.LEVELCOMPLETE);
        }
        slaps = 0;
    }

    //float delay = 2;
    /*void DelayAction(float delay)
    {
        StartCoroutine(After(delay));
    }*/

    IEnumerator After(float howLong)
    {
        yield return new WaitForSeconds(howLong);
        gameManager.Instance.SwitchState(gameManager.State.LEVELCOMPLETE);
    }
}

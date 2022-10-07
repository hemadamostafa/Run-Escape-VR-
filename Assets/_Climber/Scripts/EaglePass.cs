using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglePass : MonoBehaviour
{
    public float timer = 100f;
    public GameObject TheEagle;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= .2f;
        if(timer < 0)
        {
            Debug.Log("Grenerate Eagle");
            Instantiate(TheEagle,transform.position,transform.rotation);
            timer = 100f;
        }
    }
}

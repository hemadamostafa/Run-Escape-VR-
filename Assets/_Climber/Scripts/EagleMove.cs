using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody rb;
    public AudioSource EagleSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EagleSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
        if(transform.position.x > 5)
        {
            EagleSound.Play();
        }
    }
}

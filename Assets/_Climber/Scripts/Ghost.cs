using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public GameObject PlayerSound; // follow climper
    public GameObject PlayerHand;
    private bool Fly = false;
    private bool GhostMove = true;
    AudioSource GhostDie;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fly)
        {
            transform.LookAt(PlayerHand.transform.position);
            rb.velocity = transform.forward * speed * Time.deltaTime;
            Debug.Log("Now To player");
        }
        else
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (GhostMove)
        {
            Debug.Log("Collision Happend So He Can Fly");
            if (collision.gameObject.CompareTag("Fly"))
            {
                Fly = true;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("PlayerBody"))
            {
                PlayerSound.GetComponent<AudioSource>().Play();
                GhostMove = false;
                rb.isKinematic = true;
                SceneManager.LoadScene(1);
            }
            if (collision.gameObject.CompareTag("SafeArea"))
            {
                GhostDie.Play();
                Destroy(this);
                //SceneManager.LoadScene();
            }
        }
    }

    /*private void OnTriggerEnter(Collision other)
    {
        
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Climber climber;
    public OVRInput.Controller controller = OVRInput.Controller.None;
    public AudioSource Breath1;
    public AudioSource Breath2;
    public AudioSource Breath3;
    public Vector3 Delta { private set; get; }

    private Vector3 lastPosition = Vector3.zero;

    private GameObject currentPoint = null;
    private List<GameObject> contactPoints = new List<GameObject>();
    private MeshRenderer meshRender = null;

    private void Awake()
    {
        meshRender = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
         if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
         {
            float WichBreath = Random.Range(0f,1f);
            if (WichBreath > 0 && WichBreath < .3)
            {
                Breath1.Play();
            }
            if (WichBreath > .3 && WichBreath < .6)
            {
                Breath2.Play();
            }
            if (WichBreath > .6 && WichBreath < 1)
            {
                Breath3.Play();
            }
            GrapPoint();
         }
          if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
          {
              ReleasePoint();
          }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            GrapPoint();
        }
            
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Release");
            ReleasePoint();
        }*/
            

    }

    private void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        Delta = lastPosition - transform.position;
    }

    private void GrapPoint()
    {

        currentPoint = Utility.GetNearest(transform.position, contactPoints);
        if (currentPoint)
        {
            climber.SetHand(this);
            meshRender.enabled = false;
        }
    }

    public void ReleasePoint()
    {
        if (currentPoint)
        {
            climber.ClearHand();
            meshRender.enabled = false;
        }
        currentPoint = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        AddPoint(other.gameObject);
    }

    private void AddPoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimbPoint"))
        {
            contactPoints.Add(newObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RemovePoint(other.gameObject);
    }

    private void RemovePoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimbPoint"))
        {
            contactPoints.Remove(newObject);
        }
    }
}

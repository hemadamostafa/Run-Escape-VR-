using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Climber : MonoBehaviour
{
    public float gravity = 45.0f;
    public float sensisvty = 45.0f;

    private Hand currentHand = null;
    private CharacterController controller = null;

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }
    private void Awake()
    {

    }

    private void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        Vector3 movement = Vector3.zero;
        if (currentHand)
        {
            movement += currentHand.Delta * sensisvty;
        }
        if(movement == Vector3.zero)
        {
            movement.y -= gravity * Time.deltaTime;
        }
        controller.Move(movement*Time.deltaTime);
    }

    public void SetHand(Hand hand)
    {
        if (currentHand)
        {
            currentHand.ReleasePoint();
        }
        currentHand = hand;
    }

    public void ClearHand()
    {
        currentHand = null;
    }
}

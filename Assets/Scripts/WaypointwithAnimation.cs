using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WaypointwithAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    //private float dirX = 0f;
    //private float dirY = 0f;
    private enum MovementState { idle, right, left, top, bottom };
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState(waypoints[currentWaypointIndex].transform.position);
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }   
           
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        
    }
    private void UpdateAnimationState(Vector2 targetPosition)
    {
        MovementState state;
        state = MovementState.idle;
        //Check running player
        Debug.Log((int)targetPosition.x + " " + (int)transform.position.x);
        
        if ((int)targetPosition.x >= (int)transform.position.x)
        {
            // tomove right
            state = MovementState.right;

        }
        else if ((int)targetPosition.x <= (int)transform.position.x)
        {
            // tomove left
            state = MovementState.left;
        }

      /*  else if ((int)targetPosition.y == (int)transform.position.y)
        {
            // tomove top
            state = MovementState.top;
        }
        else if ((int)targetPosition.y == (int)transform.position.y)
        {
            // tomove bottom
            state = MovementState.bottom;
        }*/
        anim.SetInteger("state", (int)state);
    }
}

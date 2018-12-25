using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float timeBetweenMove;
    [SerializeField] float timeToMove;

    private bool moving = false;
    private Vector3 moveDirection;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;

    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if(timeToMoveCounter <0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime; //move the counter down by one update of the screen (very small)
            myRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
    }
}

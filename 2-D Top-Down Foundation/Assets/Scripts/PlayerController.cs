using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed;

    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) //GetAxisRaw takes the input of that very second
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) //GetAxisRaw takes the input of that very second
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        //In order to not make the animations take time to activate (i.e. the player starts moving, but is still in the idle animation for a little while),
        //click on the transition, uncheck "Has Exit Time," uncheck "Fixed Duration," and set "Transition Duration" to 0. Supposedly, "Transition Duration
        //is what causes this the most.
    }
}
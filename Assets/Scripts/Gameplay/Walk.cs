using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private int destination = 0;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.autoBraking = false; //No breaking at all
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance != null)
        {
            if (GameManager.instance.clickCount == 0) //If not being clicked on
            {
                //Walk animation
                anim.SetInteger("Walk", 1);
                Debug.Log("Pet is walking");
                // Choose the next destination point when the agent gets
                // close to the current one.
                if (!nav.pathPending && nav.remainingDistance < 0.5f)
                {
                    GoToNextPoint();
                }
            }
            else
            {
                anim.SetInteger("Walk", 0);
            }
        }
        
    }

    public void GoToNextPoint()
    {
        Debug.Log("Pet is moving to next point");
        //If no more points to travel to, return
        if(GameManager.instance != null)
        {
            if (GameManager.instance.walkPoints.Length == 0)
            {
                return;
            }
            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            nav.destination = GameManager.instance.walkPoints[destination].position;

            destination = (destination + 1) % GameManager.instance.walkPoints.Length;
        }
    }
}

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
        if (GameManager.instance.clickCount == 0) //If not being clicked on
        {
            anim.SetInteger("Walk", 1);

            if(!nav.pathPending && nav.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }
    }

    public void GoToNextPoint()
    {
        if(GameManager.instance.walkPoints.Length == 0)
        {
            return;
        }

        nav.destination = GameManager.instance.walkPoints[destination].position;

        destination = (destination + 1) % GameManager.instance.walkPoints.Length;
    }
}

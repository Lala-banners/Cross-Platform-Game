using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Pet Behaviours
public enum PetAI
{
    walk,
    feed,
    play,
}

public class StateMachine : MonoBehaviour
{
    [Header("Walk State Stats")]
    private NavMeshAgent nav;
    private Animator anim;
    private int destination = 0;

    //Pet States
    public PetAI state;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.autoBraking = false; //No breaking at all

        NextState();
    }

    #region IEnumerator States
    private IEnumerator walkState()
    {
        while(state == PetAI.walk)
        {
            yield return null;

            if (_GameManager.instance != null)
            {
                if (_GameManager.instance.clickCount == 0) //If not being clicked on, move around the floor
                {
                    //Walk animation
                    anim.SetInteger("Walk", 1);
                    //Debug.Log("Pet is walking");
                    WalkState();
                }
                else
                {
                    //Stop walking
                    anim.SetInteger("Walk", 0);
                }
            }
        }

        NextState();
    }

    private IEnumerator feedState()
    {
        while(state == PetAI.feed)
        {
            //Feeding Pet Code Here
            //Make pet move to start position, then put in feed state
            yield return null;
        }
        NextState();
    }

    private IEnumerator playState()
    {
        while(state == PetAI.play)
        {
            //Throw ball code here!
            yield return null;
        }

        NextState();
    }
    #endregion

    #region Functions
    public void WalkState()
    {
        Debug.Log("Pet is moving to next point");
        //If no more points to travel to, return
        if (_GameManager.instance != null)
        {
            if (Vector3.Distance(_GameManager.instance.walkPoints[destination].transform.position, transform.position) < 0.5f)
            {
                destination++;

                if (destination >= _GameManager.instance.walkPoints.Length)
                {
                    destination = 0;
                }
            }
            nav.destination = Vector3.MoveTowards(transform.position, _GameManager.instance.walkPoints[destination].transform.position, Time.deltaTime * nav.speed);
        }
    }
    #endregion

    //Function for calling the next state for pets
    private void NextState()
    {
        //Work out the name of the method to run
        string methodName = state.ToString() + "State"; //If current state is "walk" then this returns "walkState"
                                                        //gives a variable so run a method using its name
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        //Run our method
        StartCoroutine((IEnumerator)info.Invoke(this, null));
        //Using StartCoroutine() means we can leave and come back to the method that is running
        //All Coroutines must return IEnumerator
    }
}

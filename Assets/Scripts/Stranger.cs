using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stranger : MonoBehaviour
{
    bool helpful = false;
    bool timeToDump = false;

    public int influencedGoal = 5;
    public int currentTrash = 0;
    public int trashLimit = 5;

    public int trashPresentStranger;

    Vector3 trashFinder;
    Vector3 trashCanFinder;
    //Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //currentPos = transform.position;
        //trashPresentStranger = Trash_Loader.allOfTrash.trashPresent;

        trashFinder = GameObject.FindGameObjectWithTag("Trash").transform.position;
        trashCanFinder = GameObject.FindGameObjectWithTag("Trash Can").transform.position;

        if(Player.cleanMan.influence >= influencedGoal)
        {
            helpful = true;
        }

        if(helpful == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, trashFinder, 0.1f);
        }

        if(currentTrash >= trashLimit)
        {
            helpful = false;
            timeToDump = true;
        }

        if(timeToDump == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, trashCanFinder, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
            currentTrash += 1;
            Player.cleanMan.trashAmountStartPlayer -= 1;
        }

        if (collision.gameObject.tag == "Trash Can")
        {
            Player.cleanMan.influence += currentTrash;
            currentTrash = 0;
            timeToDump = false;
            helpful = true;


        }
    }
}

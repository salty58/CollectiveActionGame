using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player cleanMan;

    float horizontal;
    float vertical;

    float runSpeed = 5f;

    public int currentTrash = 0;
    public int trashLimit = 5;
    public int influence = 0;

    //public int trashPresentPlayer;
    public int trashAmountStartPlayer = 25;

    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        cleanMan = this;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //trashPresentPlayer = Trash_Loader.allOfTrash.trashPresent;
        //trashAmountStartPlayer = Trash_Loader.allOfTrash.trashAmountStart;

        if(trashAmountStartPlayer == 0)
        {
            SceneManager.LoadScene("Winner");
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
            currentTrash += 1;
            trashAmountStartPlayer -= 1;
        }

        if(collision.gameObject.tag == "Trash Can")
        {
            influence += currentTrash;
            currentTrash = 0;
            //currentTrash = 0;
            
        }
    }
}

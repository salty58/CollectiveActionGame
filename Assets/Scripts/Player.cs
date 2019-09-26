using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player cleanMan;

    float horizontal;
    float vertical;

    float runSpeed = 5f;

    public  int currentTrash = 0;
    public  int trashLimit = 5;

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
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trash" && currentTrash < 5)
        {
            Destroy(collision.gameObject);
            currentTrash += 1;
        }

        if(collision.gameObject.tag == "Trash Can")
        {
            currentTrash = 0;
        }
    }
}

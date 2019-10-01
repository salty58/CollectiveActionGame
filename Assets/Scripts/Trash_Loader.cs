using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trash_Loader : MonoBehaviour
{
    public static Trash_Loader allOfTrash;

    public GameObject trashPiece;
    Vector3 position;

    public int trashPresent;
    public int trashAmountStart;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Player.cleanMan.trashAmountStartPlayer; i++)
        {
            position = new Vector3(Random.Range(-8.07f, 9.11f), Random.Range(-4.55f, 30f), 0);
            Instantiate(trashPiece, position, Quaternion.identity);
            trashPresent++;
            trashAmountStart++;
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Player.cleanMan.influence == trashAmountStart)
        {
            SceneManager.LoadScene("Winner");
        }
        */
    }
}

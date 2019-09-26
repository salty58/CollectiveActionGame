using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash_Holder : MonoBehaviour
{
    string trashIndicator;
    Text wordText;

    // Start is called before the first frame update
    void Start()
    {
        wordText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        trashIndicator = Player.cleanMan.currentTrash + "/" + Player.cleanMan.trashLimit;
        wordText.text = trashIndicator;
    }
}

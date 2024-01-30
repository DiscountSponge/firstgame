using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item_Collector : MonoBehaviour
{
    private int cherries = 0;
    public TMP_Text cherriesText;
    private string x;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;

            cherriesText.text = "Cherries" + cherries;
        }
    }
    private void Start()
    {
        

    }
}
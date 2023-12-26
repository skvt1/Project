using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaBuffer : MonoBehaviour
{
    private readonly Dialogue Bd;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            player.GetComponent<Dialogue>().sentences = collision.gameObject.GetComponent<Dialogue>().sentences;
        }
        
        
    }
}



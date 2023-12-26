using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class React : MonoBehaviour
{
    [SerializeField]
    private Button dial;
    private Button diabutton;
    [SerializeField]
    private Vector3 offset;
    private Transform playerPos;
    private DialogueScript manager;

    private bool isButtonSpawned = false;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {

            manager.SetImage(collision.name);
            Debug.Log("&");
            string finder = "Prefabs/"+collision.name+"D1";
            dial = Resources.Load<GameObject>(finder).GetComponent<Button>();
            diabutton = Instantiate(dial, GameObject.Find("Canvas").transform);
            diabutton.transform.position = playerPos.transform.position + offset;
            diabutton.gameObject.SetActive(true);
            isButtonSpawned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (diabutton == null)
        {
        }
        else
        {
            if (collision.gameObject.CompareTag("NPC"))
                if (isButtonSpawned)
                {
                    Destroy(diabutton.gameObject);
                    isButtonSpawned = false;
                }
        }
    }  
}
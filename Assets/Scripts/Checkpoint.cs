using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;

    public static Vector3 currentCheckpointPos;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Checkpoint Reached " + gameObject.transform.position);
            currentCheckpointPos = gameObject.transform.position;
        }
    }
}

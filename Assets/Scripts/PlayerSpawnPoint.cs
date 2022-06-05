using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnPoint : MonoBehaviour
{
    GameObject checkpoint;
    public event Action CheckpointEvent;
    static bool playerDied = false;
    private void Start()
    {
        checkpoint = FindObjectOfType<Checkpoint>().gameObject;
        if (playerDied == true)
        {
            gameObject.transform.position = Checkpoint.currentCheckpointPos;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Fatal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerDied = true;
        }
    }
}

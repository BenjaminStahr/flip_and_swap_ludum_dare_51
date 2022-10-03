using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CurrentLevel.CurrentLevelID == 6) 
            {
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
            GameObject.FindGameObjectWithTag("Game").GetComponent<PlaySounds>().levelClear.Play();
            CurrentLevel.CurrentLevelID++;
        }
    }
}

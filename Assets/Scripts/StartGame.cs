using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject darkOverlay;
    public AudioSource startSound;
    public float startingDelay;
    public bool gameHasBeenStarted;
    public string firstSceneName;



    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !gameHasBeenStarted) {
            OnStartPressed();
        }
    }

    void OnStartPressed() {
        // start game with delay
        Invoke("LoadFirstLevel", startingDelay);

        // play sound
        startSound.Play();

        // activate overlay
        darkOverlay.SetActive(true);

        // remark that game is started
        gameHasBeenStarted = true;
    }

    void LoadFirstLevel() {
        SceneManager.LoadScene(firstSceneName);
    }
}

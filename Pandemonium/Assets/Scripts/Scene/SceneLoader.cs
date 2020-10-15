using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public bool change = false;

    // Update is called once per frame
    void Update()
    {
        // If mini-game ending condition is met, change scene!
        // We don't necessarily need the update function for this, I only used it for testing purposes.
        if (change)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int buildIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(buildIndex);
    }
}

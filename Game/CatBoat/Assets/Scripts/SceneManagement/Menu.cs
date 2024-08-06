using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject tutorialCanvas;
    [SerializeField] AudioClip buttonNoise;

    AudioSource buttonSource;

    private void Start()
    {
        buttonSource = GetComponent<AudioSource>();
        buttonNoise = null;
    }

    public void Play()
    {
        StartCoroutine(PlayCR());
    }

    public void TutorialOpen()
    {
        buttonSource.PlayOneShot(buttonNoise);

        tutorialCanvas.SetActive(true);
        Debug.Log("Tutorial Open");
    }

    public void TutorialClosed()
    {
        buttonSource.PlayOneShot(buttonNoise);

        tutorialCanvas.SetActive(false);
        Debug.Log("Tutorial Closed");
    }

    public void Quit()
    {
        StartCoroutine (QuitCR());
       
    }

    IEnumerator PlayCR()
    {
        buttonSource.PlayOneShot(buttonNoise);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Ocean");
        Debug.Log("Game Is Playing");
    }

    IEnumerator QuitCR()
    {
        buttonSource.PlayOneShot(buttonNoise);

        yield return new WaitForSeconds(1);

        Application.Quit();
        Debug.Log("Game Quitted");
    }
}


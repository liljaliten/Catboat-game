using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMap : MonoBehaviour
{
    //Minimap m�ste komma ih�g vart du tidigare va
    //ska �ven ha en fin transition mellan �arna eller n�t som indikerar att du �ker till den som en flagga eller n�tt
    //kan g�ra en separat minimap script f�r varje scen f�r att f� den att veta vart du tidigare va

    [SerializeField] AudioClip buttonNoise;

    AudioSource buttonSource;

    [SerializeField] bool ocean;
    [SerializeField] bool bay;
    [SerializeField] bool mangrove;

    [SerializeField] GameObject OceanMarker;
    [SerializeField] GameObject BayMarker;
    [SerializeField] GameObject MangroveMarker;

    private void Start()
    {
        //trigga en effekt f�r transition
        buttonSource = GetComponent<AudioSource>();
        buttonNoise = null;

        if (ocean == true)
        {
            OceanMarker.SetActive(true);
        }
        else { OceanMarker.SetActive(false); }

        if (bay == true)
        {
            BayMarker.SetActive(true);
        }
        else {  BayMarker.SetActive(false); }

        if(mangrove == true) 
        {
            MangroveMarker.SetActive(true);
        }
        else {  MangroveMarker.SetActive(false);}
    }

    public void OceanSelected()
    {
        StartCoroutine(Ocean());
    }

    public void BaySelected()
    {
      StartCoroutine(Bay());   
    }

    public void MangroveSelected()
    {
        StartCoroutine(Mangrove());
    }

    IEnumerator Ocean()
    {
        buttonSource.PlayOneShot(buttonNoise);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Ocean");
        Debug.Log("Ocean Is Active");
    }

    IEnumerator Bay()
    {
        buttonSource.PlayOneShot(buttonNoise);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Bay");
        Debug.Log("Bay Is Active");
    }

    IEnumerator Mangrove()
    {
        buttonSource.PlayOneShot(buttonNoise);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Mangrove");
        Debug.Log("Mangrove Is Active");
    }
}

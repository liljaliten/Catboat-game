using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMap : MonoBehaviour
{
    //Minimap måste komma ihåg vart du tidigare va
    //ska även ha en fin transition mellan öarna eller nåt som indikerar att du åker till den som en flagga eller nått
    //kan göra en separat minimap script för varje scen för att få den att veta vart du tidigare va

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
        //trigga en effekt för transition
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

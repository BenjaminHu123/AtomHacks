using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSans : MonoBehaviour
{
    public GameObject sans;
    private bool sansActive = false;
    // Start is called before the first frame update
    void Start()
    {
        sans.SetActive(false);
    }

    void Updtate()
    {

    }
    // Update is called once per frame
    public void sansAction()
    {
        sans.SetActive(true);
    }
}

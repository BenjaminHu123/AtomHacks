﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
            SceneManager.LoadScene("Level1");
    }
}

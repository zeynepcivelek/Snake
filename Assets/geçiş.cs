﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class geçiş : MonoBehaviour
{

    public void Button()
    {
        Application.LoadLevel("Main");

    }
    public void exitGame()
    {
        Application.Quit();


    }
}

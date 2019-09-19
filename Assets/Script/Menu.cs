using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagingButton : MonoBehaviour
{
    public void reloadCurrentScene()
    {
        
<<<<<<< Updated upstream
        //Destroy(GameObject.Find("DoctorPlayer"));
        //Destroy(GameObject.Find("UI"));
        //Destroy(GameObject.Find("UI(Clone)"));
        //Destroy(GameObject.Find("DoctorPlayer(Clone)"));
        Destroy(GameObject.FindGameObjectWithTag("UI"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
=======
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("UI"));
>>>>>>> Stashed changes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void goBackToMenu()
    {
<<<<<<< Updated upstream
        //Destroy(GameObject.Find("DoctorPlayer"));
        //Destroy(GameObject.Find("UI"));
        //Destroy(GameObject.Find("UI(Clone)"));
        //Destroy(GameObject.Find("DoctorPlayer(Clone)"));
        Destroy(GameObject.FindGameObjectWithTag("UI"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
=======
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("UI"));
>>>>>>> Stashed changes
        SceneManager.LoadScene(0);
    }
}

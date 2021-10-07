//Code referenced from Lab Exercises and Lectures

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class DLLRestore : MonoBehaviour
{
    //Import DLL
    [DllImport("Quiz DLL Restore 2")]

    //Call the function
    private static extern int RestoreGameWorld();


    // Start is called before the first frame update
    void Start()
    {
        //Print statment notifying that the game world has been fixed
        print("Game World Restored");

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}

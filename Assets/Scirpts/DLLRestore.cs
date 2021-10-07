using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DLLRestore : MonoBehaviour
{

    [DllImport("Quiz DLL Restore 2")]

    private static extern int RestoreGameWorld();


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(RestoreGameWorld());

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start() 
    {
        var window = new Window();
        window.SetTitle("Hello World");
        window.SetSize(200, 100);
    }
}

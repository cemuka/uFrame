using UnityEngine;
using com.uFrame;
using com.uFrame.Widgets;

public class Test : MonoBehaviour
{
    private void Start() 
    {
        uFrame.Init();

        var window = new Window();
        window.SetTitle("Hello World");
        window.SetSize(200, 200);

        var button = new ButtonWidged("click me");
        window.root.Add(button);

        var button2 = new ButtonWidged("hit me");
        window.root.Add(button2);
    }
}

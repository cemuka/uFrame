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
        window.SetSize(200, 160);

        var label = new TextWidget("my label");
        window.root.Add(label);

        var button = new ButtonWidget("hit me");
        window.root.Add(button);

        window.rootLayout.childAlignment = TextAnchor.MiddleCenter;
    }
}

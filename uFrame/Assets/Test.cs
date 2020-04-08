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
        window.SetSize(250, 200);

        window.root.Add(new ButtonWidget("Hello Button"));
        
        // var hbox = new HBoxWidget();
        // hbox.SetColor(Color.red);
        // hbox.FillOccupiedContainer();
        // // hbox.SetSize(200, 200);
        // window.root.Add(hbox);
        // var vbox1 = new VBoxWidget();
        // vbox1.SetSize(50, 50);
        // var vbox2 = new VBoxWidget();
        // vbox2.SetSize(50, 50);

        // vbox1.SetColor(Color.blue);
        // vbox2.SetColor(Color.cyan);

        // hbox.root.Add(vbox1);
        // hbox.root.Add(vbox2);

        // vbox1.root.Add(new ButtonWidget("hit me button"));
        // vbox1.SetChildOrientation(TextAnchor.MiddleCenter);
    }
}

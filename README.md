# uFrame
an experimental and programmatic approach to make floating and dragging windows in unity based on Unity UI.
```csharp
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

```
![screenshot](./screenshot.png)
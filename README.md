# uFrame
an experimental and programmatic approach to make floating and dragging windows in unity based on Unity UI.
```csharp
    private void Start() 
    {
        uFrame.Init();

        var window = new Window();
        window.SetTitle("Hello World");
        window.SetSize(200, 160);

        var button = new ButtonWidget("Hello Button");
        window.root.Add(button);
    }
```
![screenshot](./screenshot.png)
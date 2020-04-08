using com.uFrame;
using com.uFrame.Utils;
using com.uFrame.Widgets;
using UnityEngine;
using UnityEngine.UI;

public class VBoxWidget : WidgetBase
{
    private VerticalLayoutGroup layout;
    private Image background;

    public VBoxWidget()
    {
        root = new ElementRoot();

        var boxGO = new GameObject("VBox");
        var boxRect = boxGO.AddComponent<RectTransform>();
        root.transform = boxRect;
        
        background = boxGO.AddComponent<Image>();
        background.color = Color.white;

        layout = boxGO.AddComponent<VerticalLayoutGroup>();
        layout.childControlHeight = false;
        layout.childControlWidth = false;
        layout.childForceExpandHeight = false;
        layout.childForceExpandWidth = false;
        layout.spacing = 6;
        layout.SetLayoutVertical();
    }

    public void ExpandHomogeneus()
    {
        layout.childControlHeight = true;
        layout.childControlWidth = true;
        layout.childForceExpandHeight = true;
        layout.childForceExpandWidth = true;
        layout.spacing = 6;
    }

    public void SetChildOrientation(TextAnchor textAnchor)
    {
        layout.childAlignment = textAnchor;
    }

    public void SetColor(Color color)
    {
        background.color = color;
    }

    public void SetSize(int width, int height)
    {
        var rect = root.transform as RectTransform;
        rect.sizeDelta = new Vector2(width, height);
    }
}
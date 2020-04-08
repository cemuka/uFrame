using com.uFrame;
using com.uFrame.Utils;
using com.uFrame.Widgets;
using UnityEngine;
using UnityEngine.UI;

public class HBoxWidget : WidgetBase
{
    private HorizontalLayoutGroup layout;
    private Image background;
    private bool containerOccupied = false;

    public HBoxWidget(float spacing) : this()
    {
        layout.spacing = 6;
    }

    public HBoxWidget()
    {
        root = new ElementRoot();

        var boxGO = new GameObject("HBox");
        var boxRect = boxGO.AddComponent<RectTransform>();
        root.transform = boxRect;

        background = boxGO.AddComponent<Image>();
        background.color = Color.white;

        layout = boxGO.AddComponent<HorizontalLayoutGroup>();
        layout.childControlHeight = false;
        layout.childControlWidth = false;
        layout.childForceExpandHeight = false;
        layout.childForceExpandWidth = false;
        layout.SetLayoutHorizontal();
    }

    public void ExpandChildsHorizontally()
    {
        layout.childControlWidth = true;
        layout.childForceExpandWidth = true;
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
        root.transform.sizeDelta = new Vector2(width, height);
    }

    public void FillOccupiedContainer()
    {
        root.transform.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
        root.transform.anchorMax = Vector2.one;
        root.transform.Right(0f);                     //set manually full stretch
        root.transform.Left(0f);
        root.transform.Bottom(0f);
        root.transform.Top(0f);
    }

    
}
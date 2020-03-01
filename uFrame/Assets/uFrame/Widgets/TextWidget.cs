using com.uFrame;
using com.uFrame.Widgets;
using UnityEngine;
using UnityEngine.UI;

public class TextWidget : WidgetBase
{
    public Text text;
    public RectTransform textRect;

    public TextWidget(string txt) : this()
    {
        text.text = txt;
    }

    public TextWidget()
    {
        root = new ElementRoot();

        var titleGO = new GameObject("Title Text");
        var textRect = titleGO.AddComponent<RectTransform>();

        root.transform = textRect;
        root.transform.sizeDelta = new Vector2(100, 30);
        root.transform.anchoredPosition = Vector2.zero;

        titleGO.transform.SetParent(root.transform);
        text = titleGO.AddComponent<Text>();
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
    }
}
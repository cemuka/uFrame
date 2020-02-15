using UnityEngine;
using UnityEngine.UI;
using com.uFrame.Utils;

namespace com.uFrame.Widgets
{
    public class ButtonWidged : WidgetBase
    {
        public Button button;
        public Text buttonTitleText;
        public RectTransform buttonTitleRect;

        public ButtonWidged(string text) : this ()
        {
            buttonTitleText.text = text;
        }

        public ButtonWidged()
        {
            root = new ElementRoot();

            var buttonGO    = new GameObject("Button");
            var buttonRect  = buttonGO.AddComponent<RectTransform>();
            var buttonImage = buttonGO.AddComponent<Image>();
            
            root.transform = buttonRect;

            buttonImage.color = Color.gray;
            button = buttonGO.AddComponent<Button>();
            button.targetGraphic = buttonImage;
            root.transform.sizeDelta = new Vector2(100, 30);
            root.transform.anchoredPosition = Vector2.zero;

            var titleGO = new GameObject("Title Text");
            var titleRect = titleGO.AddComponent<RectTransform>();
            titleGO.transform.SetParent(root.transform);
            titleRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            titleRect.anchorMax = Vector2.one;
            titleRect.Right(0f);                     //set manually full stretch
            titleRect.Left(0f);
            titleRect.Bottom(0f);
            titleRect.Top(0f);
            buttonTitleText = titleGO.AddComponent<Text>();
            buttonTitleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            buttonTitleText.alignment = TextAnchor.MiddleCenter;
        }
    }


}


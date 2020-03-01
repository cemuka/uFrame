using UnityEngine;
using UnityEngine.UI;
using com.uFrame.Utils;

namespace com.uFrame.Widgets
{
    public class ButtonWidget : WidgetBase
    {
        private Button button;
        private Text buttonTitleText;
        private RectTransform buttonTitleRect;

        public ButtonWidget(string text) : this ()
        {
            buttonTitleText.text = text;
        }

        public ButtonWidget()
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
            titleGO.transform.SetParent(root.transform);
            
            buttonTitleRect = titleGO.AddComponent<RectTransform>();
            buttonTitleRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            buttonTitleRect.anchorMax = Vector2.one;
            buttonTitleRect.Right(0f);                     //set manually full stretch
            buttonTitleRect.Left(0f);
            buttonTitleRect.Bottom(0f);
            buttonTitleRect.Top(0f);
            buttonTitleText = titleGO.AddComponent<Text>();
            buttonTitleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            buttonTitleText.alignment = TextAnchor.MiddleCenter;
        }
    
        public Button GetButtonComponent() => button;
        public Text   GetTextComponent() => buttonTitleText;
    }
}


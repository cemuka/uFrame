using UnityEngine;
using UnityEngine.UI;
using com.uFrame.Utils;
using UnityEngine.Events;

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
            buttonImage.sprite = uFrame.configuration.body;
            buttonImage.type = Image.Type.Sliced;
            
            root.transform = buttonRect;

            buttonImage.color = Color.gray;
            button = buttonGO.AddComponent<Button>();
            button.targetGraphic = buttonImage;
            root.transform.sizeDelta = new Vector2(120, 40);
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
            buttonTitleText.font = uFrame.configuration.defaultFont;
            buttonTitleText.alignment = TextAnchor.MiddleCenter;
        }
    
        public void AddListener(UnityAction action)
        {
            button.onClick.AddListener(action);
        }

        public Button GetButtonComponent() => button;
        public Text   GetTextComponent() => buttonTitleText;

    }
}


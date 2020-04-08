using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using com.uFrame.Utils;
using com.uFrame.Widgets;

namespace com.uFrame
{
    public class Window 
    {
        public ElementRoot root;

        private Text titleText;

        private GameObject _window;
        private GameObject _windowBase;
        private GameObject _header;
        private GameObject _body;

        private RectTransform _windowRect;
        private RectTransform _windowBaseRect;
        private RectTransform _headerRect;
        private RectTransform _bodyRect;

        private Canvas _canvas;
        private Vector2 _windowSize;

        private Color _headerColor = new Color(0.84f, 0.84f, 0.84f);
        private Color _closeButtonColor = new Color(0.90f, 0.40f, 0.40f);

        private Button closeButton;

        public Window()
        {
            var config = uFrame.configuration;
            _canvas = uFrame.mainCanvas;
            root = new ElementRoot();
            //create window object as a child in the canvas
            _window = new GameObject("Window");
            _window.AddComponent<RectTransform>();
            _window.transform.SetParent(_canvas.transform);
            var windowImage = _window.AddComponent<Image>();
            windowImage.color = _headerColor;
            windowImage.sprite = config.body;
            windowImage.type = Image.Type.Sliced;
            SetSize(300, 400);
            SetPosition(0, 0);

            //create base game object
            _windowBase = new GameObject("Base");
            _windowBase.AddComponent<RectTransform>();
            _windowBase.transform.SetParent(_window.transform);
            _windowBaseRect = _windowBase.transform as RectTransform;
            _windowBaseRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            _windowBaseRect.anchorMax = Vector2.one;
            _windowBaseRect.Right(0f);                     //set manually full stretch
            _windowBaseRect.Left(0f);
            _windowBaseRect.Bottom(0f);
            _windowBaseRect.Top(0f);

            //create header
            _header = new GameObject("Header");
            _headerRect = _header.AddComponent<RectTransform>();
            _header.transform.SetParent(_windowBase.transform);
            _headerRect.pivot = new Vector2(.5f, 1);
            _headerRect.anchorMin = new Vector2(0f, 1f);
            _headerRect.anchorMax = new Vector2(1f, 1f);
            _headerRect.sizeDelta = new Vector2(0f, config.headerHeight);
            _headerRect.anchoredPosition = Vector2.zero;

            //      header drag ability
            var drag = _header.AddComponent<DragPanel>();
            drag.Init(_canvas.transform, _window.transform);

            //      header title
            var titleGO = new GameObject("Title Text");
            var titleRect = titleGO.AddComponent<RectTransform>();
            titleGO.transform.SetParent(_header.transform);
            titleRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            titleRect.anchorMax = Vector2.one;
            titleRect.Right(0f);                     //set manually full stretch
            titleRect.Left(0f);
            titleRect.Bottom(0f);
            titleRect.Top(0f);
            titleText = titleGO.AddComponent<Text>();
            titleText.font = config.defaultFont;
            titleText.alignment = TextAnchor.MiddleCenter;
            SetTitle("Window");

            //      header close button
            var closeButtonGO = new GameObject("Close Button");
            var closeButtonRect = closeButtonGO.AddComponent<RectTransform>();
            closeButtonGO.transform.SetParent(_header.transform);
            closeButtonRect.pivot = new Vector2(1f, 1f);
            closeButtonRect.anchorMin = new Vector2(1f, 1f);
            closeButtonRect.anchorMax = new Vector2(1f, 1f);
            closeButtonRect.sizeDelta = new Vector2(15, 15);
            closeButtonRect.anchoredPosition = new Vector2(-7.5f,-7.5f);

            closeButton = closeButtonGO.AddComponent<Button>();
            var closeImage = closeButtonGO.AddComponent<Image>();
            closeImage.color = _closeButtonColor;
            closeImage.sprite = config.headerButton;
            closeButton.targetGraphic = closeImage;

            //create body
            _body = new GameObject("Body");
            _body.transform.SetParent(_windowBase.transform);
            _bodyRect = _body.AddComponent<RectTransform>();
            _bodyRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            _bodyRect.anchorMax = Vector2.one;
            _bodyRect.Right(config.windowContentPadding);                     //set manually full stretch
            _bodyRect.Left(config.windowContentPadding);
            _bodyRect.Bottom(config.windowContentPadding);
            _bodyRect.Top(config.headerHeight);
            var bodyImage = _body.AddComponent<Image>();
            bodyImage.sprite = config.body;
            bodyImage.type = Image.Type.Sliced;

            // rootLayout = _body.AddComponent<VerticalLayoutGroup>();
            // rootLayout.childControlHeight = true;
            // rootLayout.childControlWidth = true;
            // rootLayout.childForceExpandHeight = true;
            // rootLayout.childForceExpandWidth = true;
            // rootLayout.spacing = 6;


            root.transform = _bodyRect;

            
        }

        public void SetSize(int width, int height)
        {
            _windowRect = _window.transform as RectTransform;
            _windowRect.sizeDelta = new Vector2(width, height);
        }

        public void SetPosition(float posX, float posY)
        {
            _windowRect = _window.transform as RectTransform;
            _windowRect.localPosition = new Vector3(posX, posY, 0);
        }

        public void SetTitle(string title)
        {
            titleText.text = title;
        }

        public void AddListenerToCloseButton(System.Action callback)
        {
            closeButton.onClick.AddListener(() => callback());
        }

        public void Destroy()
        {
            GameObject.Destroy(_window.gameObject);
        }
    }
}
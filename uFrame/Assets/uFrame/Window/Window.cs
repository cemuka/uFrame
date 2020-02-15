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
        public VerticalLayoutGroup rootLayout;

        private Text titleText;

        private GameObject window;
        private GameObject windowBase;
        private GameObject header;
        private GameObject body;

        private RectTransform windowRect;
        private RectTransform windowBaseRect;
        private RectTransform headerRect;
        private RectTransform bodyRect;

        private Canvas _canvas;
        private Vector2 windowSize;

        private Color headerColor = new Color(0.84f, 0.84f, 0.84f);
        private Color closeButtonColor = new Color(0.90f, 0.40f, 0.40f);

        private Button closeButton;

        public Window()
        {
            _canvas = uFrame.mainCanvas;
            root = new ElementRoot();
            //create window object as a child in the canvas
            window = new GameObject("Window");
            window.AddComponent<RectTransform>();
            window.transform.SetParent(_canvas.transform);
            var windowImage = window.AddComponent<Image>();
            windowImage.color = headerColor;
            SetSize(300, 400);
            SetPosition(0, 0);

            //create base game object
            windowBase = new GameObject("Base");
            windowBase.AddComponent<RectTransform>();
            windowBase.transform.SetParent(window.transform);
            windowBaseRect = windowBase.transform as RectTransform;
            windowBaseRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            windowBaseRect.anchorMax = Vector2.one;
            windowBaseRect.Right(0f);                     //set manually full stretch
            windowBaseRect.Left(0f);
            windowBaseRect.Bottom(0f);
            windowBaseRect.Top(0f);

            //create header
            header = new GameObject("Header");
            headerRect = header.AddComponent<RectTransform>();
            header.transform.SetParent(windowBase.transform);
            headerRect.pivot = new Vector2(.5f, 1);
            headerRect.anchorMin = new Vector2(0f, 1f);
            headerRect.anchorMax = new Vector2(1f, 1f);
            headerRect.sizeDelta = new Vector2(0f, 40f);
            headerRect.anchoredPosition = Vector2.zero;

            //      header drag ability
            var drag = header.AddComponent<DragPanel>();
            drag.Init(_canvas.transform, window.transform);

            //      header title
            var titleGO = new GameObject("Title Text");
            var titleRect = titleGO.AddComponent<RectTransform>();
            titleGO.transform.SetParent(header.transform);
            titleRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            titleRect.anchorMax = Vector2.one;
            titleRect.Right(0f);                     //set manually full stretch
            titleRect.Left(0f);
            titleRect.Bottom(0f);
            titleRect.Top(0f);
            titleText = titleGO.AddComponent<Text>();
            titleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            titleText.alignment = TextAnchor.MiddleCenter;
            SetTitle("Window");

            //      header close button
            var closeButtonGO = new GameObject("Close Button");
            var closeButtonRect = closeButtonGO.AddComponent<RectTransform>();
            closeButtonGO.transform.SetParent(header.transform);
            closeButtonRect.anchoredPosition = new Vector2(-4f, 0);
            closeButtonRect.sizeDelta = new Vector2(20, 20);
            closeButtonRect.pivot = new Vector2(1, .5f);
            closeButtonRect.anchorMin = new Vector2(1, .5f);
            closeButtonRect.anchorMax = new Vector2(1f, .5f);

            closeButton = closeButtonGO.AddComponent<Button>();
            var closeImage = closeButtonGO.AddComponent<Image>();
            closeImage.color = closeButtonColor;
            closeButton.targetGraphic = closeImage;

            //create body
            body = new GameObject("Body");
            body.transform.SetParent(windowBase.transform);
            bodyRect = body.AddComponent<RectTransform>();
            bodyRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
            bodyRect.anchorMax = Vector2.one;
            bodyRect.Right(4f);                     //set manually full stretch
            bodyRect.Left(4f);
            bodyRect.Bottom(4f);
            bodyRect.Top(40f);


            rootLayout = body.AddComponent<VerticalLayoutGroup>();
            rootLayout.childControlHeight = false;
            rootLayout.childControlWidth = false;
            rootLayout.childForceExpandHeight = false;
            rootLayout.childForceExpandWidth = false;
            rootLayout.spacing = 6;


            root.transform = bodyRect;

            body.AddComponent<Image>();
        }

        public void SetSize(int width, int height)
        {
            windowRect = window.transform as RectTransform;
            windowRect.sizeDelta = new Vector2(width, height);
        }

        public void SetPosition(float posX, float posY)
        {
            windowRect = window.transform as RectTransform;
            windowRect.localPosition = new Vector3(posX, posY, 0);
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
            GameObject.Destroy(window.gameObject);
        }
    }
}
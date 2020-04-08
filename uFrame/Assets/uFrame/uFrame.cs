using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using com.uFrame.Widgets;
using com.uFrame.Utils;
using System;

namespace com.uFrame
{
    public class uFrame
    {
        public static Canvas mainCanvas;
        public static GameObject eventSystemGO;
        public static Configuration configuration;

        public static void Init()
        {
            //init resources
            var configResource = Resources.Load<uFrameConfiguration>("Configuration");
            configuration = configResource.configuration;

            //create a canvas object in the scene
            var canvasGO = new GameObject("uFrame Canvas");
            mainCanvas = canvasGO.AddComponent<Canvas>();
            mainCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();

            if (GameObject.FindObjectOfType<EventSystem>() == null)
            {    
                eventSystemGO = new GameObject("EventSystem");
                eventSystemGO.AddComponent<EventSystem>();
                eventSystemGO.AddComponent<StandaloneInputModule>();
            }
        }
    }

    public class ElementRoot
    {
        public RectTransform transform;

        public void Add(WidgetBase widget)
        {
            widget.root.transform.SetParent(transform);
            widget.root.transform.anchoredPosition = Vector2.zero;

            // if (widget is VBoxWidget || widget is HBoxWidget)
            // {
            //     widget.root.transform.anchorMin = Vector2.zero;     //set anchor min max to be able to stretch
            //     widget.root.transform.anchorMax = Vector2.one;
            //     widget.root.transform.Right(0f);                    //set manually full stretch
            //     widget.root.transform.Left(0f);
            //     widget.root.transform.Bottom(0f);
            //     widget.root.transform.Top(0f);
            // }
        }
    }
}


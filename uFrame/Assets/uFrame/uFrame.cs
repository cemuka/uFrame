using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using com.uFrame.Widgets;
using System;

namespace com.uFrame
{
    public class uFrame
    {
        public static Canvas mainCanvas;
        public static GameObject eventSystemGO;

        public static void Init()
        {
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
        }
    }
}


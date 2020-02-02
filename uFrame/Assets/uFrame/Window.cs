using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    private Text titleText;

    private GameObject window;
    private GameObject root;
    private GameObject header;
    private GameObject body;

    private RectTransform windowRect;
    private RectTransform rootRect;
    private RectTransform headerRect;
    private RectTransform bodyRect;

    private Canvas _canvas;
    private Vector2 windowSize;

    private Color headerColor = new Color(0.84f, 0.84f, 0.84f);
    private Color closeButtonColor = new Color(0.90f, 0.40f, 0.40f);

    public Window()
    {
        //create a canvas object in the scene
        var canvasGO = new GameObject("uFrame Canvas");
        _canvas = canvasGO.AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        //create window object as a child in the canvas
        window = new GameObject("Window");
        window.AddComponent<RectTransform>();
        window.transform.SetParent(_canvas.transform);
        var windowImage = window.AddComponent<Image>();
        windowImage.color = headerColor;
        SetSize(300, 400);
        SetPosition(0, 0);

        //create root
        root = new GameObject("Root");
        root.AddComponent<RectTransform>();
        root.transform.SetParent(window.transform);
        rootRect = root.transform as RectTransform;
        rootRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
        rootRect.anchorMax = Vector2.one;
        rootRect.Right(0f);                     //set manually full stretch
        rootRect.Left(0f);
        rootRect.Bottom(0f);
        rootRect.Top(0f);

        //create header
        header = new GameObject("Header");
        headerRect = header.AddComponent<RectTransform>();
        header.transform.SetParent(root.transform);
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

        var closeButton = closeButtonGO.AddComponent<Button>();
        var closeImage = closeButtonGO.AddComponent<Image>();
        closeImage.color = closeButtonColor;
        closeButton.targetGraphic = closeImage;

        //create body
        body = new GameObject("Body");
        body.transform.SetParent(root.transform);
        bodyRect = body.AddComponent<RectTransform>();
        bodyRect.anchorMin = Vector2.zero;      //set anchor min max to be able to stretch
        bodyRect.anchorMax = Vector2.one;
        bodyRect.Right(4f);                     //set manually full stretch
        bodyRect.Left(4f);
        bodyRect.Bottom(4f);
        bodyRect.Top(40f);

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
}

public static class RectTransformExtensions
{
    public static RectTransform Left( this RectTransform rt, float x )
    {
        rt.offsetMin = new Vector2( x, rt.offsetMin.y );
        return rt;
    }
 
    public static RectTransform Right( this RectTransform rt, float x )
    {
        rt.offsetMax = new Vector2( -x, rt.offsetMax.y );
        return rt;
    }
 
    public static RectTransform Bottom( this RectTransform rt, float y )
    {
        rt.offsetMin = new Vector2( rt.offsetMin.x, y );
        return rt;
    }
 
    public static RectTransform Top( this RectTransform rt, float y )
    {
        rt.offsetMax = new Vector2( rt.offsetMax.x, -y );
        return rt;
    }
}

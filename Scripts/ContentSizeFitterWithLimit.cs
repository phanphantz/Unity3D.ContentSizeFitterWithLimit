using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[System.Serializable]
[ExecuteAlways]
public class ContentSizeFitterWithLimit : ContentSizeFitter
{
    private bool limitWidth;
    private bool limitHeight;
    private float maxWidth = 500f;
    private float maxHeight = 500f;

    public bool LimitWidth
    {
        get
        {
            return limitWidth;
        }
        set
        {
            limitWidth = value;
            ForceRebuild();
        }
    }

    public float MaxWidth
    {
        get
        {
            return maxWidth;
        }
        set
        {
            maxWidth = value;
            ForceRebuild();
        }
    }

    public bool LimitHeight
    {
        get
        {
            return limitHeight;
        }
        set
        {
            limitHeight = value;
            ForceRebuild();
        }
    }

    public float MaxHeight
    {
        get
        {
            return maxHeight;
        }
        set
        {
            maxHeight = value;
            ForceRebuild();
        }
    }

    private RectTransform rect;

    protected override void Awake()
    {
        base.Awake();
        OnValidate();
    }

    protected override void OnValidate()
    {
        base.OnValidate();

        if (rect == null)
            rect = GetComponent<RectTransform>();

        ForceRebuild();
    }

    private void ForceRebuild()
    {
        SetLayoutHorizontal();
        SetLayoutVertical();
    }

    public override void SetLayoutHorizontal()
    {
        base.SetLayoutHorizontal();
        RefreshSize();
    }

    public override void SetLayoutVertical()
    {
        base.SetLayoutVertical();
        RefreshSize();
    }

    public void RefreshSize()
    {
        if (rect == null)
            return;

        if (limitWidth && rect.rect.width > maxWidth)
            RefreshWidth();

        if (limitHeight && rect.rect.height > maxHeight)
            RefreshHeight();
    }

    public void RefreshWidth()
    {
        if (rect == null)
            return;

        rect.sizeDelta = new Vector2(maxWidth, rect.sizeDelta.y);
    }

    public void RefreshHeight()
    {
        if (rect == null)
            return;

        rect.sizeDelta = new Vector2(rect.sizeDelta.x, maxHeight);
    }

}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PanelDrag : MonoBehaviour, IDragHandler, IBeginDragHandler
{

    RectTransform panel = null;
    [SerializeField] 
    private Canvas canvas;

    // Use this for initialization
    void Start()
    {
        panel = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
         panel.position += new Vector3(eventData.delta.x, eventData.delta.y);

        //panel.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        panel.SetAsLastSibling();
    }
}


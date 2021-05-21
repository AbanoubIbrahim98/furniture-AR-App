using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    PointerEventData pDate;
    EventSystem eventSystem;

    public Transform selectionPoint;

    private static UIManger instance;
    public static UIManger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManger>();
            }
            return instance;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pDate = new PointerEventData(eventSystem);
        pDate.position = selectionPoint.position;

    }

    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
             raycaster.Raycast(pDate, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
    public void ScrollToButton(Button b)
    {

    }
}

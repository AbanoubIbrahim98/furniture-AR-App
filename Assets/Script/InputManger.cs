using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.XR.ARSubsystems;
public class InputManger : ARBaseGestureInteractable

{
    [SerializeField] private Camera arcam;
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private GameObject crosshair;

    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;
    void Start()
    {
    }
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.targetObject == null)
            return true;
        return false;

    }
    protected override void OnContinueManipulation(TapGesture gesture)
    {
        if (gesture.isCanceled)
            return;
        if (gesture.targetObject != null && IspointerOverUI(gesture))
        {
            return;
        }
        if (GestureTransformationUtility.Raycast(gesture.startPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            GameObject placedobj = Instantiate(DateHandler.Instance.GetFurniture(), pose.position, pose.rotation);
        }
    }
    void FixedUpdate()
    {
        crosshairCalculation();

    }
    bool IspointerOverUI(TapGesture touch)
    {
        PointerEventData evenDate = new PointerEventData(EventSystem.current);
        evenDate.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(evenDate, results);
        return results.Count > 0;

    }

    private RaycastHit hit;
    void crosshairCalculation()
    {
        Vector3 origin = arcam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        if (GestureTransformationUtility.Raycast(origin, _hits, TrackableType.PlaneWithinPolygon))
        {
            pose = _hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);

        }



    }
}

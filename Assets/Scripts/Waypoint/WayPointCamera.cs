using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WayPointCamera : MonoBehaviour
{
    public Dictionary<GameObject,WayPoint> wayPointMarkers = new Dictionary<GameObject, WayPoint>(); //onScreenMarker,waypoint
    GameObject canvas;
    GameObject wayPointOverlay;

    [SerializeField] List<string> wayPointTags;

    [SerializeField] Camera cam;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        wayPointOverlay = GameObject.Find("WayPointOverlay");
        Debug.Assert(canvas != null, "Canvas not Found");
        Debug.Assert(wayPointOverlay != null, "WayPointOverlay not Found");
        Debug.Assert(cam != null, "cam not Found");

        if (wayPointOverlay.transform is RectTransform rt && canvas.transform is RectTransform crt)
            rt.sizeDelta = crt.sizeDelta;
        wayPointOverlay.SetActive(false);
    }

    void Update()
    {
        FindWayPoints();
        wayPointOverlay.SetActive(true);

        if (wayPointOverlay.transform is RectTransform rt && canvas.transform is RectTransform crt)
            rt.sizeDelta = crt.sizeDelta;

        DrawMarkers();
    }

    private void FindWayPoints()
    {
        foreach (string tag in wayPointTags)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                if (obj.GetComponent<WayPoint>() != null) AddWayPoint(obj);
            }
        }
    }

    private void AddWayPoint(GameObject wayPointObj)
    {
        if (!wayPointObj.activeSelf) return;
        WayPoint wayPoint = wayPointObj.GetComponent<WayPoint>();
        if (wayPointMarkers.Values.Contains(wayPoint)) return;
        if (wayPoint == null) return;   
        GameObject prefab = wayPoint.getPrefab();
        GameObject onScreenMarker = Instantiate(prefab);
        onScreenMarker.transform.SetParent(canvas.transform);
        wayPointMarkers.Add(onScreenMarker, wayPoint);
    }

    private void DrawMarkers()
    {
        foreach (GameObject onScreenMarker in wayPointMarkers.Keys)
        {
            onScreenMarker.SetActive(true);
            WayPoint wayPoint = wayPointMarkers.GetValueOrDefault(onScreenMarker);
            GameObject wayPointObj = wayPoint.gameObject;
            float dist = (wayPointObj.transform.position - transform.position).magnitude;

            if (wayPoint.getMaxDisplayDistance()>0 && dist > wayPoint.getMaxDisplayDistance())
            {
                onScreenMarker.SetActive(false);
                continue;
            }

            InteractableObject interactable = wayPointObj.GetComponent<InteractableObject>();

            if (wayPointObj == null || !wayPointObj.activeSelf || wayPointObj.GetComponent<WayPoint>() == null || (interactable != null && !interactable.canInteract))
            {
                onScreenMarker.SetActive(false);
                continue;
            }


            TextMeshProUGUI distanceText = onScreenMarker.GetComponentInChildren<TextMeshProUGUI>();
            distanceText.text = ((int)dist) + " M";


            if (wayPointObj == null || !wayPointObj.activeSelf || wayPointObj.GetComponent<WayPoint>() == null)
            {
                Destroy(onScreenMarker);
                wayPointMarkers.Remove(onScreenMarker);
                continue;
            }

            float minX = -onScreenMarker.GetComponentInChildren<RawImage>().GetPixelAdjustedRect().width / 8;
            float maxX = Screen.width - minX;

            float minY = -onScreenMarker.GetComponentInChildren<RawImage>().GetPixelAdjustedRect().height / 8;
            float maxY = Screen.height - minY;

            Vector2 pos = cam.WorldToScreenPoint(wayPointObj.transform.position);

            if(Vector3.Dot(wayPointObj.transform.position - cam.transform.position, cam.transform.forward) <0)
            {
                if(pos.x < Screen.width/2) {
                    pos.x = maxX;
                } else
                {
                    pos.x = minX;
                }
                pos.y = Screen.height - pos.y;
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            onScreenMarker.transform.position = pos;
        }
    }
}

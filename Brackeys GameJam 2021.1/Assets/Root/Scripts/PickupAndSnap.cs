using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndSnap : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    [SerializeField] private Transform[] slots;
    private bool isHeld;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld == true)
        {
            Vector3 closestPos = Input.mousePosition;
            foreach (Transform slot in slots)
            {
                if (Vector3.Distance(cam.ScreenToWorldPoint(Input.mousePosition), (Vector2)slot.position) < Vector3.Distance(cam.ScreenToWorldPoint(Input.mousePosition), closestPos))
                {
                    Debug.Log(slot.name);
                    closestPos = slot.position;
                    Debug.Log($"Changed position to {closestPos}");
                }
            }

            transform.position = closestPos + (Vector3)offset;
        }

        Debug.Log(isHeld);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isHeld = false;
    }
}
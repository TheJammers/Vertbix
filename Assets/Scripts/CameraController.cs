using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 0.01f;
    private Vector2 previousPoint;
    private bool dragging;
    
    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (camera != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
            }
            else if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == null && !EventSystem.current.IsPointerOverGameObject())
            {
                dragging = true;
            }
            else if ( Input.GetMouseButton(0) &&
                      EventSystem.current.currentSelectedGameObject == null && (!EventSystem.current.IsPointerOverGameObject() || dragging))
            {
                var pos = transform.position;
                pos.z = Mathf.Clamp(pos.z + ((previousPoint.x - Input.mousePosition.x) * movementSpeed),GameManager.Instance.vehicleMovement.vehicleObject.backPoint.z, GameManager.Instance.vehicleMovement.vehicleObject.frontPoint.z);
                transform.position = pos;

                dragging = true;
            }

            previousPoint = Input.mousePosition;
        }
    }
}

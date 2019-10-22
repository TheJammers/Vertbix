using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var hits = Physics.RaycastAll(camera.ScreenPointToRay (Input.mousePosition));
            var isOverVehicle = hits.Any(hit => hit.collider.CompareTag("Vehicle"));
            
//            Debug.Log(string.Join(", ", hits.Select(x=> x.collider.tag)));
            
            bool isFreeToStart = EventSystem.current.currentSelectedGameObject == null && !EventSystem.current.IsPointerOverGameObject() && 
                                 !isOverVehicle && !GameManager.Instance.uiController.IsDialogOpen;
            
            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
            }
            
            if ((Input.GetMouseButtonDown(0) /*|| Input.GetMouseButton(0)*/) && isFreeToStart)
            {
                dragging = true;
            }
            
            if (dragging)
            {
                var pos = transform.position;
                pos.z = Mathf.Clamp(pos.z + ((previousPoint.x - Input.mousePosition.x) * movementSpeed),GameManager.Instance.vehicleMovement.vehicleObject.backPoint.z, GameManager.Instance.vehicleMovement.vehicleObject.frontPoint.z);
                transform.position = pos;
            }
            
            previousPoint = Input.mousePosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1;
    private bool active;
    [SerializeField]
    public Vehicle vehicleObject;

    [SerializeField] private GameObject vehiclePrefab;
    // Start is called before the first frame update
    void Awake()
    {
        active = false;
    }

    public void Init(Vector3 startPosition, Vector3 startRotation)
    {
        vehicleObject = Instantiate(vehiclePrefab, startPosition, Quaternion.Euler(startRotation)).GetComponent<Vehicle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            vehicleObject.transform.Translate(Vector3.forward * movementSpeed);
        }
    }

    public void StartMovement()
    {
        active = true;
    }

    public void StopMovement()
    {
        active = false;
    }

    public Vehicle GetVehicle()
    {
        return vehicleObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TopDownRace;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private float generationDistance;
    [SerializeField] private List<GameObject> segmentPrefabs;
    [SerializeField] private Vector3 startPoint;

    [SerializeField] private GameObject startSegment;
    private List<Segment> generatedSegments;

    //[SerializeField] private Vector3 direction;

    private bool generating;
    // Start is called before the first frame update
    void Awake()
    {
        generatedSegments = new List<Segment>();
        generating = false;
    }

    public void StartGeneration()
    {
        generatedSegments.Add(Instantiate(startSegment, startPoint, Quaternion.identity).GetComponent<Segment>());
        GenerateTerrainWhileNeeded();
        
        generating = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (generating)
        {
            GenerateTerrainWhileNeeded();
        }
    }

    void GenerateTerrainWhileNeeded()
    {
        while (Vector3.Distance(generatedSegments.Last().transform.position,
                   GameManager.Instance.vehicleMovement.GetVehicle().transform.position) < generationDistance)
        {
            GenerateSegment();
        }
    }

    private void GenerateSegment()
    {
        
        var generatedSegment = Instantiate(segmentPrefabs[Random.Range(0, segmentPrefabs.Count)],
            Vector3.forward * -100, Quaternion.identity).GetComponent<Segment>();
        var selectedJointToSnap = generatedSegment.joints[Random.Range(0, generatedSegment.joints.Count)];
        Transform jointToSnap;
        
        var lastSegment = generatedSegments[generatedSegments.Count - 1];
        if (generatedSegments.Count > 1)
        {
            var prevSegment = generatedSegments[generatedSegments.Count - 2];

            jointToSnap = lastSegment.joints.FirstOrDefault(j =>
                !prevSegment.joints.Any(jj => Vector3.Distance(j.transform.position, jj.transform.position) < 0.1f));
        }
        else
        {
            jointToSnap = lastSegment.joints[0];
        }

        SegmentUtility.SnapJoints(generatedSegment.transform, selectedJointToSnap, jointToSnap);
        
        generatedSegments.Add(generatedSegment);
    }
}

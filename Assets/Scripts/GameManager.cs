using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<WagonData> WagonData;  
    public static GameManager Instance;
    [SerializeField] private float scoreMiltiplier;
    [SerializeField] private float screIncrease;
    [SerializeField] private float scoreIncreaseTime = 1000;
    [SerializeField] private Vector3 vehicleStartPosition;
    [SerializeField] private Vector3 vehicleStartRotation;
    [SerializeField] public VehicleMovement vehicleMovement;
    [SerializeField] public TerrainGenerator terrainGenerator;
    public delegate void ScoreChangedDelegate(float score);

    public event ScoreChangedDelegate ScoreChangedEvent;
    public float Score { get; set; }

    private Timer scoreIncreaseTimer;

    private Vector3 lastPosition;
    private void Awake()
    {
        WagonData = Resources.LoadAll<WagonData>("Data/WagonData").ToList();
        if (PlayerPrefs.HasKey("Score"))
        {
            Score = PlayerPrefs.GetFloat("Score");
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
//        scoreIncreaseTimer = new Timer(scoreIncreaseTime);
//        scoreIncreaseTimer.Elapsed += IncreaseMultiplier;
//        scoreIncreaseTimer.AutoReset = true;
//        scoreIncreaseTimer.Start();
        
        vehicleMovement.Init(vehicleStartPosition, vehicleStartRotation);
        terrainGenerator.StartGeneration();
        vehicleMovement.StartMovement();
        
    }

    private void IncreaseMultiplier(object sender, ElapsedEventArgs e)
    {
        scoreMiltiplier += screIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        var vehiclePosition = vehicleMovement.GetVehicle().transform.position;
        var distMoved = lastPosition - vehiclePosition;
        var scoreToAdd = distMoved.sqrMagnitude * scoreMiltiplier;
        if (scoreToAdd > 0)
        {
            AddScore(scoreToAdd);

            lastPosition = vehiclePosition;
        }
    }

    private void AddScore(float scoreToAdd)
    {
        var newScore = Score + scoreToAdd;
        
        if ((int)Score != (int)newScore)
        {
            if (ScoreChangedEvent != null)
            {
                PlayerPrefs.SetFloat("Score" ,Score);
                ScoreChangedEvent(newScore);
            }
        }
        
        Score = newScore;
    }
}

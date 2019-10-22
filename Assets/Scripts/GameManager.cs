using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public List<WagonData> WagonData;  
    [HideInInspector] public List<TowerData> TowerData;  
    public static GameManager Instance;
    [SerializeField] private float scoreMiltiplier;
    [SerializeField] private float screIncrease;
    [SerializeField] private float scoreIncreaseTime = 1000;
    [SerializeField] private Vector3 vehicleStartPosition;
    [SerializeField] private Vector3 vehicleStartRotation;
    public VehicleMovement vehicleMovement;
    public TerrainGenerator terrainGenerator;
    public NavMeshSurface navMeshSurface;
    public UIController uiController;
    
    public delegate void ScoreChangedDelegate(float score);

    public event ScoreChangedDelegate ScoreChangedEvent;
    public float Score { get; set; }
    
    public float TotalScore { get; set; }

    private Timer scoreIncreaseTimer;

    private Vector3 lastPosition;
    private void Awake()
    {
        terrainGenerator = FindObjectOfType<TerrainGenerator>();
        vehicleMovement = FindObjectOfType<VehicleMovement>();
        navMeshSurface = FindObjectOfType<NavMeshSurface>();
        uiController = FindObjectOfType<UIController>();
        WagonData = Resources.LoadAll<WagonData>("Data/WagonData").ToList();
        TowerData = Resources.LoadAll<TowerData>("Data/TowerData").ToList();
        Score = PlayerPrefs.GetFloat("Score", 0);
        TotalScore = PlayerPrefs.GetFloat("TotalScore", 0);
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

    public void AddScore(float scoreToAdd)
    {
        var newScore = Score + scoreToAdd;
        
        if ((int)Score != (int)newScore)
        {
            if (ScoreChangedEvent != null)
            {
                ScoreChangedEvent(newScore);
            }
        }

        TotalScore += scoreToAdd;
        Score = newScore;
        
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Score", Score);
        PlayerPrefs.SetFloat("TotalScore", TotalScore);
        
        PlayerPrefs.Save();
    }

    public bool RemoveScore(float scoreToRemove)
    {
        var newScore = Score - scoreToRemove;
        bool canRemove = newScore >= 0;
        if (canRemove)
        {
            if ((int) Score != (int) newScore)
            {
                if (ScoreChangedEvent != null)
                {
                    ScoreChangedEvent(newScore);
                }
            }

            Score = newScore;
            
            Save();
        }

        return canRemove;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    [SerializeField]
    private  GameObject[] Players;
    public static GameManager instance;

    private int _charIndex;
    public  int CharIndex
    {
        get{ return _charIndex; }
        set{ _charIndex = value; }
    } 
    
    private void Awake() 
    {
        if(instance==null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

        void Update()
    {
        
    }

    void OnEnable() {

        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable() {
        
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        
        if(scene.name == "SampleScene"){
            Debug.Log("On Level "+ Players[CharIndex] + " " + CharIndex);
            Instantiate(Players[CharIndex]);
        }

    }









}//class

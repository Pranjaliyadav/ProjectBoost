using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{      
    Movement movement;
    [SerializeField] float LoadDelayTime = 0.5f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    AudioSource audioSource;


    void Start() {
        
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();


    }
    
    void OnCollisionEnter(Collision other) {

        switch(other.gameObject.tag){

                case "Friendly":
                        Debug.Log("This is a friendly place!");
                        break;
                case "Finish":
                        StartWinSequence();
                        break;
                default:
                        StartCrashSequence();          
                        break;

        }
        
    }

    void StartCrashSequence(){

        audioSource.PlayOneShot(crash);
        movement.enabled = false;
        Invoke("ReloadLevel", LoadDelayTime);     //dont use ReloadLevel()  only name is needed not the brackets
                                        //delay the function , wait for 1 sec to execute this function

    }

    void StartWinSequence(){

        audioSource.PlayOneShot(success);
        movement.enabled = false;
        Invoke("LoadNextLevel" , LoadDelayTime);
        
    }

    void ReloadLevel(){
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;    //get the current active screen index from screen manager
        SceneManager.LoadScene(CurrentSceneIndex);   //now by this u can load it again
    }

    void LoadNextLevel(){
        int NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;           //for the next level 
        if(NextSceneIndex == SceneManager.sceneCountInBuildSettings){            //sceneCountInBuildSettings gets the total scenes count
            NextSceneIndex = 0;                          //load the first scene.
        }
        SceneManager.LoadScene(NextSceneIndex);   //load next level
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {

        switch(other.gameObject.tag){

                case "Friendly":
                        Debug.Log("This is a friendly place!");
                        break;
                case "Finish":
                        LoadNextLevel();
                        break;
                default:
                        ReloadLevel();
                        break;

        }
        
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
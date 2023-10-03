using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
   public void LoadScene(int sceneInt){
    SceneManager.LoadScene(sceneInt);
   }

   public void quitGame()
   {
      Application.Quit();
   }
}

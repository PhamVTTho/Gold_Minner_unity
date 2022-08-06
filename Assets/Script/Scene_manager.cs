using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour
{
    [SerializeField] public int sceneIndex;
    public void onButtonClickLoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

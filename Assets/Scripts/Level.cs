using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //params
    [SerializeField] int breakableBlocks;//Serialized for debugging

    //cached reference
    SceneLoader sceneLoader;
    
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks ()
    {
        breakableBlocks ++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}

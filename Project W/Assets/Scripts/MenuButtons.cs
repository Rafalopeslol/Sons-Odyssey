using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public LevelLoader load1;
    public LevelLoader load2;
    public LevelLoader load3;
    public void Play()
    {
        load1.NextLevel();
    }
    public void Options()
    {
        load2.NextLevel();
    }
    public void Credits()
    {
        load3.NextLevel();
    }


}


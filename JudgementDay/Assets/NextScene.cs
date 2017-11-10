using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextScene : MonoBehaviour {

    public void LoadNextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}

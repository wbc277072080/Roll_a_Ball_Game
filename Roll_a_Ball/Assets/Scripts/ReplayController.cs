using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayController : MonoBehaviour
{
    public void Restart(){
        SceneManager.LoadScene("MiniGame");
    }
}

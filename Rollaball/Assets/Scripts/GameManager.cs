using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    bool pause = false;
    public Slider speedSlider;

    void Update()
    {
        if(pause == false)
        {
            Time.timeScale = speedSlider.value;
        }
    }

    public void PauseToggle()
    {
        if(pause == false)
        {
            Time.timeScale = 0;
            pause = true;
        } else {
            Time.timeScale = 1;
            pause = false;
        }
    }

    public PlayerController player;
}

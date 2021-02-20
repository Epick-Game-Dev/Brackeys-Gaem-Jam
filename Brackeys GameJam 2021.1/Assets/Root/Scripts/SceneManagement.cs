using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static void LoadPuzzle1()
    {
        PlayerStats.currentHappiness = 0;
        SceneManager.LoadSceneAsync("Puzzle 1");
    }
    public void LoadPuzzle1NonStatic()
    {
        PlayerStats.currentHappiness = 0;
        SceneManager.LoadSceneAsync("Puzzle 1");
    }

    public static void LoadPuzzle2()
    {
        SceneManager.LoadSceneAsync("Puzzle 2");
    }

    public static void LoadPointsCountScene()
    {
        SceneManager.LoadSceneAsync("Counting Points");
    }

    public static void Quit()
    {
        Application.Quit();
    }
    public void QuitNonStatic()
    {
        Application.Quit();
    }
}
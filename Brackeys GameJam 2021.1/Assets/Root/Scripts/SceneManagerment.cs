using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerment : MonoBehaviour
{
    public static void LoadPuzzle1()
    {
        SceneManager.LoadSceneAsync("Puzzle 1");
    }

    public static void LoadPuzzle2()
    {
        SceneManager.LoadSceneAsync("Puzzle 2");
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public static void LoadPointsCountScene()
    {
        SceneManager.LoadSceneAsync("Counting Points");
    }
}
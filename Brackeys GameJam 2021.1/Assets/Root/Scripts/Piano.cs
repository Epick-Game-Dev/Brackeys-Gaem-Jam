using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piano : MonoBehaviour
{
    [SerializeField] private Image[] keys;
    [SerializeField] private Image[] blackKeys;
    public Canvas _canvas;
    [SerializeField] private string result;
    private bool playerInRange = false;
    private int resultIndex = 0;
    [SerializeField] private string notes = "";
    [SerializeField] private PuzzleStart puzzle;
    void Start()
    {
        _canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            _canvas.enabled = !_canvas.enabled;
        }

        if (_canvas.enabled)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().status = PlayerMovement.PlayerStatus.Stuck;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().status = PlayerMovement.PlayerStatus.Free;
        }
        HandleWhiteKey1();
        HandleWhiteKey2();
        HandleWhiteKey3();
        HandleWhiteKey4();
        HandleWhiteKey5();
        HandleWhiteKey6();
        HandleWhiteKey7();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void HandleWhiteKey1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            keys[0].color = Color.black;
            SoundManager.PlaySound("Do");
            CheckResult('1');
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            keys[0].color = Color.white;
        }
    }

    private void HandleWhiteKey2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            keys[1].color = Color.black;
            SoundManager.PlaySound("Re");
            CheckResult('2');
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            keys[1].color = Color.white;
        }
    }

    private void HandleWhiteKey3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            keys[2].color = Color.black;
            SoundManager.PlaySound("Mi");
            CheckResult('3');
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            keys[2].color = Color.white;
        }
    }

    private void HandleWhiteKey4()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            keys[3].color = Color.black;
            SoundManager.PlaySound("Fa");
            CheckResult('4');
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            keys[3].color = Color.white;
        }
    }

    private void HandleWhiteKey5()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            keys[4].color = Color.black;
            SoundManager.PlaySound("So");
            CheckResult('5');
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            keys[4].color = Color.white;
        }
    }

    private void HandleWhiteKey6()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            keys[5].color = Color.black;
            SoundManager.PlaySound("La");
            CheckResult('6');
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            keys[5].color = Color.white;
        }
    }

    private void HandleWhiteKey7()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            keys[6].color = Color.black;
            SoundManager.PlaySound("Ti");
            CheckResult('7');
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            keys[6].color = Color.white;
        }
    }

    private void CheckResult(char number)
    {

        if (number == result[resultIndex])
        {
            Debug.Log($"Nice! {number} was the right answer");
            resultIndex++;
            notes += number;

            if (notes == result)
            {
                Debug.Log("You won!");
                StartCoroutine(FindObjectOfType<PuzzleStart>().EndPuzzle());
                Debug.Log("Wwwww");
                resultIndex = 0;
            }

        }
        else
        {
            Debug.Log($"Wrong! {number} was the wrong answer");
            notes = "";
            resultIndex = 0;
        }

    }
}

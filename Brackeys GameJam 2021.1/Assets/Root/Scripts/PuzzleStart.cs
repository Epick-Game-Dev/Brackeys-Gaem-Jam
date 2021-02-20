using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStart : MonoBehaviour
{
    private AudioClip song;
    [SerializeField] private Animator catAnimControl;
    [SerializeField] private Animator camAnimControl;
    private bool canInteract = false;

    private void Start()
    {
        song = Resources.Load<AudioClip>("Puzzle 1 Girl Song");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            StartCoroutine(Sing());
        }
    }

    private IEnumerator Sing()
    {
        MusicManager.StopMusic();
        yield return new WaitForSeconds(1);
        PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player.status = PlayerMovement.PlayerStatus.Stuck;
        SoundManager.source.PlayOneShot(song);
        yield return new WaitForSeconds(song.length + 1);
        player.status = PlayerMovement.PlayerStatus.Free;
        MusicManager.StartMusic();
    }

    public IEnumerator EndPuzzle()
    {
        Debug.Log("ending puzzle");
        MusicManager.StopMusic();
        FindObjectOfType<Piano>()._canvas.enabled = false;
        PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player.status = PlayerMovement.PlayerStatus.Stuck;
        catAnimControl.SetBool("Jump", true);
        yield return new WaitForSeconds(1);
        catAnimControl.SetBool("Jump", false);
        yield return new WaitForSeconds(1);
        camAnimControl.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        SceneManagerment.LoadPuzzle2();
    }
}

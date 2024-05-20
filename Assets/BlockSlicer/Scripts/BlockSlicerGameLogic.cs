using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

/// <summary>
/// Manager class for BlockSlicer
/// </summary>
public class BlockSlicerGameLogic : MonoBehaviour
{
    //Game State: Start
    public XRRayInteractor[] XRRayInteractors;
    public Canvas StartMenu;

    //Game State: Playing
    public GameObject[] sabers;
    public Canvas ScoreBoard;
    public TMP_Text GameScoreText; 
    public GameObject Level;
    public AudioClip Music;

    //Game State: Finished
    public Canvas EndGameCanvas;
    public TMP_Text EndGameScoreText, WinLoseText;

    private void Start()
    {
        Level.SetActive(false);
    }

    /// <summary>
    /// Change Game State from Start to Playing, tuning on and off the associated objects
    /// </summary>
    public void StartGame()
    {
        //Turn off Start State objects
        foreach(XRRayInteractor xRRay in XRRayInteractors)
        {
            xRRay.enabled = false;
        }
        StartMenu.gameObject.SetActive(false);

        //Turn on and start Playing State objects
        foreach (GameObject saber in sabers)
        {
            saber.SetActive(true);
        }
        ScoreBoard.gameObject.SetActive(true);
        Level.SetActive(true);
        StartCoroutine("YieldEndOfLevel");
        GetComponent<AudioSource>().PlayOneShot(Music);
    }

    IEnumerator YieldEndOfLevel()
    {
        //Wait the length of the player's song and an extra second
        yield return new WaitForSeconds(Music.length + 1.0f);
        //If the level is on, then the player has not run out of lives
        if(Level.activeInHierarchy)
        {
            FinishedSong();
        }
    }

    /// <summary>
    /// Lose condition
    /// </summary>
    public void GameOver()
    {
        LevelComplete(false);
    }

    /// <summary>
    /// Win condition
    /// </summary>
    public void FinishedSong()
    {
        LevelComplete(true);
    }

    /// <summary>
    /// Enter 'Finished Game' state
    /// </summary>
    /// <param name="didWin">Tell the game if the player won</param>
    void LevelComplete(bool didWin)
    {
        //Turn off Playing State objects
        foreach (GameObject saber in sabers)
        {
            saber.SetActive(false);
        }
        Level.SetActive(false);
        ScoreBoard.gameObject.SetActive(false);

        //Turn on Finished State objects
        foreach (XRRayInteractor xRRay in XRRayInteractors)
        {
            xRRay.enabled = true;
        }
        EndGameCanvas.gameObject.SetActive(true);

        //Tell the player if they won or lost
        WinLoseText.text = didWin ? "You Win!" : "You Lose!";
        EndGameScoreText.text = GameScoreText.text;
    }

    /// <summary>
    /// Reset the game
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

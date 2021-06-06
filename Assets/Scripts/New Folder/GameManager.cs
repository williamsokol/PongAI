using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{


    const int AIMODE = 1;
    const int PLAYER = 0;

    [Header("Referances")]
    public JsonManager jsonManager;
    public Camera camera2;
    public GameObject player,AI;
    public Animator textAnimator;
    public TextMeshProUGUI tutorialText;

    [Header("Data")]
    public int _playMode;
    public static int playMode;

    private bool playerMoved;
    [Header("Settings")]
    public float trainTime;
    

 
    // Start is called before the first frame update
    void Start()
    {
        playMode = _playMode;
        StartCoroutine(TutorialLoop());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // write data when you moved, the timers on, and it's the start of the game
        if(playerMoved &&trainTime < Time.timeSinceLevelLoad && playMode != AIMODE)
        {
            ChangeModeTo(1);
            //jsonManager.writeTrainData();
        }

        //check if the player moved
        if(!playerMoved &&Input.GetAxis("Horizontal") != 0)
        {
            textAnimator.SetTrigger("Moved");
            playerMoved = true;
            trainTime += Time.timeSinceLevelLoad;
        }
    }
    public void ChangeModeTo(int mode)
    {
        // mode 1 = AIMODE playing
        if(mode == AIMODE)
        {
            camera2.depth = 0;
            player.SetActive(true);
            AI.GetComponent<Paddle>().playMode = AIMODE;
            playMode = AIMODE;

        }
    }

    public IEnumerator TutorialLoop()
    {
        Time.timeScale = .1f;
        yield return new WaitForSeconds(.1f);
        Time.timeScale = 1f;

        do
        {
            yield return new WaitForSeconds(textAnimator.GetCurrentAnimatorStateInfo(0).length);
        } while(playerMoved == false);

        while(playMode == PLAYER)
        {
            tutorialText.text = (trainTime-Time.timeSinceLevelLoad).ToString("#.00");
            yield return new WaitForSeconds(.01f);
            //break;
        }

        tutorialText.text = "Done!";
        Time.timeScale = .01f;
        yield return new WaitForSeconds(.02f);
        Time.timeScale = 1f;
        tutorialText.gameObject.SetActive(false); 
        
    }
}

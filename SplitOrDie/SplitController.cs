using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SplitController : MonoBehaviour {

    public GameObject Ball;
    public GameObject[] miniBalls;
    public GameObject smallBall1;
    public GameObject smallBall2;

    Animator BigBallAnim;
    Animator smallBall1Anim;
    Animator smallBall2Anim;

    private Renderer rend;
    private Collider bigBallCollider;

    private float doubleTapTimer;
    private bool smallBallsActive;

    void Start() {

        BigBallAnim = Ball.GetComponent<Animator>();
        smallBall1Anim = smallBall1.GetComponent<Animator>();
        smallBall2Anim = smallBall2.GetComponent<Animator>();

        smallBallsActive = false;

        rend = Ball.GetComponent<Renderer>();
        bigBallCollider = Ball.GetComponent<Collider>();

        foreach (GameObject ball in miniBalls)
        {
            ball.transform.parent = Ball.transform;
            ball.SetActive(false);
        }      
    }

    void Update() {
        //      Input pt Windows si OSX
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        if (!GameManager.Instance.isDead)
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                if (BigBallAnim != null)
                {
                    BigBallAnim.SetBool("split", true);
                }

                if (!GameManager.Instance.isDead)
                {
                    StartCoroutine("split");
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (!GameManager.Instance.isDead)
                {
                    if (smallBall1Anim != null && smallBall2Anim != null)
                    {
                        smallBall1Anim.SetBool("merge", true);
                        smallBall2Anim.SetBool("merge", true);
                    }
                    StartCoroutine("mergeBallsEdit");
                }
            }
        }
#endif

        //      Input pt mobile
#if UNITY_ANDROID || UNITY_IOS

        if (!GameManager.Instance.isDead)
        {

            foreach (Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    return;
                }
            }

            if (Input.touchCount > 0)
            {
                Touch touch1 = Input.GetTouch(0);

                if (touch1.phase == TouchPhase.Began)
                {
                    doubleTapTimer = Time.time;

                }

                if (touch1.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Canceled)
                {
                    if (Time.time - doubleTapTimer <= 0.2)
                    {
                        if (!smallBallsActive)
                        {
                            if (rend != null)
                            {
                                if (BigBallAnim != null)
                                {
                                    BigBallAnim.SetBool("split", true);
                                }
                                StartCoroutine("splitBall");
                            }
                        }
                        else if (smallBallsActive)
                        {
                            if (rend != null)
                            {
                                if (smallBall1Anim != null && smallBall2Anim != null)
                                {
                                    smallBall1Anim.SetBool("merge", true);
                                    smallBall2Anim.SetBool("merge", true);
                                }
                                StartCoroutine("mergeBalls");
                            }
                        }
                    }
                }
            }
        }
#endif
    }

    IEnumerator split()
    {
        yield return new WaitForSeconds(0.1f);
        if (BigBallAnim != null)
        {
            BigBallAnim.SetBool("split", false);
        }
        rend.enabled = false;
        Ball.GetComponent<BallRotation>().enabled = false;
        foreach (GameObject ball in miniBalls)
        {
            if (ball != null)
            {
                ball.SetActive(true);
                bigBallCollider.enabled = false;
            }
        }
    }

    IEnumerator splitBall()
    {
        yield return new WaitForSeconds(0.1f);
        if (BigBallAnim != null)
        {
            BigBallAnim.SetBool("split", false);
        }
        rend.enabled = false;
        Ball.GetComponent<BallRotation>().enabled = false;
        foreach (GameObject ball in miniBalls)
        {
            if (ball != null)
            {
                ball.SetActive(true);
                bigBallCollider.enabled = false;
                smallBallsActive = true;
            }
        }

    }

    IEnumerator mergeBalls()
    {
        yield return new WaitForSeconds(0.1f);
        Ball.GetComponent<BallRotation>().enabled = true;
        if (smallBall1Anim != null && smallBall2Anim != null)
        {
            smallBall1Anim.SetBool("merge", false);
            smallBall2Anim.SetBool("merge", false);
        }

        rend.enabled = true;
        foreach (GameObject ball in miniBalls)
        {
            if (ball != null)
            {
                ball.SetActive(false);
                bigBallCollider.enabled = true;
                smallBallsActive = false;
            }
        }
    }

    IEnumerator mergeBallsEdit()
    {
        yield return new WaitForSeconds(0.1f);

        if (smallBall1Anim != null && smallBall2Anim != null)
        {
            smallBall1Anim.SetBool("merge", false);
            smallBall2Anim.SetBool("merge", false);
        }
        rend.enabled = true;
        Ball.GetComponent<BallRotation>().enabled = true;
       
        foreach (GameObject ball in miniBalls)
        {
            if (ball != null)
            {
                ball.SetActive(false);
                bigBallCollider.enabled = true;
            }
        }
    }
}
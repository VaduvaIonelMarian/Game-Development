using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer rend;
    
    public float playerSpeedMobile = 0.25f;
    public float speed;
    //float xMin = -2.4f;
   // float xMax = 2.4f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();

        rend.material = GameManager.Instance.GetBallMaterial();
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.isDead )
        {
           GameManager.Instance.HandlePauseMenu();
        }
    }

    void FixedUpdate()
    {

        //      Input pt mobile
#if UNITY_ANDROID || UNITY_IOS
        if (!GameManager.Instance.isDead)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {

                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                rb.velocity = new Vector3(touchDeltaPosition.x * playerSpeedMobile, 0.0f, 0.0f);

            }
            else
            {
                rb.velocity = Vector3.zero;
            }

          //  rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), rb.position.y, rb.position.z);
        }
        else
            rb.velocity = Vector3.zero;

#endif

        //      Input pt Windows si OSX
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN

        if (!GameManager.Instance.isDead)
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(moveHorizontal * speed, 0.0f, 0.0f);
          //  rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), rb.position.y, rb.position.z);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
       
#endif   

    }
}

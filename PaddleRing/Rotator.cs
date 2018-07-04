using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    

  
    
    [SerializeField] Transform pivot;
	[SerializeField] float speed;
    Vector3 v1;
    Vector3 v2;
    Vector3 firstPos;
    Vector3 lastPos;
    

	// Use this for initialization
	void Start () {
        
    }
	
   
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        
        if (Input.GetMouseButton(0))
        {
            //firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          //  v1 = firstPos - pivot.transform.position;




            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            v2 = lastPos - pivot.transform.position;
            float angle = Vector3.Angle(v1, v2);
            Vector3 cross = Vector3.Cross(v1, v2);
            if (cross.z > 0)
            {

                angle = -angle;
                
            }
             angle *= 4.25f;

            transform.Rotate(0, 0, -angle);
            v1 = v2;
            //Debug.Log(angle);
        }
        /* if (Input.GetKey(KeyCode.LeftArrow))
         {
             RotateRight();


         if (Input.GetKey(KeyCode.RightArrow))
         {
             RotateLeft();
         }*/

#endif
#if UNITY_ANDROID || UNITY_IOS
        if (GamePlayMode.instance.tap==false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
               
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                lastPos = Input.GetTouch(0).position;
                v2 = lastPos - pivot.transform.position;
                float angle = Vector3.Angle(v1, v2);
                Vector3 cross = Vector3.Cross(v1, v2);
                if (cross.z > 0)
                {

                    angle = -angle;
                }
              //  angle *= 4.25f;

                transform.Rotate(0, 0, angle);
          
                v1 = v2;
            }
            }
            
             else
           {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).position.x < Screen.width / 2)
                {
                    RotateRight();

                }
                else if (Input.GetTouch(0).position.x > Screen.width / 2)
                {
                    RotateLeft();
                }
            }

        }

            
        
        
      
#endif

    }

    private void RotateRight(){
		
		transform.RotateAround (pivot.transform.position, Vector3.forward, speed * Time.deltaTime);

	}

	 private void RotateLeft(){
	
	    transform.RotateAround (pivot.transform.position, -Vector3.forward, speed * Time.deltaTime);
	}

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }


}

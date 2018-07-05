using UnityEngine;

public class SmallBallPosition : MonoBehaviour {

	void Update ()
    {
        transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
    }

    private void LateUpdate()
    {
        {
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }
    }
}

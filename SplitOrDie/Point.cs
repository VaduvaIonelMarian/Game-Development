using UnityEngine;

public class Point : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.IncrementScore();
        }
    }
}

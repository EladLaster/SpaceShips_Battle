using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoOtherSide : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" || other.tag == "Player2") {
            Vector3 currentPosition = other.transform.position;
            other.transform.position = new Vector3(-currentPosition.x, currentPosition.y, 0);
        }
    }
}
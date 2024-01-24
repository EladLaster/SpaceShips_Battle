using System.Collections;
using UnityEngine;

public class BlockThePlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Block triggered by Player1");
            
            // Find the second player
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            if (player2 != null)
            {
                var destroyComponent = player2.GetComponent<LaserShooter>();
                if (destroyComponent)
                {
                    destroyComponent.StartCoroutine(Block(destroyComponent));
                    Destroy(gameObject);
                }
            }
        }
        if (other.CompareTag("Player2"))
        {
            Debug.Log("Block triggered by Player2");
            
            // Find the second player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                var destroyComponent = player.GetComponent<LaserShooter>();
                if (destroyComponent)
                {
                    destroyComponent.StartCoroutine(Block(destroyComponent));
                    Destroy(gameObject);
                }
            }
        }
    }

    private IEnumerator Block(LaserShooter destroyComponent)
    {
        destroyComponent.enabled = false;
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("block: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
        }
        Debug.Log("block gone!");
        destroyComponent.enabled = true;
    }
}

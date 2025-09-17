using UnityEngine;

public class FallingObstacleTrigger : MonoBehaviour
{
    public Rigidbody2D obstacleRb;
    public float delay = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DropAfterDelay());
        }
    }

    System.Collections.IEnumerator DropAfterDelay()
    {
        yield return new WaitForSeconds(delay); // 指定秒数待機
        obstacleRb.isKinematic = false;         // 重力で落下
    }
}

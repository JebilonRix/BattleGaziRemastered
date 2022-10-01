using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] string _tag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(_tag))
        {
            return;
        }

        SceneManager.LoadScene("03Victory");
    }
}
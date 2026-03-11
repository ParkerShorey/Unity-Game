using UnityEngine;
using System.Collections;

public class low_OrbController : MonoBehaviour
{
    [Header("rand")]
    [SerializeField] private Rigidbody2D player;

    [Header("Activation")]
    [SerializeField] private bool autoActivate = false;
    [SerializeField] private bool singleUse = true;

    [Header("Bounce Settings")]
    [SerializeField] private float xBoost = 10f;
    [SerializeField] private float yBoost = 10f;

    private bool playerInRange = false;
    private bool orbUsed = false;

    private void Update()
    {
        if (orbUsed) return;

        if (!autoActivate && playerInRange && Input.GetKeyDown(KeyCode.UpArrow))
        {
            ActivateOrb();
        }
    }
    private IEnumerator Dash()
    {
        float ogGravity = player.gravityScale;
        player.gravityScale = 0f;
        player.linearVelocity = new Vector2(transform.localScale.x * xBoost, 0f);
        yield return new WaitForSeconds(0.5f);
        player.gravityScale = ogGravity;
        yield return new WaitForSeconds(0f);
    }
    private void ActivateOrb()
    {
        StartCoroutine(Dash());
        if (singleUse)
        {
            orbUsed = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (orbUsed) return;

        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Rigidbody2D>();
            playerInRange = true;

            if (autoActivate)
            {
            ActivateOrb();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
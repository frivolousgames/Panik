using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RatLeap : MonoBehaviour
{
    public Rigidbody2D rb;

    Vector2 leapDir;
    public float leapPowerX;
    public float leapPowerY;

    public UnityEvent land;

    private void Update()
    {
        leapDir = new Vector2(transform.parent.localScale.x * leapPowerX, leapPowerY);
    }

    public void Leap()
    {
        rb.AddForce(leapDir, ForceMode2D.Impulse);
    }

    public void Land()
    {
        rb.velocity = Vector2.zero;
    }
    public void ResetLeap()
    {
        land.Invoke();
    }
}

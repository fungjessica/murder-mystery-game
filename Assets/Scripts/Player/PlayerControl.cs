using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private List<string> inputs = new List<string> {};
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (UserInput.instance.upPressed)
            inputs.Add("Up");
        if (UserInput.instance.downPressed)
            inputs.Add("Down");
        if (UserInput.instance.leftPressed)
            inputs.Add("Left");
        if (UserInput.instance.rightPressed)
            inputs.Add("Right");
        
        if (UserInput.instance.upReleased)
            inputs.Remove("Up");
        if (UserInput.instance.downReleased)
            inputs.Remove("Down");
        if (UserInput.instance.leftReleased)
            inputs.Remove("Left");
        if (UserInput.instance.rightReleased)
            inputs.Remove("Right");

        switch (inputs.LastOrDefault()) {
            case "Up":
                rb.linearVelocity = new Vector2(0, speed);
                break;
            case "Down":
                rb.linearVelocity = new Vector2(0, -speed);
                break;
            case "Left":
                rb.linearVelocity = new Vector2(-speed, 0);
                break;
            case "Right":
                rb.linearVelocity = new Vector2(speed, 0);
                break;
            default:
                rb.linearVelocity = Vector2.zero;
                break;
        }
    }
}

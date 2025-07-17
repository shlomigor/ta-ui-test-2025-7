using UnityEngine;
using UnityEngine.EventSystems;

public class ThreeStateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;
    public float holdTimeToSpin = 1f;

    private float holdTimer = 0f;
    private bool isHolding = false;
    private bool hasSpun = false;

    void Update()
    {
        if (isHolding && !hasSpun)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= holdTimeToSpin)
            {
                animator.ResetTrigger("Pressed");
                animator.SetTrigger("AutoSpin");
                hasSpun = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetTrigger("Pressed");
        isHolding = true;
        holdTimer = 0f;
        hasSpun = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        holdTimer = 0f;

        if (!hasSpun)
        {
            animator.ResetTrigger("AutoSpin");
            animator.SetTrigger("Pressed"); // to allow press effect if hold was < 1s
        }
    }
}


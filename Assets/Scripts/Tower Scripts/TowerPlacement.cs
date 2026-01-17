using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlacement : MonoBehaviour
{
    public enum TowerPlacementMode
    {
        NoCollision,
        OnCollision
    }

    [SerializeField] private TowerPlacementMode mode;
    private SpriteRenderer spriteRenderer;
    private float speed = 10.0f;
    private bool canBePlaced = true;
    [SerializeField] private ContactFilter2D filter;

    private readonly Color unableToPlaceColor = Color.red;
    private readonly Color standardColor = Color.white;

    private void Start()
    {
        StartCoroutine(moveWithMousePosition());
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator moveWithMousePosition()
    {
        while (enabled)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, speed);
            yield return null;
        }
    }

    private void Update()
    {
        switch (mode)
        {
            case TowerPlacementMode.NoCollision:
                if (CollisionActive())
                {
                    canBePlaced = false;
                    spriteRenderer.color = unableToPlaceColor;
                }
                else
                {
                    canBePlaced = true;
                    spriteRenderer.color = standardColor;
                }
                break;
            case TowerPlacementMode.OnCollision:
                if (CollisionActive())
                {
                    canBePlaced = true;
                    spriteRenderer.color = standardColor;
                }
                else
                {
                    canBePlaced = false;
                    spriteRenderer.color = unableToPlaceColor;
                }
                break;
            default:
                break;
        }
    }

    private bool CollisionActive()
    {
        return Physics2D.OverlapCollider(GetComponent<Collider2D>(), filter, new List<Collider2D>()) >= 1;
    }

    private void OnMouseDown()
    {
        if (!canBePlaced)
            return;

        GameManager.TowerPlaced(gameObject);
        enabled = false;
    }
}

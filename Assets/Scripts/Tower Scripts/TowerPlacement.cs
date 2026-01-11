using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlacement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float speed = 10.0f;
    private Vector3 mousePosition;
    private bool canBePlaced = true;
    private ContactFilter2D contactFilter;

    private readonly Color unableToPlaceColor = Color.red;
    private readonly Color standardColor = Color.white;

    private void Start()
    {
        StartCoroutine(moveWithMousePosition());
        spriteRenderer = GetComponent<SpriteRenderer>();
        contactFilter = new ContactFilter2D().NoFilter();
        contactFilter.SetLayerMask(LayerMask.GetMask("TowerPlacementRestrictions"));
        contactFilter.useLayerMask = true;
    }

    private IEnumerator moveWithMousePosition()
    {
        while (enabled)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, speed);
            yield return null;
        }
    }

    private void OnMouseDown()
    {
        if (!canBePlaced)
            return;

        GameManager.TowerPlaced();
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Physics2D.OverlapCollider(GetComponent<Collider2D>(), contactFilter, new List<Collider2D>()) == 0)
            return;

        canBePlaced = false;
        spriteRenderer.color = unableToPlaceColor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        List<Collider2D> results = new List<Collider2D>();

        if(Physics2D.OverlapCollider(GetComponent<Collider2D>(), contactFilter ,results) == 0)
        {
            canBePlaced = true;
            spriteRenderer.color = standardColor;
        }
    }
}

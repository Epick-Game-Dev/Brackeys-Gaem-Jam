using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundAlphaSprite;
    private Vector2 move;

    private void Start()
    {
        move = new Vector2(0, 0);
    }

    private void Update()
    {
        GetInput();
        if (PlayerStats.currentHappiness >= PlayerStats.maxHappiness)
        {
            PlayerStats.currentHappiness = PlayerStats.maxHappiness;
        }

        backgroundAlphaSprite.color = new Color(255, 255, 255, GetHappinessNormalized());
    }

    private void GetInput()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (move.x < 0)
        {
            backgroundAlphaSprite.flipX = true;
        }
        else if (move.x > 0)
        {
            backgroundAlphaSprite.flipX = false;
        }
    }
    
    private float GetHappinessNormalized()
    {
        return PlayerStats.currentHappiness / PlayerStats.maxHappiness;
    }
}

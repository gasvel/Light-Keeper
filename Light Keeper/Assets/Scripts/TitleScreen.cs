using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TitleScreen : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite first;

    [SerializeField]
    private Sprite second;

    [SerializeField]
    private Sprite third;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = first;
	}
	
	void Update () {
        float secs = Time.time % 60;
        
		if(secs >= 0 && secs < 20 && spriteRenderer.sprite.name != first.name)
        {
            Debug.Log(spriteRenderer.sprite.name);
            Debug.Log(first.name);
            spriteRenderer.sprite = first;
        }
        else if (secs >= 20 && secs < 40 && spriteRenderer.sprite.name != second.name)
        {
            Debug.Log("Second");

            spriteRenderer.sprite = second;
        }
        else if(secs >= 40 && spriteRenderer.sprite.name != third.name)
        {
            spriteRenderer.sprite = third;
        }
    }
}

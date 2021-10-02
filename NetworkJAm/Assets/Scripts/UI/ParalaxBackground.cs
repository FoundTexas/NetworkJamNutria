using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParalaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    [SerializeField]private bool InfiniteHorizontal;
    [SerializeField]private bool InfiniteVertical;


    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float TextureUniteSizeX;
    private float TextureUniteSizeY;



    private void Start()
    {
     
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        TextureUniteSizeX = texture.width / sprite.pixelsPerUnit;
        TextureUniteSizeY = texture.height / sprite.pixelsPerUnit;
    }



    private void LateUpdate()
    {
        
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
            
            transform.position +=new Vector3( deltaMovement.x * parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y,0);
            lastCameraPosition = cameraTransform.position;
        if (InfiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= TextureUniteSizeX)
            {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % TextureUniteSizeX;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionX);
            }
        }
        if (InfiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= TextureUniteSizeY)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % TextureUniteSizeY;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
            }
        }
    }
   
}

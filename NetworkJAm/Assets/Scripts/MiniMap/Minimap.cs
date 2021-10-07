using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public RectTransform playerInMap;

    private Vector3 mapped;

    public float X, Y;

    private void Update()
    {


        
        playerInMap.localPosition = new Vector2 (this.transform.position.x * X, this.transform.position.y * Y) ;
    }

}

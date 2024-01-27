using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float duration;
    
    // Start is called before the first frame update
    void Start()
    {
        Tween.Position(transform, transform.position - Vector3.down * distance, duration, 0f, Tween.EaseInOut, Tween.LoopType.PingPong);
    }
}

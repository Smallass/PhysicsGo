using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class fingertouch : MonoBehaviour
{
    private TapGestureRecognizer tapGesture;
    private SwipeGestureRecognizer swipeGesture;
    private ScaleGestureRecognizer scaleGesture;
    
    void Start()
    {
        CreateTapGesture();
        CreateSwipeGesture();
        CreateScaleGesture();
        
    }
    private void ScaleGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            
            print("scale");
        }
    }

    private void CreateScaleGesture()
    {
        scaleGesture = new ScaleGestureRecognizer();
        scaleGesture.StateUpdated += ScaleGestureCallback;
        FingersScript.Instance.AddGesture(scaleGesture);
    }
    private void SwipeGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            print("swipe");

        }
    }
    private void CreateSwipeGesture()
    {
        swipeGesture = new SwipeGestureRecognizer();
        swipeGesture.Direction = SwipeGestureRecognizerDirection.Any;
        swipeGesture.StateUpdated += SwipeGestureCallback;
        swipeGesture.DirectionThreshold = 1.0f; // allow a swipe, regardless of slope
        FingersScript.Instance.AddGesture(swipeGesture);
    }

   
    private void TapGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            print("tap");
        }
    }
    private void CreateTapGesture()
    {
        tapGesture = new TapGestureRecognizer();
        tapGesture.StateUpdated += TapGestureCallback;
        FingersScript.Instance.AddGesture(tapGesture);
    }

}

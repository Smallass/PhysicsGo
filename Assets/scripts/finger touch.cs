using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class FingerTouch : MonoBehaviour
{
    public GameObject ActiveObject;
    private TapGestureRecognizer tapGesture;
    private SwipeGestureRecognizer swipeGesture;
    private ScaleGestureRecognizer scaleGesture;
    
    void Start()
    {
        CreateTapGesture();
        CreateSwipeGesture();
        CreateScaleGesture();
        
    }
    IEnumerator RotateActiveObject(float angle)
    {
        float initAngle = ActiveObject.transform.rotation.eulerAngles.y;
        for (float i = 0.0f; i <= 1.0f; i += Time.deltaTime / 0.3f)
        {
            float newAngle = Mathf.Lerp(initAngle, initAngle + angle, i);
            ActiveObject.transform.rotation = Quaternion.AngleAxis(newAngle, Vector3.up);
            yield return null;
        }
    }
    private void ScaleGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            float newScale = Mathf.Clamp(ActiveObject.transform.localScale.x * scaleGesture.ScaleMultiplier, 0.3f, 3.0f);
            ActiveObject.transform.localScale = new Vector3(newScale,newScale,newScale);

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
            StartCoroutine(RotateActiveObject(-gesture.DistanceX / Screen.width * 360.0f));

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(TrackedPoseDriver))]
public class MRHand : MonoBehaviour {

    TrackedPoseDriver tracker;
    InteractionSourceHandedness handedness;
    bool triggerpressed;
    bool triggerpress;
    bool triggerup;
    bool touchingtouchpad;
    bool touchpadpressed;
    bool touchpadpress;
    bool touchpadup;
    Vector2 touchpadPos;
    bool menupressed;
    bool menupress;
    bool menuup;
    bool grasppressed;
    bool grasppress;
    bool graspup;
    bool thumbstickpress;
    bool thumbstickpressed;
    bool thumbstickup;
    Vector2 thumbstickPos;

    private void Update()
    {
       
        if (GetGraspPress())
            Debug.Log("grasppressonce"+handedness.ToString());
        if (GetGraspPressed())
            Debug.Log("grasppressing" + handedness.ToString());
        if (GetGraspUp())
            Debug.Log("graspup" + handedness.ToString());
        if (GetTouchpadPress())
            Debug.Log("touchpadpressonce" + handedness.ToString());
        if (GetTouchpadPressed())
            Debug.Log("touchpadpressing" + handedness.ToString());
        if (GetTouchpadUp())
            Debug.Log("touchpadup" + handedness.ToString());
        if (GetMenuPress())
            Debug.Log("Menupressonce" + handedness.ToString());
        if (GetMenuPressed())
            Debug.Log("Menupressing" + handedness.ToString());
        if (GetMenuUp())
            Debug.Log("Menuup" + handedness.ToString());
        if (GetTriggerPress())
            Debug.Log("Triggerpressonce" + handedness.ToString());
        if (GetTriggerPressed())
            Debug.Log("Triggerpressing" + handedness.ToString());
        if (GetTriggerUp())
            Debug.Log("Triggerup" + handedness.ToString());
        if (GetThumbStickPress())
            Debug.Log("ThumbStickpressonce" + handedness.ToString());
        if (GetThumbStickPressed())
            Debug.Log("ThumbStickpressing" + handedness.ToString());
        if (GetThumbStickUp())
            Debug.Log("ThumbStickup" + handedness.ToString());        
        if (GetTouchTouching())
            Debug.Log(TouchPadPosition());
            
        
        

    }

    void Start()
    {
        tracker = GetComponent<TrackedPoseDriver>();
        if (tracker.poseSource == TrackedPoseDriver.TrackedPose.LeftPose)
            handedness = InteractionSourceHandedness.Left;
        else
            handedness = InteractionSourceHandedness.Right;
        
        InteractionManager.InteractionSourcePressed += InteractionManager_InteractionSourcePressed;
        InteractionManager.InteractionSourceReleased += InteractionManager_InteractionSourceReleased;
        InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;

    }

   

    void OnDestroy()
    {        
        InteractionManager.InteractionSourcePressed -= InteractionManager_InteractionSourcePressed;
        InteractionManager.InteractionSourceReleased -= InteractionManager_InteractionSourceReleased;
        InteractionManager.InteractionSourceUpdated -= InteractionManager_InteractionSourceUpdated;
    }

    void InteractionManager_InteractionSourcePressed(InteractionSourcePressedEventArgs state)
    {
        if (state.state.source.handedness == handedness)
        {
            switch (state.pressType)
            {
                case InteractionSourcePressType.Select:
                    triggerpress = true;
                    triggerpressed = true;
                    break;
                case InteractionSourcePressType.Menu:
                    menupress = true;
                    menupressed = true;
                    break;
                case InteractionSourcePressType.Grasp:
                    grasppress = true;
                    grasppressed = true;
                    break;
                case InteractionSourcePressType.Touchpad:
                    touchpadpress = true;
                    touchpadpressed = true;
                    break;
                case InteractionSourcePressType.Thumbstick:
                    thumbstickpress = true;
                    thumbstickpressed = true;
                    break;

            }
        }
        
    }

    void InteractionManager_InteractionSourceReleased(InteractionSourceReleasedEventArgs state)
    {
        if (state.state.source.handedness == handedness) { 

            switch (state.pressType)
            {
                case InteractionSourcePressType.Select:                
                    triggerpressed = false;
                    triggerup = true;
                    break;
                case InteractionSourcePressType.Menu:               
                    menupressed = false;
                    menuup = true;
                    break;
                case InteractionSourcePressType.Grasp:               
                    grasppressed = false;
                    graspup = true;
                    break;
                case InteractionSourcePressType.Touchpad:               
                    touchpadpressed = false;
                    touchpadup = true;
                    break;
                case InteractionSourcePressType.Thumbstick:                
                    thumbstickpressed = false;
                    thumbstickup = true;
                    break;

            }
        }


    }
    

    private void InteractionManager_InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
    {
        if (obj.state.source.handedness == handedness)
        {
            touchingtouchpad = obj.state.touchpadTouched;
            touchpadPos = obj.state.touchpadPosition;
            thumbstickPos = obj.state.thumbstickPosition;
        }

        
        
    }

    public bool GetTriggerPress()
    {
        return triggerpress;
    }
    public bool GetTriggerPressed()
    {
        return triggerpressed;
    }
    public bool GetTriggerUp()
    {
        return triggerup;
    }
    public bool GetMenuPress()
    {
        return menupress;
    }
    public bool GetMenuPressed()
    {
        return menupressed;
    }
    public bool GetMenuUp()
    {
        return menuup;
    }
    public bool GetGraspPress()
    {
        return grasppress;
    }
    public bool GetGraspPressed()
    {
        return grasppressed;
    }
    public bool GetGraspUp()
    {
        return graspup;
    }
    public bool GetTouchpadPress()
    {
        return touchpadpress;
    }
    public bool GetTouchpadPressed()
    {
        return touchpadpressed;
    }
    public bool GetTouchpadUp()
    {
        return touchpadup;
    }
    public bool GetTouchTouching()
    {
        return touchingtouchpad;
    }
    public bool GetThumbStickPress()
    {
        return thumbstickpress;
    }
    public bool GetThumbStickPressed()
    {
        return thumbstickpressed;
    }
    public bool GetThumbStickUp()
    {
        return thumbstickup;
    }
    public Vector2 TouchPadPosition()
    {
        return touchpadPos;
    }
    public Vector2 ThumbStickPosition()
    {
        return thumbstickPos;
    }


    private void LateUpdate()
    {
        triggerpress = false;
        menupress = false;
        grasppress = false;
        touchpadpress = false;
        thumbstickpress = false;
        triggerup = false;
        menuup = false;
        graspup = false;
        touchpadup = false;
        thumbstickup = false;
    }

}

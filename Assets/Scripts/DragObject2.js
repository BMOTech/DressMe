#pragma strict

//import HutongGames.PlayMaker;

// Attach this script to an orthographic camera.
private var object : Transform;     // The object we will move.
private var offSet : Vector3;       // The object's position relative to the mouse position.
public static var Selected; // the last object selected
public var HandGrabber : GameObject;
var handClosed : Sprite;
var handOpen : Sprite;

function Start ()
{
//HandGrabber.GetComponent(SpriteRenderer).sprite = idleHand;
}

function Update () {
    var layerMask = 1 << 5;
    layerMask = ~layerMask;
    var ray = camera.ScreenPointToRay(Input.mousePosition);     // Gets the mouse position in the form of a ray.
    if (Input.GetButtonDown("Fire1")) {     // If we click the mouse...
        if (!object) {      // And we are not currently moving an object...
        	HandGrabber.GetComponent(SpriteRenderer).sprite = handOpen;
            var hit : RaycastHit;
            if (Physics.Raycast(ray, hit, Mathf.Infinity, layerMask)) {        // Then see if an object is beneath us using raycasting.
            	HandGrabber.GetComponent(SpriteRenderer).sprite = handOpen;
                object = hit.transform;     // If we hit an object then hold on to the object.
                HandGrabber.GetComponent(SpriteRenderer).sprite = handClosed;
                Selected = hit.transform;
                Debug.Log(Selected);
                object.transform.localScale += Vector3(0.1,0.1,0.1); //increase size
                offSet = object.position-ray.origin;        // This is so when you click on an object its center does not align with mouse position.
            }
        }
    }
    else if (Input.GetButtonUp("Fire1")) {
        object.transform.localScale -= Vector3(0.1,0.1,0.1); //decrease size
        object = null;      // Let go of the object.
       HandGrabber.GetComponent(SpriteRenderer).sprite = handOpen;
    }
    if (object) {
        object.position = Vector3(ray.origin.x+offSet.x, ray.origin.y+offSet.y, ray.origin.z+offSet.z);     // Only move the object on a 2D plane.
    }
   
}
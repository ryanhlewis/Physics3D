# 3D Physics in Unity

This tutorial covers deterministic physics in Unity using trajectories, velocities, and forces.
If you ever wanted to see if a trickshot was possible, simulate it first.

(This is the concept of [digital twins](https://en.wikipedia.org/wiki/Digital_twin). Feel free to look into it!)

#### Basically, beer pong.

![image](https://user-images.githubusercontent.com/76540311/227367904-e32161f6-0ef4-4b7e-a30c-6f6c71c4f5a4.png)

## Tutorial

Let's start out from the basics. Get an empty 3D Unity project.

![image](https://user-images.githubusercontent.com/76540311/227368441-0a2ef8fc-fb9d-471b-a8cc-73c002d6b320.png)
![image](https://user-images.githubusercontent.com/76540311/227368490-4c663a33-0b45-451a-a25a-839c29e9bd5f.png)

Now, let's create a ground layer in our scene. On the left hierarchy, Right Click -> 3D Object -> Plane.

Scale it to be larger, and add a material if you want!

(To add a material, in assets folder, Right Click -> Create -> Material, set Albedo Color, and drag material to plane)

![image](https://user-images.githubusercontent.com/76540311/227369553-e2d36380-39e6-4060-a874-dcf36035c6fa.png)

Now, let's add our physics ball.

On the left side again, Right Click -> 3D Object -> Sphere.

Now, on the sphere properties on the right, Add Component -> "rigid" -> "Rigidbody"
Do NOT click 2D! We are in 3D!!

![image](https://user-images.githubusercontent.com/76540311/227370040-ceda3fc9-f61e-4f8e-8a75-1f8a5ac30476.png)

If everything went smoothly, when you click "Play", your ball should fall!

![ezgif com-video-to-gif](https://user-images.githubusercontent.com/76540311/227372029-a55bc8f2-cc72-4e7a-bdf2-b31360167f1e.gif)

Easy enough. Now, let's make it fall into something. A cup? (Beer pong?) A hole? (Mini-golf?) Anything? 
We know that basically every game has some kind of receptor for this ball, so let's make one.

Make sure you're back in EDIT MODE ~ and not still in PLAY MODE. (Otherwise you will lose work)

On the left side, Right Click -> 3D Object -> Cylinder.
Now, move it into position, scale it so a ball can fit inside.

Now, duplicate and scale for the "inside" of the cylinder.

![image](https://user-images.githubusercontent.com/76540311/227372855-f17db931-c736-4c99-a2e5-01c5fc4312a1.png)
(Color added for effect)

Now, we want to "subtract" the inside cylinder from the outside one.
This is called a **boolean operation**.

Can we do this in Unity?

#### Yes, but..

##### plugins..?

It can be done.. "[ProBuilder](https://docs.unity3d.com/Packages/com.unity.probuilder@5.0/manual/boolean.html)" "[CSG](https://github.com/karl-/pb_CSG)"

Or.. we can just open Blender and do it almost instantly.
(Don't worry if you don't have Blender, here's the model file.)

![cup](https://user-images.githubusercontent.com/76540311/227376160-df522a23-d0a2-47ab-abc5-9f6c30df759c.png)
(Right click and save link as -> change the file extension from .png to .fbx! It's a trick to let me upload it here.)

In Blender, ADD -> Mesh -> Cylinder

![image](https://user-images.githubusercontent.com/76540311/227373877-964dcbcd-2049-473e-a09e-bb3b8c28fda1.png)

Do it again, so we have two cylinders. Now, keybinds!! (Or use the tools, but keybinds are faster.)

Press S to scale the other cylinder, and just slightly drag your mouse inwards to make the other cylinder smaller.

Click to apply the operation.

Now, press G to position the other cylinder so it can reach the top. Notice it moves around! We don't want that!
Press Z now to lock your movement to the Z-axis. Now, it should only move up and down. Move the cylinder up so that
it goes through the top.

![image](https://user-images.githubusercontent.com/76540311/227374509-51295570-e0ff-43eb-9849-7810fad1d704.png)

Now, finally, press S again, but this time, press Z to lock our scale to the Z-axis and scale the inner "hole" cylinder
until are a good distance away from the bottom. We've now made a cup.. somewhat!

(You can play with locking axes if you like. Press X or Y or Z after a G (position) or S (scale) or R (rotation). You can also type numbers after to be super precise.. 
like try S -> Z -> 0.5, to scale your model by half in the Z-axis!)

Okay, time for our boolean operation. Click on the larger cylinder, and on the right side, find the wrench.

![image](https://user-images.githubusercontent.com/76540311/227375050-33976acd-e533-458b-b08d-39b37fede1d7.png)

Now, add a modifier -> Boolean!

![image](https://user-images.githubusercontent.com/76540311/227375150-ef707fc5-fc02-4714-8d22-bbc85601eac6.png)

Make sure to have "Difference" selected, and use the Eyedropper tool to select our hole (the inner cylinder).

![image](https://user-images.githubusercontent.com/76540311/227375383-e8bd8f58-a334-467d-a3fe-1a95c91cd232.png)

Finally, click the drop down arrow (in the modifier properties) and click Apply.

![image](https://user-images.githubusercontent.com/76540311/227375457-c8fa2aea-d19a-4ecb-a7eb-24275c46ca4a.png)

Now, delete your second (inner) cylinder! We don't need it anymore. It served its purpose.

![image](https://user-images.githubusercontent.com/76540311/227375642-2616fad9-ae32-4a5e-9561-ac3ceb5db2cc.png)

We now have a cup!

File -> Export -> FBX

![image](https://user-images.githubusercontent.com/76540311/227375714-8b3c632d-b21d-4854-9666-bb84972c6d7d.png)

And remember to disable "camera" and other silly exports. We don't want those!
Select only mesh.

![image](https://user-images.githubusercontent.com/76540311/227375857-f9983699-fbcb-4867-99f8-7b8f63590cb8.png)

And now just drag the FBX file into your Unity project, 
position a little under the ball.

![image](https://user-images.githubusercontent.com/76540311/227376584-5bab9b46-69e1-4855-aa8b-a14b1a23e817.png)

It looks right and falls right in.. or does it?

![image](https://user-images.githubusercontent.com/76540311/227376757-891e6749-68eb-4c4b-8f6e-f7804a873488.png)

We need a collider on our cup. Click the cup -> Add Component -> Mesh Collider.

![image](https://user-images.githubusercontent.com/76540311/227376841-6f2c84b1-6836-4d0a-9f6b-4965b4eda4c4.png)

Perfect.

![image](https://user-images.githubusercontent.com/76540311/227376900-06f7f210-4f01-4126-b9a7-f9cc9d1bddcd.png)

Now, we can play with Physics properties, like bounciness, friction, and do trajectories..

Let's select our ball, go to Add Component -> "trickshot" -> and make a new script.

This should open as trickshot.cs, and we can simply do..

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trickshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        // Apply a z velocity of 25.7f to the ball
        // by rigidbody
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 25.8f);

    }

}
```

And our ball will go flying off!

This is fun.. but we have no idea where we're going!

Let's do some trajectories.
I won't subject you to the math here, but it's just every physics equation ever.

Add Component -> TrajectoryController -> and make a new script.

This should open as TrajectoryController.cs, and we can simply do..

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryController : MonoBehaviour
{
    [Header("Line renderer veriables")]
    public LineRenderer line;
    [Range(2, 30)]
    public int resolution;

    [Header("Formula variables")]
    public Vector3 velocity;
    public float yLimit;
    private float g;

    [Header("Linecast variables")]
    [Range(2, 30)]
    public int linecastResolution;
    public LayerMask canHit;

    private void Start()
    {
        g = Mathf.Abs(Physics.gravity.y);
    }

    private void Update()
    {
        RenderArc();
    }

    private void RenderArc()
    {
        line.positionCount = resolution + 1;
        line.SetPositions(CalculateLineArray());
    }

    private Vector3[] CalculateLineArray()
    {
        Vector3[] lineArray = new Vector3[resolution + 1];

        var lowestTimeValueX = MaxTimeX() / resolution;
        var lowestTimeValueZ = MaxTimeZ() / resolution;
        var lowestTimeValue = lowestTimeValueX > lowestTimeValueZ ? lowestTimeValueZ : lowestTimeValueX;

        for (int i = 0; i < lineArray.Length; i++)
        {
            var t = lowestTimeValue * i;
            lineArray[i] = CalculateLinePoint(t);
        }

        return lineArray;
    }

    private Vector3 HitPosition()
    {
        var lowestTimeValue = MaxTimeY() / linecastResolution;

        for (int i = 0; i < linecastResolution + 1; i++)
        {
            RaycastHit rayHit;

            var t = lowestTimeValue * i;
            var tt = lowestTimeValue * (i + 1);

            if (Physics.Linecast(CalculateLinePoint(t), CalculateLinePoint(tt), out rayHit, canHit))
                return rayHit.point;
        }

        return CalculateLinePoint(MaxTimeY());
    }

    private Vector3 CalculateLinePoint(float t)
    {
        float x = velocity.x * t;
        float z = velocity.z * t;
        float y = (velocity.y * t) - (g * Mathf.Pow(t, 2) / 2);
        return new Vector3(x + transform.position.x, y + transform.position.y, z + transform.position.z);
    }

    private float MaxTimeY()
    {
        var v = velocity.y;
        var vv = v * v;

        var t = (v + Mathf.Sqrt(vv + 2 * g * (transform.position.y - yLimit))) / g;
        return t;
    }

    private float MaxTimeX()
    {
        if (IsValueAlmostZero(velocity.x))
            SetValueToAlmostZero(ref velocity.x);

        var x = velocity.x;

        var t = (HitPosition().x - transform.position.x) / x;
        return t;
    }

    private float MaxTimeZ()
    {
        if (IsValueAlmostZero(velocity.z))
            SetValueToAlmostZero(ref velocity.z);

        var z = velocity.z;

        var t = (HitPosition().z - transform.position.z) / z;
        return t;
    }

    private bool IsValueAlmostZero(float value)
    {
        return value < 0.0001f && value > -0.0001f;
    }

    private void SetValueToAlmostZero(ref float value)
    {
        value = 0.0001f;
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }
}
```

Don't worry about understanding this code! It's physics.

Now, make a new "line" object in our scene, apply it to our "line" in the controller.. and..
if you adjust the velocity slightly..

![image](https://user-images.githubusercontent.com/76540311/227382448-16fa2f41-06c7-47cb-9635-b3ab311ae26b.png)









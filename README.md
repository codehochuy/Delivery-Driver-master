### Driver.cs

##### Debud.Log(message);
* Output some info into console.
##### Time.deltaTime
* Using `Time.deltaTime` Unity can tell us how long each frame took to execute.
* When we multiply something by `Time.deltaTime` it makes our game "frame rate independent".
* Ie. The game behaves the same on fast and slow computers.

***
### Collision.cs -> was renamed to Delivery.cs
##### OnCollisionEnter2D Method
* Collision action.

##### OnTriggerEnter2D method
* Actions when interacting with a trigger.

##### If Statements
If statements let us check if something is true or not and then do something based upon the result.
```
if(this thing is true)
{
    do this thing;
}
```
##### Why Use Tags?
Tags allow us to easily check in code if something belongs to a particular category of thing.

##### What Is a Bool?
* Bools are types of variables that can store one of two values - true or false.
* They are often used with if statements to decide whether something happens or not.

##### Destroying Game Objects
* We call `Destroy()` to delete game objects from the scene.
* `Destroy()` requires us to tell it ("pass in") 2 things:
    * Which game object to destroy.
    * How much delay until its destroyed.`

Example: `Destroy(theMonster.gameObject, 0.5f);`
***
### FollowCamera.cs
##### Creating a reference
If we want to access / change / call anything other than this game object's transform, we need to create a reference.

Ie. we need to tell Unity what the "thing" is that we are referring to.
"# Delivery-Driver-master" 
"# Delivery-Driver-master" 

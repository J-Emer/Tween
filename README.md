# Tween

Simple Tweening system for Monogame projects.

&nbsp;
&nbsp;

## Building

This project is a c# ClassLibrary for Monogame. Simply build the project, and reference the .dll in your Monogame project. 


&nbsp;
&nbsp;

## Useage: 

First create an instance of the Tween System.

```csharp 
new Tween_System();
``` 

Any tweens you create will auto register with the tween system. The Tween_System is a Singleton.



Next create an instance of a "Tween", for this example I'm using a Vec2_Tweener.

```csharp
            _positionTweener = new Vec2_Tweener
            {
                Name = "Position_Tweener",
                IsActive = true,
                Start = new Vector2(100,100),
                End = new Vector2(300,200),
                Duration = 2f
            };
```

Other types of Tweens are Float_Tweener, and Color_Tweener. 

&nbsp;
&nbsp;

## Setting the "Output" property

There are 2 ways of seeting the "Output"


### #1
Simply setting the property you wish to change = to the "Output" property of the Tween. For this example I am setting the "Position" property of a "Player" class

```csharp
        public void Update()
        {
            _player.Position = _positionTweener.Output;
        }
```

Note! Using this method you will have to set the "Position" every frame in the Update(), like I did above.


### #2
Subscribing to the Tweens HandleOutput event. This will fire after the Tweener has done its internal Update()


```csharp
         _positionTweener.HandleOutput += Output;

        private void Output(Vector2 _newPosition)
        {
            _player.Position = _newPosition;
        }

```

&nbsp;
&nbsp;


## Getting a Tween from the Tween_System

The Tween_System uses generics to "Get" a Tween. The "GetTweener<T>" has 2 overloads.

```csharp
            GetTweener<T>()
```
            
will simply return the first Tweener of Type<T> that it finds

```csharp
            GetTweener<T>(string _name)
```
            
will return the Tweener with the supplied name and return it as a Type<T>

Useage: 

```csharp
            Vec2_Tweener _someTweener = Tweener_System.Instance.GetTweener<Vec2_Tweener>();
            Vec2_Tweener _someOtherTweener = Tweener_System.Instance.GetTweener<Vec2_Tweener>("Position_Tweener");
```

&nbsp;
&nbsp;

            
## Flip() & Flip_And_Wait()

Calling a Tweens ```Flip()``` will reverse the Tween. Ie that start is now the endpoint, and the end is now the start point. This will reset its ```IsActive = true``` 

Calling a Tweens ```Flip_And_Wait()``` will reverse the Start & End, but will leave the ``` IsActive = false```. You will have to manually set the "IsActive" property to restart the Tween.           

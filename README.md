# Tween

Simple Tweening system for Monogame projects.

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
Subscribing the the Tweens HandleOutput event. This will fire after the Tweener has done its internal Update()


```csharp
         _positionTweener.HandleOutput += Output;

        private void Output(Vector2 _newPosition)
        {
            _player.Position = _newPosition;
        }

```

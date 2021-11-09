using System;
using Microsoft.Xna.Framework;

namespace Tween
{
    public abstract class Tween_Base
    {
        public string Name{get; set;}
        public bool IsActive{get;set;} = true;
        
        //public int RepeatLimit{get;set;} = 1;
        //todo: Need to add in the RepeatLimit property at some point -> Only Flip() should countdown the Limit? -> How to cache the Limit for the Reset()? 
            
        public Tween_Base()
        {
            this.Name = this.GetType().Name;
            Tweener_System.Instance.Add(this);
        }

        public abstract void Update(GameTime __gameTime);
    }


    public abstract class Base_Tween<T> : Tween_Base
    {
        public T Start;
        public T End;
        public T Output;

        public float Duration;
        private float _timer;
        protected float _timeStep;


        public event Action OnStart;
        public event Action OnFinish;

        public event Action<T> HandleOutput;
        private bool _startFlag = false;
        private bool _endFlag = false;


        public override void Update(GameTime _gameTime)
        {
            if(!IsActive){return;}

            if(_timer >= Duration)
            {
                if(!_endFlag)
                {
                    _endFlag = true;
                    IsActive = false;
                    OnFinish?.Invoke();
                }
                return;
            }

            if(!_startFlag)
            {
                _startFlag = true;
                OnStart?.Invoke();
            }

            _timer += (float)_gameTime.ElapsedGameTime.TotalSeconds;   
            _timeStep = Normalize(_timer, 0, Duration); 

            Set();        

            HandleOutput?.Invoke(Output);
        }

        public void Flip()
        {
            var _tempStart = Start;
            var _tempEnd = End;
            
            Start = _tempEnd;
            End = _tempStart;

            _timer = 0;

            _startFlag = false;
            _endFlag = false;

            IsActive = true;
        }

        public void Reset()
        {
            _timer = 0;
            _startFlag = false;
            _endFlag = false;
            IsActive = true;
        }

        public abstract void Set();

        protected float Normalize(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }
    }
}

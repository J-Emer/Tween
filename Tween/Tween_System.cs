using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace Tween
{
    public class Tweener_System
    {
        public static Tweener_System Instance;

        private List<Tween_Base> _tweens = new List<Tween_Base>();


        public Tweener_System()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }
        public void Destroy()
        {
            Instance = null;
        }
        public void Add(Tween_Base _tween)
        {
            _tweens.Add(_tween);
        }
        public void Remove(Tween_Base _tween)
        {
            _tweens.Add(_tween);
        }
        public void Update(GameTime _time)
        {
            for (int i = 0; i < _tweens.Count; i++)
            {
                _tweens[i].Update(_time);
            }
        }
        public T GetTweener<T>() where T : Tween_Base
        {
            var _obj = _tweens.FirstOrDefault(x => x.GetType() == typeof(T));

            if(_obj != null)
            {
                return (T)_obj;
            }

            return null;
        }

        public T GetTweener<T>(string _name) where T : Tween_Base
        {
            var _obj = _tweens.FirstOrDefault(x => x.Name == _name);

            if(_obj != null)
            {
                return (T)_obj;
            }

            return null;
        }
    }
}

using Microsoft.Xna.Framework;

namespace Tween
{
    public class Vec2_Tweener : Base_Tween<Vector2>
    {
        public override void Set()
        {
            Output = Vector2.Lerp(Start, End, _timeStep);
        }
    }
    public class Float_Tweener : Base_Tween<float>
    {
        public override void Set()
        {
            Output = MathHelper.Lerp(Start, End, _timeStep);
        }
    }
    public class Color_Tweener : Base_Tween<Color>
    {
        public override void Set()
        {
            Output = Color.Lerp(Start, End, _timeStep);
        }
    }
}

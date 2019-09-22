using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FunFun.Easing
{
    public static class Easing{
        
        public delegate float EasingFunction (float t);

        // Operators
        public static float Flip(this float t){
            return 1-t;
        }

        public static float Clamp(this float t){
            return t > 1 ? 1 : 
                   t < 0 ? 0 : t;
        }

        public static float Lerp(this float t, EasingFunction a, EasingFunction b){
            return (1-t) * a(t) + t * b(t);
        }

        public static float Mix(this float t, EasingFunction a, EasingFunction b, float percent){
            return (1-percent) * a(t) + percent * b(t);
        }


        public static float Scale(this float t, float s){
            return t * s;
        }

        public static float ReverseScale(this float t, float s){
            return (1-t) * s;
        }






        public static float SmoothBegin2(this float t){
            return t*t;
        }

        public static float SmoothBegin3(this float t){
            return t*t*t;
        }

        public static float SmoothBegin4(this float t){
            return t*t;
        }

        public static float SmoothBegin5(this float t){
            return t*t*t*t*t;
        }

        public static float SmoothBeginN(this float t, int exponent){
            for(int i = 0; i < exponent; i++){
                t *= t;
            }
            
            return t;
        }
        


        // Compound functions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothEnd2(this float t){
            return t.Flip().SmoothBegin2().Flip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothEnd3(this float t){
            return t.Flip().SmoothBegin3().Flip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothEnd4(this float t){
            return t.Flip().SmoothBegin4().Flip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothEnd5(this float t){
            return t.Flip().SmoothBegin5().Flip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothEndN(this float t, int exponent){
            return t.Flip().SmoothBeginN(exponent).Flip();
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep2(this float t){
            return t.Lerp(SmoothBegin2, SmoothEnd2);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep3(this float t){
            return t.Lerp(SmoothBegin3, SmoothEnd3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep4(this float t){
            return t.Lerp(SmoothBegin4, SmoothEnd4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep5(this float t){
            return t.Lerp(SmoothBegin5, SmoothEnd5);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Arch(this float t){
            return t.Flip().Scale(t);
        }









    }   



    
}
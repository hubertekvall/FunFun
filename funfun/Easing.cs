using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FunFun
{
    public static class Easing{


        // Operators
        public static float Flip(this float t){
            return 1-t;
        }

        public static float Scale(this float t, float s){
            return t * s;
        }

        public static float ReverseScale(this float t, float s){
            return (1-t) * s;
        }

        public static float SmoothStart2(this float t){
            return t*t;
        }

        public static float SmoothStart3(this float t){
            return t*t*t;
        }

        public static float SmoothStart4(this float t){
            return t*t;
        }

        public static float SmoothStart5(this float t){
            return t*t*t*t*t;
        }

        public static float SmoothStartN(this float t, int exp){
            for(int i = 0; i < exp; i++){
                t *= t;
            }
            
            return t;
        }
        


        // Compound functions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStop2(this float t){
            return t.Flip().SmoothStart2().Flip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStop3(this float t){
            return t.Flip().SmoothStart3().Flip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStop4(this float t){
            return t.Flip().SmoothStart4().Flip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStop5(this float t){
            return t.Flip().SmoothStart5().Flip();
        }




        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep2(this float t){
            return (1-t) * SmoothStart2(t) + t * SmoothStop2(t);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep3(this float t){
            return (1-t) * SmoothStart3(t) + t * SmoothStop3(t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep4(this float t){
            return (1-t) * SmoothStart4(t) + t * SmoothStop4(t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep5(this float t){
            return (1-t) * SmoothStart5(t) + t * SmoothStop5(t);
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Arch(this float t){
            return t.Flip().Scale(t);
        }





    }   



    
}
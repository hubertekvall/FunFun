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

        public static float SmoothBeginN(this float t, int exp){
            for(int i = 0; i < exp; i++){
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
        public static float SmoothStep2(this float t){
            return (1-t) * SmoothBegin2(t) + t * SmoothEnd2(t);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep3(this float t){
            return (1-t) * SmoothBegin3(t) + t * SmoothEnd3(t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep4(this float t){
            return (1-t) * SmoothBegin4(t) + t * SmoothEnd4(t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep5(this float t){
            return (1-t) * SmoothBegin5(t) + t * SmoothEnd5(t);
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Arch(this float t){
            return t.Flip().Scale(t);
        }





    }   



    
}
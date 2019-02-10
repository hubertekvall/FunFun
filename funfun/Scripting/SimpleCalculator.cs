using System;
using System.Collections;
using System.Collections.Generic;

namespace FunFun.Scripting
{

    struct Slice<T>
    {
        T[] source;

        int left, right;


        public T this[int index]
        {
            get
            {
                return source[left + index];
            }
        }

        public Slice<T> slice(int l)
        {
            Slice<T> newSlice = new Slice<T>(source, left + l);

            return newSlice;
        }

        public Slice<T> slice(int l, int r)
        {
            Slice<T> newSlice = new Slice<T>(source, left + l, right - r);

            return newSlice;
        }



        public Slice(T[] source)
        {
            this.source = source;
            this.left = 0;
            this.right = source.Length - 1;
        }



        public Slice(T[] source, int left)
        {
            this.source = source;
            this.left = left;
            this.right = source.Length - 1;
        }


        public Slice(T[] source, int left, int right)
        {
            this.source = source;
            this.left = left;
            this.right = right;
        }


    }




    public static class SimpleCalculator
    {

        struct ParseData{
            public Slice<char> data;
            public bool success;
            public static implicit operator bool(ParseData r)
            {
                return r.success;
            }


            public ParseData(Slice<char> data, bool success){
                this.data = data;
                this.success = success;
            }

            public ParseData Fail(){
                this.success = false;
                return this;
            }
        }

        


        delegate ParseData Parser(ParseData input);
    
        static ParseData And(ParseData input, params Parser[] parsers){
        
            ParseData current = input;

            for(int i = 0; i < parsers.Length; i++){
                current = parsers[i](current);
                if(!current) return input.Fail();
            }

            return current;
        }

        static ParseData Or(ParseData input, params Parser[] parsers)
        {
            ParseData current = input;

            for(int i = 0; i < parsers.Length; i++){
                
                current = parsers[i](current);
                if(current) return current;
            }

            return input.Fail();
        }

     




        static ParseData Add(ParseData input){
            return input;
        }

  

        static ParseData Expression(ParseData input){
            return And(input, Factor, Many);
        }







     


    }

}

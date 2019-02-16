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






    public class SimpleCalculator
    {

        static void Main(string[] args)
        {
            // Display the number of command line arguments:
            System.Console.WriteLine(args.Length);
        }


        static Stack<Slice<char>> sliceBuffer;
        static Slice<char> currentSlice;


        public SimpleCalculator()
        {
            sliceBuffer = new Stack<Slice<char>>(1024);
        }




        public delegate bool Parser();

        public struct ParserCombinator
        {
            Parser parser;

            public ParserCombinator(Parser parser)
            {
                this.parser = parser;
            }


            public bool Run()
            {
                var cache = currentSlice;
                bool result = parser();

                if (result)
                {
                    return true;
                }
                else
                {
                    currentSlice = cache;
                    return false;
                }
            }


            public static implicit operator ParserCombinator(string s)
            {
                return new ParserCombinator(
                    StringParser(s)
                );
            }


            public static implicit operator ParserCombinator(char c)
            {
                return new ParserCombinator(
                    CharParser(c)
                );
            }



            public static implicit operator ParserCombinator(Parser p)
            {
                return new ParserCombinator(p);
            }
        }








        public static Parser And(params ParserCombinator[] parsers)
        {
            return delegate ()
            {

                for (int i = 0; i < parsers.Length; i++)
                {
                    if (!parsers[i].Run()) return false;
                }

                return true;
            };
        }

        public static Parser Or(params ParserCombinator[] parsers)
        {

            return delegate ()
            {
                for (int i = 0; i < parsers.Length; i++)
                {
                    if (parsers[i].Run()) return true;
                }

                return false;
            };
        }


        public static Parser Many(params ParserCombinator[] parsers)
        {
            return delegate ()
            {
                bool result = true;

                while (result)
                {
                    for (int i = 0; i < parsers.Length; i++)
                    {
                        result = parsers[i].Run();
                    }
                }

                return result;
            };
        }



        public static Parser Range(char start, char end){
            return delegate(){
                return true;
            };
        }


        public static Parser StringParser(string s)
        {
            return delegate ()
            {
                return false;
            };
        }


        public static Parser CharParser(char c)
        {
            return delegate ()
            {
                return false;
            };
        }








        static Parser Number = Range('0', '9');


        static Parser Primary = 
            And(
                Or(
                    '(', Expression, ')',
                    Number,
                    Many(),
                    And('-', Primary)
                ) 
            );


        static Parser MulDiv = 
            And(
                Or('*', '/'),
                Primary
            );


        static Parser AddSub = 
            And(
                Or('+', '-'),
                Factor
            );
 


        static Parser Factor = 
            And(
                Primary,
                Many(MulDiv)
            );


        static Parser Expression = 
            And(
                Factor,
                Many(AddSub)
            );
       













    }

}

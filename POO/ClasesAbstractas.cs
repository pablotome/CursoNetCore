using System;

namespace POO
{
    public abstract class A
    {
        public abstract void F();
    }

    public abstract class B : A
    {
        public void G()
        {
            Console.WriteLine("Metodo B.G");
        }
    }

    public class C : B
    {
        public override void F()
        {
            Console.WriteLine("Metodo C.F");
        }
    }

    public class D : A
    {
        public override void F()
        {
            Console.WriteLine("Metodo D.F");
        }
    }
}
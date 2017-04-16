using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpTest0416
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit unit1 = new Unit("user1", 100f);

            Unit unit2 = new Unit("user2", 200f);
            
            Console.ReadKey();
        }
    }

    public struct Status
    {
        public string name;
        public float fHp;

        public Status(string _name, float _fHp)
        {
            name = _name;
            fHp = _fHp;
        }
    }

    public class Unit
    {
        delegate void delEvent();
        delEvent eventFunc;
        Queue<delEvent> eventQueue = new Queue<delEvent>();

        Status stat;

        public Unit() { }
        
        public Unit(string _name, float _fHp)
        {
            stat = new Status(_name,_fHp);
            eventQueue.Enqueue(CheckName);
            eventQueue.Enqueue(CheckHp);
            PrintQueue();
        }

        public void PrintQueue()
        {
            while (eventQueue.Count != 0)
            {
                eventFunc = eventQueue.Peek();
                eventFunc();
                eventQueue.Dequeue();
            }

            Console.WriteLine(string.Format("-------------------"));
        }

        void CheckName()
        {
            Console.WriteLine(string.Format("name : {0}", stat.name));
        }

        void CheckHp()
        {
            Console.WriteLine(string.Format("hp : {0}", stat.fHp));
        }
    }
}

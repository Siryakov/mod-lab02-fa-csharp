using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    // Класс, представляющий состояние автомата
    public class State
    {
        public string Name;  // Название состояния
        public Dictionary<char, State> Transitions;  // Переходы из текущего состояния по символам
        public bool IsAcceptState;  // Флаг, указывающий, является ли состояние финальным (принимающим)
    }


    // Класс, реализующий конечный автомат FA1
    public class FA1
    {
        public static readonly State a = new State { Name = "a", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        public static readonly State b = new State { Name = "b", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
        public static readonly State с = new State { Name = "с", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

        public static readonly State InitialState = a;
        public FA1()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = a;
            b.Transitions['1'] = с;
            с.Transitions['1'] = с;
        }

        // Метод Run выполняет обработку входной последовательности символов и возвращает результат
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            // Проверяем наличие перехода для всех символов во входной последовательности с использованием LINQ
            return s.All(c => current.Transitions.TryGetValue(c, out current)) ? current.IsAcceptState : (bool?)null;
        }
    }
    // дял классов FA2 и FA3 всё аналогично
    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA2()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;

            b.Transitions['0'] = a;
            b.Transitions['1'] = d;

            c.Transitions['0'] = d;
            c.Transitions['1'] = a;

            d.Transitions['0'] = c;
            d.Transitions['1'] = b;
        }

        // Метод Run выполняет обработку входной последовательности символов и возвращает результат
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            // Проверяем наличие перехода для всех символов во входной последовательности с использованием LINQ
            return s.All(c => current.Transitions.TryGetValue(c, out current)) ? current.IsAcceptState : (bool?)null;
        }
    }
    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA3()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;

            b.Transitions['0'] = a;
            b.Transitions['1'] = c;

            c.Transitions['0'] = a;
            c.Transitions['1'] = d;

            d.Transitions['0'] = d;
            d.Transitions['1'] = d;
        }

        // Метод Run выполняет обработку входной последовательности символов и возвращает результат
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            // Проверяем наличие перехода для всех символов во входной последовательности с использованием LINQ
            return s.All(c => current.Transitions.TryGetValue(c, out current)) ? current.IsAcceptState : (bool?)null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String s = "1110111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}

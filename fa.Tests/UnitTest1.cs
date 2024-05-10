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
        // Определение состояний автомата FA1
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State e = new State()
        {
            Name = "e",
            IsAcceptState = true, 
            Transitions = new Dictionary<char, State>()
        };

        static State InitialState = a;  // Начальное состояние автомата

        // Конструктор класса FA1, определяющий переходы между состояниями
        public FA1()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;

            b.Transitions['0'] = d;
            b.Transitions['1'] = e;

            c.Transitions['0'] = e;
            c.Transitions['1'] = c;

            d.Transitions['0'] = d;
            d.Transitions['1'] = d;

            e.Transitions['0'] = d;
            e.Transitions['1'] = e;
        }

        // Метод Run выполняет обработку входной последовательности символов и возвращает результат
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // Цикл по всем символам входной строки
            {
                if (!current.Transitions.ContainsKey(c))  // Проверяем, есть ли переход по текущему символу
                    return null;  // Если нет, возвращаем null

                current = current.Transitions[c];  // Переходим в новое состояние в соответствии с текущим символом
            }
            return current.IsAcceptState;  // Возвращаем true, если достигнуто финальное состояние, иначе false
        }
    }
    // дял классов FA@ и FA3 всё аналогично
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

            b.Transitions['0'] = a; // После прочтения '0' переходим обратно в начальное состояние
            b.Transitions['1'] = d; // После прочтения '1' переходим в финальное состояние

            c.Transitions['0'] = d;
            c.Transitions['1'] = a;

            d.Transitions['0'] = c;
            d.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
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

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
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

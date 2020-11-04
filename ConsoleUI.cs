using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_labRSP
{   
    /// <summary>
    /// Класс ConsoleUI предназначен для создания простого консольного меню.
    /// </summary>
    class ConsoleUI
    {
        public delegate void FunctionEvent();

        private struct menuItem
        {
            public string nameItem;
            public FunctionEvent functionEvent;

            public menuItem(string nameItem, FunctionEvent functionEvent)
            {
                this.nameItem = nameItem;
                this.functionEvent = functionEvent;
            }
        }

        /// <summary>
        /// Название программы отображаемое перед пунктами меню
        /// </summary>
        public string title;

        /// <summary>
        /// Отступ по вертикали.
        /// Высота отступа исчисляется пропусками строк
        /// </summary>
        public byte height;

        /// <summary>
        /// Отступ по горизонтале.
        /// Длина отступа исчисляется пробелами
        /// </summary>
        public byte weight;

        private string indent; // Вычисляемый отступ по горизонтале

        /// <summary>
        /// Индекс текущего пункта меню, соответсвует индексу в menuItems
        /// </summary>
        public int indexItemMenu { get; private set; } // индекс текущего/выделенного айтема

        private List<menuItem> menuItems = new List<menuItem>
        {
            new menuItem("О UI", new FunctionEvent(() => { Console.WriteLine("Для создания интерфейса использовался мой модульный" +
                " класс \"ConsoleUI\"."); })),
            new menuItem("Exit", new FunctionEvent(() => { Environment.Exit(0); }))
        }; // Список пунктов меню и привязанным к ним функции 

        /// <summary>
        /// Конструктор иницилизирующий название программы и отступы
        /// </summary>
        /// <param name="title">Название программы отображаемое перед пунктами меню, по умолчанию "Программа 1"</param>
        /// <param name="height">Отступ по вертикали, по умолчанию 5</param>
        /// <param name="weight">Отступ по горизонтале, по умолчанию 30</param>
        public ConsoleUI(string title = "Программа 1", byte height = 5, byte weight = 30)
        {
            this.title = title;
            this.height = height;
            this.weight = weight;
        } 

        /// <summary>
        /// Метод для добавления нового пункта меню
        /// </summary>
        /// <param name="name">Название пункта меню</param>
        /// <param name="functionEvent">Функция выполняемое пунктом меню</param>
        public void AddItem(string name, FunctionEvent functionEvent) // внесение в список нового айтема
        {
            menuItems.Insert(0, new menuItem(name, functionEvent));
        }

        private void DrawMenu(List<menuItem> items) // отрисовка всех айтемов из списка и выделение текущего айтема
        {
            indent = RepeatStr(" ", weight);

            Console.Write(RepeatStr("\n", height));
            Console.WriteLine(indent + title);
            Console.WriteLine(indent + "=====" + RepeatStr("=", 50));

            for (int i = 0; i < items.Count; i++)
            {
                
                if (i == indexItemMenu)
                {
                    Console.WriteLine(indent + "| > " + $"{items[i].nameItem, 50}|");
                }
                else
                {
                    Console.WriteLine(indent + "|   " + $"{items[i].nameItem, 50}|");
                }
                Console.ResetColor();                
            }

            Console.WriteLine(indent + "=====" + RepeatStr("=", 50));

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (indexItemMenu == items.Count - 1)
                {
                    //index = 0; //Remove the comment to return to the topmost item in the list
                }
                else { indexItemMenu++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (indexItemMenu <= 0)
                {
                    //index = menuItem.Count - 1; //Remove the comment to return to the item in the bottom of the list
                }
                else { indexItemMenu--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                pressEnter();
            }          

            Console.Clear();
        }      

        /// <summary>
        /// Метод предназначенный для отрисовки меню.
        /// </summary>
        public void startDrawMenu()
        {
            Console.CursorVisible = false;
            while (true)
            {
                DrawMenu(menuItems);                         
            }
        } //Перманентный цикл с отрисовкой айтемов

        private void pressEnter()
        {
            Console.Clear();
            menuItems[indexItemMenu].functionEvent();
            Console.Write($"\nнажмите любую клавишу чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        } 

        private static string RepeatStr(string a, int b)
        {
            string text = "";
            for (int i = 0; i < b; i++)
                text += a;
            return text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_labRSP
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI uI = new ConsoleUI("Лабораторные по РСП");
            uI.AddItem("Лабораторная 1", Lab1);
            uI.startDrawMenu();
            
        }

        static void Lab1()
        {
            Console.Write("Сколько книг? = ");
            int kol = Convert.ToInt32(Console.ReadLine());

            Book[] book = new Book[kol];

            for (int i = 0; i < book.Length; i++)
            {
                book[i] = new Book();
                book[i].Id = i;
                Console.Write("Название книги: ");
                book[i].Name = Console.ReadLine();
                Console.Write("Сколько авторов у книги? = ");
                byte kolA = Convert.ToByte(Console.ReadLine());
                for (int j = 0; j < kolA; j++)
                {
                    Console.Write($"{j, 3}. ФИО автора : ");
                    book[i].authors.Add(Console.ReadLine());
                }
                Console.Write("Издательство: ");
                book[i].PublihingHouse = Console.ReadLine();
                Console.Write("Год издания: ");
                book[i].PublishDate = Convert.ToInt32(Console.ReadLine());
                Console.Write("Количество страниц: ");
                book[i].NumberOfPages = Convert.ToInt32(Console.ReadLine());
                Console.Write("Цена: ");
                book[i].Price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Тип переплета: ");
                book[i].TypeOfBinding = Console.ReadLine();
            }

            for(int i = 0; i < book.Length; i++)
            {
                Console.WriteLine($"{"",10}|====================|========================================|");
                Console.WriteLine($"{"",10}|ID :                |{book[i].Id,-40}|");
                Console.WriteLine($"{"",10}|ФИО авторов :       |{string.Join("; ", book[i].authors), -40}|");
                Console.WriteLine($"{"",10}|Издательство :      |{book[i].PublihingHouse, -40}|");
                Console.WriteLine($"{"",10}|Год издания :       |{book[i].PublishDate, -40}|");
                Console.WriteLine($"{"",10}|Количество страниц :|{book[i].NumberOfPages,-40}|");
                Console.WriteLine($"{"",10}|Цена :              |{book[i].Price,-40}|");
                Console.WriteLine($"{"",10}|Тип переплета :     |{book[i].TypeOfBinding,-40}|");
                Console.WriteLine($"{"",10}|====================|========================================|");
            }

            Console.Write("Найдем книги по автору: ");
            string poisk = Console.ReadLine();
            Console.WriteLine("|========================================|");
            for (int i = 0; i < book.Length; i++)
            {
                for (int j = 0; j < book[i].authors.Count; j++)
                {
                    if (book[i].authors[j] == poisk)
                    {
                        Console.WriteLine($"|{book[i].Name,-40}|");
                    }
                }
            }
            Console.WriteLine("|========================================|");

            Console.Write("Найдем книги по издателю: ");
            poisk = Console.ReadLine();
            Console.WriteLine("|========================================|");
            for (int i = 0; i < book.Length; i++)
            {                
                if (book[i].PublihingHouse == poisk)
                {
                    Console.WriteLine($"|{book[i].Name,-40}|");
                }
            }
            Console.WriteLine("|========================================|");

            Console.Write("Найдем все книги старше: ");
            poisk = Console.ReadLine();
            Console.WriteLine("|========================================|");
            for (int i = 0; i < book.Length; i++)
            {               
                if (book[i].PublishDate > Convert.ToInt32(poisk))
                {
                    Console.WriteLine($"|{book[i].Name,-40}|");
                }
            }
            Console.WriteLine("|========================================|");
        } 
    }
}

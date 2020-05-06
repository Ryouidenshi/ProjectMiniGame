using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace Film_Libary
{
    class Program
    {
        public static void Main(string[] args)
        {
            string writePath = @"Путь к файлу";
            Console.WriteLine("Сейчас мы предоставим вам фильмотеку, дайте оценку фильмам");
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(1000);
            var listFilms = new List<Film>();
            CreateFilm(listFilms);
            foreach (var film in listFilms)
            {
                Print(film, false);
                Console.WriteLine("----------------------------------------------------");
                while (true)
                {
                    Console.Write("Ваша оценка фильму (Максимум 10): ");
                    film.Estimation = int.Parse(Console.ReadLine());
                    if (film.Estimation > 10)
                        throw new Exception("Вы выбрил не то!");
                    Console.WriteLine();
                    Console.WriteLine("1 - Посмотреть позже, 2 - Просмотрено, 3 - Хочу посмотреть");
                    Console.WriteLine();
                    Console.Write("Ваш выбор: ");
                    film.Mark = GetMark(film);
                    Console.WriteLine("----------------------------------------------------");
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Ваш результат: ");
                Print(film, true);
                Console.WriteLine("PIZDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                for (int i = 0; i < 3; i++)
                    Console.WriteLine();
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    var actors = new StringBuilder();
                    foreach (var actor in film.Actors)
                        actors.Append(actor + ", ");
                    sw.WriteLine("Оригинальное название фильма - {0}\nРусское название - {1}\n" +
                "Режиссёр - {2}\nАктёры - {3}\nСостояние - {4}\nОценка - {5}\n", film.OriginalName, film.Name, film.Director,
                                actors.ToString(), film.Mark, film.Estimation);
                }
                Thread.Sleep(5000);
            }
        }

        public static string GetMark(Film film)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    return "Посмотреть позже";
                case "2":
                    return "Просмотрено";
                case "3":
                    return "Хочу посмотреть";
                default: throw new Exception("Вы выбрил не то!");
            }
        }

        public static void Print(Film film, bool printAll)
        {
            var actors = new StringBuilder();
            foreach (var actor in film.Actors)
                actors.Append(actor + ", ");
            if (!printAll)
                Console.WriteLine("Оригинальное название фильма - {0}\nРусское название - {1}\n" +
                    "Режиссёр - {2}\nАктёры - {3}\nСостояние - {4}\n", film.OriginalName, film.Name, film.Director,
                                actors.ToString(), film.Mark);
            else Console.WriteLine("Оригинальное название фильма - {0}\nРусское название - {1}\n" +
                "Режиссёр - {2}\nАктёры - {3}\nСостояние - {4}\nОценка - {5}\n", film.OriginalName, film.Name, film.Director,
                                actors.ToString(), film.Mark, film.Estimation);
        }

        public static void CreateFilm(List<Film> films)
        {
            films.Add(new Film("Voice Form","Форма голоса", "Наоко Ямада", 
                new List<string> { "Мию Ирино", "Саори Хаями", "Аои Юки", "Кэнсё Оно" }));
            films.Add(new Film("Shameless", "Бесстыжие", "Марк Майлод",
                new List<string> { "Уильям Х. Мэйси", "Джереми Аллен Уайт", "Шанола Хэмптон", "Стив Хоуи" }));
            films.Add(new Film("Tokyo Ghoul", "окийский гуль", "Сюхэй Морита",
                new List<string> { "Масатака Кубота", "Фумика Симидзу", "Нобуюки Судзуки", "Хиёри Сакурада" }));
            films.Add(new Film("JoJo: Bizzare Adventure", "ДжоДжо: Невероятные приключения", "Кэнъити Судзуки",
                new List<string> { "Даисукэ Оно", "Унсё Исидзука", "Тору Окава", "Фумитомо Комацу" }));
        }
    }

    public class Film
    {
        private string originalName;
        private string name;
        private string director;
        private List<string> actors;
        private int estimation;
        private string mark;
        public Film(string originalName ,string name, string director, List<string> actors)
        {
            this.OriginalName = originalName;
            this.Name = name;
            this.Director = director;
            this.Actors = actors;
            mark = "Не оценено";
        }
        public string OriginalName
        {
            get { return originalName; }
            set { originalName = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
        public List<string> Actors
        {
            get { return actors; }
            set { actors = value; }
        }
        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public int Estimation
        {
            get
            {
                if (estimation <= 10 && estimation>=0)
                    return estimation;
                else throw new Exception("Оценка не может привышать 10!");

            }
            set { estimation = value; }
        }
    }

    public class FilmWithActor : Film
    {
        private int numberFilm;
        public FilmWithActor(string originalName, string name, string director, List<string> actors)
            : base(originalName, name, director, actors)
        {
            numberFilm = 0;
        }
        public int NumberFilm
        {
            get { return numberFilm++; }
            set { numberFilm = value; }
        }
    }
}

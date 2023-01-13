using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Non
{
    class Program
    {
        /*
         * Версия нона: 0.1-dev
         * 
         * 
         * 1 - Ошибка форматирования
         * 2 - Не найдено
         * 
         * NonException - Исключение языка Non
         * ЧИСТО ТЕСТОВАЯ ШТУКА! ТОЛЬКО ДЛЯ ТЕСТИРОВАНИЯ, наврятли будет в релизе
         * 
         */
        public struct NonException
        {
            public static string Message;
            public static string Line;
            public static string ErrorCode;

            public static void Print() { Console.WriteLine("Line::" + i + "\nMessage::" + e.Message + "\nSource::" + e.Source + "\nHelpLink::" + e.HelpLink + "\nOur Email::mineloced@gmail.com"); }

            public static void Write() { File.WriteAllText("log::" + DateTime.Now.ToString("HH:mm:ss"), "Line::" + i + "\nMessage::" + e.Message + "\nSource::" + e.Source + "\nHelpLink::" + e.HelpLink + "\nOur Email::mineloced@gmail.com"); }
        }


        public static void Main(string[] args)
        {
            /*
             * То, где поставлен комментарий, значит что я там работаю.
             * И нет, я не работаю в начале метода, этот комментарий исключение.
             * Если будете использовать код отсюда(ну например позаимствовать), то стоит мне написать (   mineloced@gmail.com / vk.com/fanatscoc174   )
             * Так как наврятли вы что-то тут поймёте, хоть и с комментами, но всё равно.
             * 
             * UPD(11.01.2023): Из-за ониме(кажд. день смотрю), у меня нету времени прогать. 
             * + из-за школы(учёбы)
             */

            Console.OutputEncoding = System.Text.Encoding.UTF8; // хз просто так
            string path = "main.non"; // Объявляем переменную path(в переводе с англ. путь) со значением "main.non" - данный файл - файл с кодом
            foreach (string s in args) // Проходимся по аргументам(если таковые есть) и...
                path = s; // Устанавливаем переменной path значение, равное аргументу(то есть предположительно файлу с кодом)
            if (File.Exists(path)) // Если указанный файл с кодом(переменная path) существует, то... Начинается ЯП
            {
                Dictionary<string, string> vars = new Dictionary<string, string> // Список переменных
                {
                    { "username", Environment.UserName }, // Переменная (не буду далее писать названия, лень) со значением *Ник пользователя Windows*
                    { "machinename", Environment.MachineName }, // Переменная со значением *Название ПК*
                    { "currentdirectory", Environment.CurrentDirectory }, // Переменная со значением *Текущяя директория*
                    { "systemdirectory", Environment.SystemDirectory }, //  Переменная со значением *Системная директория* (Как я понимаю это "C:\Windows\System32" или типа такого)
                    { "osplatform", Environment.OSVersion.Platform.ToString() }, // Переменная... Фиг знает
                    { "osservicepack", Environment.OSVersion.ServicePack }, // тож
                    { "osversion", Environment.OSVersion.VersionString }, // тож
                    { "showerrors", "true" }, // Показывать ошибки или нет(выводить на экран или нет)
                    { "writeerrors", "false" }, // Записывать ошибки или нет (Логи)
                };
                /*
                 * Изначально должно было быть несколько типов переменных:
                 * : string
                 * : decimal
                 * : double
                 * : char
                 * Но мне было лень это всё делать поэтому ага.
                 *
                 * А вот классы, функции и неймспейсы было не лень. Ага.
                 * Потом ещё аргументы для функций сделаю, ага (нет, уж это люди прогаюшие на нонке пусть сами делают(их нету, и не будет наверн)).
                 * 
                 */
                string[] l = File.ReadAllLines(path);
                Dictionary<string, int> functions = new Dictionary<string, int>
                {

                };
                Dictionary<string, int> classes = new Dictionary<string, int>
                {

                };
                Dictionary<string, int> namespaces = new Dictionary<string, int>
                {

                };
                /*
                 * ВНИМАНИЕ, после этой строчки не все части кода будут объяснены.
                 * Всё таки я не робот, и иногда лень писать объяснения
                 * Всё таки я ещё сижу на CyberForum, где бывает натыкаешься на людей с синдромом Дауна. Ну и короче нервы всё.
                 * (  ≪ ⅁℔ℐ ℬ℻℡ ℽ⅄℻ ⅖⅄℻ ℔⅂ℍ⅄℻ ℔ℐ ℽ⅂⅄℩ℐ⅄  )
                 * P.S. Зашифровано* в HueShifrator 1.0 офиц+гитхаб
                 * 
                 * ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉
                 * ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉
                 * ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉
                 * ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉
                 * ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉ ∎∉ ≠≪≭∰⅍≭∉
                 * 
                 */
                for (int i = 0; i < l.Length; i++)
                {
                    string[] splitted = l[i].Split(new string[] { " " }, StringSplitOptions.None); // разделяем строку на массив строк, {операясь на пробел}*
                    if(splitted[0] == "Namespace")
                        namespaces.Add(splitted[1], i);
                    else if (splitted[0] == "Class")
                        classes.Add(splitted[1], i);
                    else if (splitted[0] == "Function")
                        functions.Add(splitted[1], i);
                }
                for (int i = 0; i < l.Length; i++)
                {
                    try
                    {
                        string[] splitted = l[i].Split(new string[] { " " }, StringSplitOptions.None);
                        if (splitted[0] == "Variable")
                        {
                            /*
                             * Изначально команда Variable должна была похожа на Dim из Visual Basic:
                             * : <   Variable text As String Is "def.a"+$var   >
                             * 
                             * Также она предназначена для полной замены большинства моих команд из других моих ЯП(AuScript, Xana)
                             * 
                             * Example:
                             * - Variable text Is Set Mina
                             * - Variable text Is File text.txt 0
                             * - Variable text1 Is Substring %text% %startIndex% %length%
                             * - Variable text2 Is Removed %text% %startIndex% %length%
                             * 
                             * ∎∉ ≠≪≭∰⅍≭∉
                             * 
                             */
                            // Start codes
                            string name = splitted[1];
                            string action = splitted[3];
                            if (action == "Set")
                            {
                                string text = l[i].Remove(0, 9 + name.Length + 4 + action.Length + 1);
                                if (vars.ContainsKey(name))
                                    vars[name] = text;
                                else
                                    vars.Add(name, text);
                            }
                            else if (action == "File")
                            {
                                string def = l[i].Remove(0, 9 + name.Length + 4 + action.Length + 1);

                            }
                        }
                        else if (splitted[0] == "PrintText")
                        {
                            /*
                             * Я почти ничего нового не сделал,
                             * Просто скопировал код из другого языка (Key: devonly ver.)
                             * 
                             * ∎∉ ≠≪≭∰⅍≭∉
                             * 
                             */
                            string text = l[i].Remove(0, splitted[0].Length + 1);
                            for (int ii = 0; ii < text.Length; ii++)
                            {
                                if (text[ii] == '%')
                                {
                                    for (int j = ii + 1; j < text.Length; j++)
                                    {
                                        if (text[j] == '%')
                                        {
                                            int startIndex = ii;
                                            int endIndex = j;
                                            int length = endIndex - startIndex;
                                            string var = text.Substring(startIndex + 1, length - 1);
                                            text = text.Remove(startIndex, length + 1);
                                            if (vars.ContainsKey(var))
                                            {
                                                text = text.Insert(startIndex, vars[var]);
                                            }
                                            ii = j;
                                            break;
                                        }
                                    }
                                }
                            }
                            Console.Write(text);
                        }
                        else if (splitted[0] == "PrintTextLine")
                        {
                            string text = l[i].Remove(0, splitted[0].Length + 1);
                            for (int ii = 0; ii < text.Length; ii++)
                            {
                                if (text[ii] == '%')
                                {
                                    for (int j = ii + 1; j < text.Length; j++)
                                    {
                                        if (text[j] == '%')
                                        {
                                            int startIndex = ii;
                                            int endIndex = j;
                                            int length = endIndex - startIndex;
                                            string var = text.Substring(startIndex + 1, length - 1);
                                            text = text.Remove(startIndex, length + 1);
                                            if (vars.ContainsKey(var))
                                            {
                                                text = text.Insert(startIndex, vars[var]);
                                            }
                                            ii = j;
                                            break;
                                        }
                                    }
                                }
                            }
                            Console.WriteLine(text);
                        }
                        else if (splitted[0] == "PrintChar")
                        {
                            string text = l[i].Remove(0, splitted[0].Length + 1);
                            for (int ii = 0; ii < text.Length; ii++)
                            {
                                if (text[ii] == '%')
                                {
                                    for (int j = ii + 1; j < text.Length; j++)
                                    {
                                        if (text[j] == '%')
                                        {
                                            int startIndex = ii;
                                            int endIndex = j;
                                            int length = endIndex - startIndex;
                                            string var = text.Substring(startIndex + 1, length - 1);
                                            text = text.Remove(startIndex, length + 1);
                                            if (vars.ContainsKey(var))
                                            {
                                                text = text.Insert(startIndex, vars[var]);
                                            }
                                            ii = j;
                                            break;
                                        }
                                    }
                                }
                            }
                            try { char c = char.Parse(text);  Console.Write(text); }
                            catch
                            {

                            }
                        }
                        else if (splitted[0] == "Comment") { }
                        else { throw new InvalidDataException("Unkown command"); }
                    }
                    catch (Exception e)
                    {
                        if (vars["showerrors"] == "true")
                            Console.WriteLine("Line::" + i + "\nMessage::" + e.Message + "\nSource::" + e.Source + "\nHelpLink::" + e.HelpLink + "\nOur Email::mineloced@gmail.com");
                        if (vars["writeerrors"] == "true")
                            File.WriteAllText("log::" + DateTime.Now.ToString("HH:mm:ss"), "Line::" + i + "\nMessage::" + e.Message + "\nSource::" + e.Source + "\nHelpLink::" + e.HelpLink + "\nOur Email::mineloced@gmail.com");
                    }
                }
            }
        }

        /*
         * Created in Visual Studio 2017
         * InnieSharpSoftware Union/ISSU
         * InnieSharp^1
         * $even$^3
         * SharpMoon^2
         * Windows 8.1+ only!
         * 
         * ∎∉ ≠≪≭∰⅍≭∉
         * 
         */

        public static int SearchStringInArray(string text, string[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == text)
                    return i;
            return -1;
        }

        public static bool ExistsStringInArray(string text, string[] array)
        {
            if (SearchStringInArray(text, array) != -1)
                return true;
            return false;
        }
    }
}

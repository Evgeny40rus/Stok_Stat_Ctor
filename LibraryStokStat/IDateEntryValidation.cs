﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryStokStat
{
    public interface IDateEntryValidation
    {
        public string ValidatOfEnteredDataString() //Проверка введенных строковых данных Проверка на строку и символы
        {          
            string? validStr = null;
            bool isWorkName = true;
            while (isWorkName)
            {
                validStr = Console.ReadLine();
                if (validStr is null or "")
                    Console.WriteLine("Ничего не ввели.\nПовторите ввод:");
                else
                {
                    if (Regex.IsMatch(validStr, "^[а-яА-Яa-zA-Z]+$"))
                        isWorkName = false;
                    else
                        Console.WriteLine("Только буквы.\nПовторите ввод:");
                }
            }
            return validStr ?? "Нет данных";
        }
        public void SaveInJson<T>(in List<T> people,in string path)
        {
            var settings = new JsonSerializerSettings  // Задаем формат Json
            {
                Formatting = Formatting.Indented,
            };
            // Создаем строку в формате Json      
            File.WriteAllText(path, JsonConvert.SerializeObject(people, settings));  // Записываем файл Json на диск
        }
    }    
}

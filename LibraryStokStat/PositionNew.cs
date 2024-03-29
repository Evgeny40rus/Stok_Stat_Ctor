﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LibraryStokStat
{
    internal class PositionNew:IDateEntryValidation
    {            
        public static List<PositionNew> listPositionNew = new();
        private static readonly string fileNamePosition = "PositionJson.json";
        [JsonProperty("Наименование")]
        public string? NamePosition { get; private set; }  // Наименование позиции
        [JsonProperty("Срок норм выдачи")]
        public int NormTermDay { get; private  set; } // Срок норм в днях(количество дней)

        public PositionNew(string? namePosition, int normTermDay)
        {
            NamePosition = namePosition;
            NormTermDay = normTermDay;
        }
        public void PosInputNewDate()
        {
            bool isWorkPositNew = true;
            while (isWorkPositNew)
            {               
                Console.Write("Наименование: ");
                NamePosition = Console.ReadLine();
                Console.Write("Срок норм выдачи(лет): ");
                string? normTerD = Console.ReadLine();
                if (normTerD != null) NormTermDay = int.Parse(normTerD);
                PositionNew? positionNormsNew = new(NamePosition, NormTermDay);
                listPositionNew.Add(positionNormsNew);
                Console.WriteLine("Внести еще позицию?\n0 - Нет\n1 - Да");
                int? command = 0;
                try
                {
                    string? commandSrt = Console.ReadLine();                   
                    if (commandSrt != null)
                        command = int.Parse(commandSrt);
                }
                catch (Exception)
                {
                    Console.WriteLine("Нет такой команды");
                    
                }
                switch (command)
                {
                    case 0:
                        isWorkPositNew = false;
                        if (positionNormsNew is IDateEntryValidation iDateEntryValid)
                        {
                            iDateEntryValid.SaveInJson(in listPositionNew, fileNamePosition);
                        }
                        break;
                    default:
                        isWorkPositNew = true; break;
                }
            }                      
        }        
    }
}

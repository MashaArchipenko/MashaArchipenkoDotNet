using Lab1.Interfaces;
using Lab1.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lab1.BusinessLogic
{
    public static class ConsoleHelper
    {
        public static string DefineFormat(this string name)
        {
            var type = typeof(FileFormat);
            var memInfo = type.GetMember(name);
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }
        public static (IWriter,string[]) ChooseWriteFile(string[] line)
        {
            const int CommandCount = 3;
            bool checkCorrectFormatFlag = false;
            IWriter writerFormat = null;
            while (!checkCorrectFormatFlag)
            {
                if (line.Length == CommandCount)
                {
                    if (line[(int)InputData.Format].Equals(DefineFormat(FileFormat.Excel.ToString())))
                    {
                        writerFormat = new ExcelWriter();
                        checkCorrectFormatFlag = true;
                    }
                    else if (line[(int)InputData.Format].Equals(FileFormat.Json.ToString().DefineFormat()))
                    {
                        writerFormat = new JsonWriter();
                        checkCorrectFormatFlag = true;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect format:{line[(int)InputData.Format]}.Enter:");
                        line[(int)InputData.Format] = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong number of parameters enter,enter the correct paramerts:");
                    Console.WriteLine("'Input file name' 'Output file name' 'format'");
                    line = Console.ReadLine().Split();
                }
           }
            return (writerFormat,line);
        }
    }
}

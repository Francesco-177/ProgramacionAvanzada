using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using textcalculator;


string pathFile1 = @"C:\Users\Gusta\PA17BAgo-Dic2023\PracticaTextCalculator\TextFiles\TestProfe1.txt";

string pathFile2 = @"C:\Users\Gusta\PA17BAgo-Dic2023\PracticaTextCalculator\TextFiles\TestProfe2.txt";

string pathFile3 = @"C:\Users\Gusta\PA17BAgo-Dic2023\PracticaTextCalculator\TextFiles\TestProfe3.txt";

TextCalculator textCalculator = new();

textCalculator.ProcessFile(pathFile1);
textCalculator.ProcessFile(pathFile2);
textCalculator.ProcessFile(pathFile3);


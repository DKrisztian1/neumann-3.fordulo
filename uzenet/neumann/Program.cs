using System.Collections.Generic;
using System.Linq;
using System.Security;


List<string> uzenetek = new List<string>();
uzenetek = File.ReadAllLines("uzenetek.txt").ToList();


//a
int hanyszorNemErtelmezte = 0;
foreach (var uzenet in uzenetek)
{
	foreach (var kar in uzenet)
	{
		if (kar == '?')
			hanyszorNemErtelmezte++;
	}
}
Console.WriteLine(hanyszorNemErtelmezte);

//1.a Valasz: 7442



//b
List<char> indexElemei = new List<char>();
string eredeti = "";
int currentIndex = 0;

for (int i = 0; i < 100; i++)
{
    indexElemei.Clear();
    foreach (var uzenet in uzenetek)
	{      
		if (uzenet[currentIndex] != '-' && uzenet[currentIndex] != '?')
            indexElemei.Add(uzenet[currentIndex]);     
    }
    currentIndex++;
    var most = (from y in indexElemei group y by y into grp orderby grp.Count() descending select grp.Key).First();
    eredeti += most;
}

Console.WriteLine(eredeti);
//1.b Valasz 7610922751913275142233435073915524642160008422684973049146293643594970710907471138712178244571230807



//c

Dictionary<string, double> elteresesdi = new Dictionary<string, double>();
for (int i = 0; i < 10; i++)
{
	elteresesdi.Add(Convert.ToString(i), 0 );
}


foreach (string uzenet in uzenetek)
{
	for (int i = 0; i < uzenet.Length; i++)
	{
		if (uzenet[i] != eredeti[i])
		{
			elteresesdi[Convert.ToString(eredeti[i])] += 1;
		}		
    }
}

double osszeshiba =  0;
foreach (var item in elteresesdi)
{
	osszeshiba += item.Value;
}

/*
foreach (var item in elteresesdi)
{
    Console.WriteLine($"{item.Key} {Math.Round(item.Value / osszeshiba * 100, 2)}");
}
*/

//c. Valasz 1: 4 13


/*
Dictionary<string, double> osszesize = new Dictionary<string, double>();
for (int i = 0; i < 10; i++)
{
    osszesize.Add(Convert.ToString(i), 0);
}
foreach (var item in eredeti)
{
	osszesize[Convert.ToString(item)] += 500;
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{i} {Math.Round(elteresesdi.ElementAt(i).Value / osszesize.ElementAt(i).Value * 100, 2)}");
}
*/

//c. Valasz 2: 5 76,34




//d
List<int> hosszusagok = new List<int>();
List<int> sorok = new List<int> ();
List<int> kezdoPoziciok = new List<int>();
int hossz = 0;
int sor = 0;

bool eppenRossz = false;
foreach (var uzenet in uzenetek)
{
    for (int i = 0; i < uzenet.Length; i++)
	{
		if (uzenet[i] == eredeti[i])
		{
			eppenRossz = false;
			if (hossz != 0)
			{
                hosszusagok.Add(hossz);
				hossz = 0;
            }		
		}
		else if (uzenet[i] != eredeti[i] && eppenRossz == false)
		{		
			kezdoPoziciok.Add(i);
			sorok.Add(sor);
            hossz = 1;

            eppenRossz = true;
        }
		else if (uzenet[i] != eredeti[i] && eppenRossz)
		{
            hossz++;
		}

    }
	sor++;
}

int maxIndex = hosszusagok.IndexOf(hosszusagok.Max());
Console.WriteLine($"Max: {hosszusagok[maxIndex]} KezdoPozicio: {kezdoPoziciok[maxIndex]+=1} Sor: {sorok[maxIndex]+=1}");
//1.d Valasz:  Max: 31 KezdoPozicio: 60 Sor: 95
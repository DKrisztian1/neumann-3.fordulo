List<string> Szavak = new List<string>();
Szavak = File.ReadAllLines("szavak.txt").ToList();

char[] maganhangzok = new char[] { 'E', 'U', 'I', 'O', 'A' };


//a
int legalabbNegy = 0;
int maganhagzokSzama = 0;
foreach (string szo in Szavak)
{
	maganhagzokSzama = 0;
	foreach (char betu in szo)
	{
		if (maganhangzok.Contains(betu))
			maganhagzokSzama++;
	}
	if (maganhagzokSzama >= 4)
		legalabbNegy++;
}
Console.WriteLine(legalabbNegy);
//a. Valasz: 1316


//b
int hanyESAT = 0;
foreach(string szo in Szavak)
{
	if (szo.Contains('E') && szo.Contains('S') && szo.Contains('A') && szo.Contains('T'))
	{
        if (szo.IndexOf('E') < szo.IndexOf('S') && szo.IndexOf('S') < szo.IndexOf('A') && szo.IndexOf('A') < szo.IndexOf('T'))
        {
			hanyESAT++;
        }
    }
}
Console.WriteLine(hanyESAT);
//b. Valasz: 23


//c
static bool IsPrime(int number)
{
    if (number <= 1)
    {
        return false;
    }

    if (number <= 3)
    {
        return true;
    }

    if (number % 2 == 0 || number % 3 == 0)
    {
        return false;
    }

    for (int i = 5; i * i <= number; i += 6)
    {
        if (number % i == 0 || number % (i + 2) == 0)
        {
            return false;
        }
    }

    return true;
}

Dictionary<string, int> SzavakASCIIkodOsszege = new Dictionary<string, int>();
int kodOsszeg = 0;
int hanyprim = 0;
foreach (string szo in Szavak)
{
	kodOsszeg = 0;
	foreach (char kar in szo)
	{
		kodOsszeg += (byte)kar;
    }
	SzavakASCIIkodOsszege.Add(szo, kodOsszeg);
    if (IsPrime(kodOsszeg))
    {
        hanyprim++;
    }
}
Console.WriteLine(hanyprim);
//c. Valasz: 805


//d
int maxOccurenceValue = SzavakASCIIkodOsszege.GroupBy(x => x.Value).OrderByDescending(g => g.Count()).First().Key;
Console.WriteLine(maxOccurenceValue);
//d. Valasz: 600



//e
List<char> OsszesKarakter = new List<char>();
foreach (var item in SzavakASCIIkodOsszege)
{
    foreach (var szo in item.Key)
    {
        if (!OsszesKarakter.Contains(szo))
            OsszesKarakter.Add(szo);
    }
}

List<string> amikkellenek607 = new List<string>();
foreach (var item in SzavakASCIIkodOsszege)
{
    if (item.Value == 607)
    {
        amikkellenek607.Add(item.Key);
    }
}

int hanytartalmazzaAjelenlegit = 0;
List<char> megoldas = new List<char>();

for (int i = 0; i < OsszesKarakter.Count; i++)
{
    hanytartalmazzaAjelenlegit = 0;
    foreach (var szo in amikkellenek607)
    {
        if (szo.Contains(OsszesKarakter[i]))
        {
            hanytartalmazzaAjelenlegit++;
        }
    }
    if (hanytartalmazzaAjelenlegit >= 5)
    {
        megoldas.Add(OsszesKarakter[i]);
    }
}
megoldas.Sort();
foreach (var item in megoldas)
{
    Console.Write(item);
}
//e. Valasz: AEFHLMNOPT
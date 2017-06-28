using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			string registreredeBrugere = File.ReadAllText(projectDirectory + "\\Logins.txt");
			Console.WriteLine("Indtast login: ");
			string indtastetLogin = Console.ReadLine();

			if (registreredeBrugere.Contains(indtastetLogin))
			{
				while (true)
				{
					string[] registreredeBilerArray = Directory.GetFiles(projectDirectory + "\\Registrerede biler");
					string[] tidsBestillingerArray = Directory.GetFiles(projectDirectory + "\\Tidsbestillinger");
					List<string> filesList = new List<string>();
					List<string> tidsBestillingerList = new List<string>();
					foreach (string file in registreredeBilerArray)
					{
						filesList.Add(Path.GetFileNameWithoutExtension(file));
					}
					foreach (string file in tidsBestillingerArray)
					{
						tidsBestillingerList.Add(Path.GetFileNameWithoutExtension(file));
					}

					StreamWriter LogFile = File.AppendText(projectDirectory + "\\Login Log.txt");
					LogFile.WriteLine(indtastetLogin + " " + DateTime.Now);
					LogFile.Close();
					Console.Clear();
					Console.WriteLine("Menu: ");
					Console.WriteLine("[1] Opret");
					Console.WriteLine("[2] Tidsbestilling");
					Console.WriteLine("[3] Afslut programmet...");
					ConsoleKeyInfo menuValg = Console.ReadKey(true);

					if (menuValg.KeyChar == '1')
					{
						Console.Clear();
						Console.WriteLine("[1] Opret bil");
						Console.WriteLine("[2] Opret bruger");
						Console.WriteLine("[3] Tilbage...");
						menuValg = Console.ReadKey(true);
						if (menuValg.KeyChar == '1')
						{
							Console.Clear();
							Console.WriteLine("Indtast nummerpladen");
							string indtastetNummerPlade = Console.ReadLine();
							int nummerPladeMenu = filesList.Count + 1;
							StreamWriter registrerBil = File.CreateText(projectDirectory + "\\Registrerede biler\\" + indtastetNummerPlade + ".txt");
							registrerBil.WriteLine(indtastetNummerPlade);
							registrerBil.Close();
							continue;
						}
						if (menuValg.KeyChar == '2')
						{
							Console.Clear();
							Console.WriteLine("Indtast ønsket login: ");
							StreamWriter loginFile = File.AppendText(projectDirectory + "\\Logins.txt");
							loginFile.WriteLine(Console.ReadLine());
							loginFile.Close();
							continue;
						}
						if (menuValg.KeyChar == '3')
						{
							continue;
						}
					}
					if (menuValg.KeyChar == '2')
					{
						Console.Clear();
						Console.WriteLine("[1] Bestilling af tid");
						Console.WriteLine("[2] Se nuværende tidsbestillinger");
						Console.WriteLine("[3] Slet tidsbestilling");
						Console.WriteLine("[4] Tilbage...");
						menuValg = Console.ReadKey(true);
						if (menuValg.KeyChar == '1')
						{
							Console.Clear();
							Console.WriteLine("Skriv dato i format YYYY-MM-DD");
							DateTime tidsbestillingDato = Convert.ToDateTime(Console.ReadLine());
						
							Console.Clear();
							Console.WriteLine(tidsbestillingDato.ToString("yyyy-MM-dd"));
							Console.WriteLine("----------");
							Console.WriteLine("Vælg tid: ");
							Console.WriteLine("[1]07:00 - 08:00");
							Console.WriteLine("[2]08:00 - 09:00");
							Console.WriteLine("[3]09:00 - 10:00");
							Console.WriteLine("[4]10:00 - 11:00");
							Console.WriteLine("[5]11:00 - 12:00");
							Console.WriteLine("[6]12:00 - 13:00");
							Console.WriteLine("[7]13:00 - 14:00");
							Console.WriteLine("[8]14:00 - 15:00");
							ConsoleKeyInfo tidValgTast = Console.ReadKey(true);
							string tidValgt = "Placeholder";
							if (tidValgTast.KeyChar == '1')
							{
								tidValgt = "07_00-08_00";
							}
							if (tidValgTast.KeyChar == '2')
							{
								tidValgt = "08_00-09_00";
							}
							if (tidValgTast.KeyChar == '3')
							{
								tidValgt = "09_00-010_00";
							}
							if (tidValgTast.KeyChar == '4')
							{
								tidValgt = "10_00-11_00";
							}
							if (tidValgTast.KeyChar == '5')
							{
								tidValgt = "11_00-12_00";
							}
							if (tidValgTast.KeyChar == '6')
							{
								tidValgt = "12_00-13_00";
							}
							if (tidValgTast.KeyChar == '7')
							{
								tidValgt = "13_00-14_00";
							}
							if (tidValgTast.KeyChar == '8')
							{
								tidValgt = "14_00-15_00";
							}
							StreamWriter registrerTidsbestilling = File.CreateText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
							registrerTidsbestilling.Close();
							Console.Clear();
							Console.WriteLine("Vælg nummerplade: ");
							for (int i = 1; i < filesList.Count + 1; i++)
							{
								Console.WriteLine("[" + i + "]" + filesList[i - 1]);
							}
							NummerPladeFilTidsBestilling(filesList, tidsbestillingDato, tidValgt, projectDirectory);
							Console.Clear();
							Console.WriteLine("Vælg service: ");
							Console.WriteLine("[1]Olieskift");
							Console.WriteLine("[2]Dækskift");
							Console.WriteLine("[3]Vintertjek");
							Console.WriteLine("[4]Klargøring til syn");
							Console.WriteLine("[5]Bilsyn");
							Console.WriteLine("[6]Ferietjek");
							Console.WriteLine("[7]Bremsetjek");
							Console.WriteLine("[8]Rusttjek");
							TilføjService(tidsbestillingDato, tidValgt, projectDirectory);
						}
						if (menuValg.KeyChar == '2')
						{
							Console.Clear();
						
							Console.WriteLine("Vælg tidsbestilling: ");
							for (int i = 1; i < tidsBestillingerList.Count + 1; i++)
							{
								Console.WriteLine("[" + i + "]" + tidsBestillingerList[i - 1]);
							}
							menuValg = Console.ReadKey(true); 
							int nummerValgt = 0;
							if (menuValg.KeyChar == '1')
							{
								nummerValgt = 0;
							}
							if (menuValg.KeyChar == '2')
							{
								nummerValgt = 1;
							}
							if (menuValg.KeyChar == '3')
							{
								nummerValgt = 2;
							}
							if (menuValg.KeyChar == '4')
							{
								nummerValgt = 3;
							}
							if (menuValg.KeyChar == '5')
							{
								nummerValgt = 4;
							}
							if (menuValg.KeyChar == '6')
							{
								nummerValgt = 5;
							}
							if (menuValg.KeyChar == '7')
							{
								nummerValgt = 6;
							}
							if (menuValg.KeyChar == '8')
							{
								nummerValgt = 7;
							}
							if (menuValg.KeyChar == '9')
							{
								nummerValgt = 8;
							}
							string readText = File.ReadAllText(tidsBestillingerArray[nummerValgt]);
							Console.WriteLine(readText);
							Console.WriteLine("Tryk på en tast for at fortsætte...");
							Console.ReadKey();
							continue;
						}
						if (menuValg.KeyChar == '3')
						{
							Console.WriteLine("Vælg tidsbestilling der skal slettes: ");
							for (int i = 1; i < tidsBestillingerList.Count + 1; i++)
							{
								Console.WriteLine("[" + i + "]" + tidsBestillingerList[i - 1]);
							}
							menuValg = Console.ReadKey(true); 
							int nummerValgt = 0;
							if (menuValg.KeyChar == '1')
							{
								nummerValgt = 0;
							}
							if (menuValg.KeyChar == '2')
							{
								nummerValgt = 1;
							}
							if (menuValg.KeyChar == '3')
							{
								nummerValgt = 2;
							}
							if (menuValg.KeyChar == '4')
							{
								nummerValgt = 3;
							}
							if (menuValg.KeyChar == '5')
							{
								nummerValgt = 4;
							}
							if (menuValg.KeyChar == '6')
							{
								nummerValgt = 5;
							}
							if (menuValg.KeyChar == '7')
							{
								nummerValgt = 6;
							}
							if (menuValg.KeyChar == '8')
							{
								nummerValgt = 7;
							}
							if (menuValg.KeyChar == '9')
							{
								nummerValgt = 8;
							}
							File.Delete(tidsBestillingerArray[nummerValgt]);
							continue;
						}
							if (menuValg.KeyChar == '4')
						{
							continue;
						}
					}
					if (menuValg.KeyChar == '3')
					{
						break;
					}
				}
			}
			
		}
		static void DirSearch(string dir)
		{
			try
			{
				foreach (string f in Directory.GetFiles(dir))
					Console.WriteLine(f);
				foreach (string d in Directory.GetDirectories(dir))
				{
					Console.WriteLine(d);
					DirSearch(d);
				}

			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		static void NummerPladeFilTidsBestilling(List<string>filesList, DateTime tidsbestillingDato, string tidValgt, string projectDirectory)
		{
            ConsoleKeyInfo nummerPladeValgt = Console.ReadKey(true);
			if (nummerPladeValgt.KeyChar == '1')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[0]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '2')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[1]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '3')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[2]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '4')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[3]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '5')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[4]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '6')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[5]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '7')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[6]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '8')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[7]);
				nummerPladeTidsBestilling.Close();
			}
			if (nummerPladeValgt.KeyChar == '9')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Nummerplade:	" + filesList[8]);
				nummerPladeTidsBestilling.Close();
			}
		}
		static void TilføjService(DateTime tidsbestillingDato, string tidValgt, string projectDirectory)
		{
            ConsoleKeyInfo serviceValgt = Console.ReadKey(true);
			if (serviceValgt.KeyChar == '1')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Olieskift");
				nummerPladeTidsBestilling.Close();
			}
			if (serviceValgt.KeyChar == '2')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Dækskift");
				nummerPladeTidsBestilling.Close();
			}
			if (serviceValgt.KeyChar == '3')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Vintertjek");
				nummerPladeTidsBestilling.Close();
			}
			if (serviceValgt.KeyChar == '4')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Klargøring til syn");
				nummerPladeTidsBestilling.Close();
			}
			if (serviceValgt.KeyChar == '5')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Bilsyn");
				nummerPladeTidsBestilling.Close();
			}
			if (serviceValgt.KeyChar == '6')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Ferietjek");
				nummerPladeTidsBestilling.Close();
			}
			if (serviceValgt.KeyChar == '7')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Bremsetjek");
				nummerPladeTidsBestilling.Close();
			}
			if (serviceValgt.KeyChar == '8')
			{
				StreamWriter nummerPladeTidsBestilling = File.AppendText(projectDirectory + "\\Tidsbestillinger\\" + tidsbestillingDato.ToString("yyyy-MM-dd") + "   " + tidValgt + ".txt");
				nummerPladeTidsBestilling.WriteLine("Service:	Rusttjek");
				nummerPladeTidsBestilling.Close();
			}
		}
	}
}

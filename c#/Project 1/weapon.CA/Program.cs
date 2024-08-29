using System;
using System.Diagnostics.CodeAnalysis;
using weapon.Buisness.Implementions;
using weapon.Core.Enum;
using weapon.Core.Models;
using weapon.Data.DAL;
using WMPLib;

namespace weapon.CA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit != true)
            {
                Console.WriteLine("1.Create new Weapon");
                Console.WriteLine("2.Choose a Weapon");
                Console.WriteLine("3.Exit");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                char key = consoleKeyInfo.KeyChar;
                Console.WriteLine();
                if (key == '1')
                {
                    Console.Write("Enter weapon name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter weapon bulletcapacity : ");
                    int bc = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Weapon weapon = new Weapon()
                    {
                        Name = name,
                        BulletCapacity = bc,
                        BulletNumber = bc,
                        fireMod = FireMOd.Single
                    };
                    Console.Write("Select firemod => 1.Multi 2.Single : ");
                    ConsoleKeyInfo consoleKeyInfo2 = Console.ReadKey();
                    char key2 = consoleKeyInfo2.KeyChar;
                    Console.WriteLine();
                    if(key2 == '1')
                    {
                        weapon.fireMod = FireMOd.Multi;
                    }
                    else
                    {
                        weapon.fireMod = FireMOd.Single;
                    }

                    WeaponService weaponService = new WeaponService();
                    Console.WriteLine();
                    weaponService.Create(weapon);
                    Console.WriteLine();
                    weaponService.Information(weapon);
                    Console.WriteLine();
                }
                else if(key == '2')
                {
                    WeaponService weaponService = new WeaponService();
                    Weapon? weapon = null;
                    Console.Write("Please enter your weapon id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    foreach (var item in WeaponDAL<Weapon>.Weapons)
                    {
                        if(id == item.Id)
                        {
                            weapon = item;
                            Console.WriteLine($"Weapon was found. {weapon.Name} is ready for use");
                            break;
                        }
                    }
                    if (weapon != null)
                    {
                        bool extcmd = false;
                        while (extcmd != true)
                        {
                            Console.WriteLine("1.Shoot");
                            Console.WriteLine("2.Information");
                            Console.WriteLine("3.Fire");
                            Console.WriteLine("4.GetRemainBulletCount");
                            Console.WriteLine("5.Reload");
                            Console.WriteLine("6.ChangeFireMod");
                            Console.WriteLine("7.Edit");
                            Console.WriteLine("8.Exit");
                            Console.WriteLine();

                            ConsoleKeyInfo consoleKeyInfo2 = Console.ReadKey();
                            char key2 = consoleKeyInfo2.KeyChar;
                            Console.WriteLine();

                            if (key2 == '1')
                            {
                                if (weapon.fireMod == FireMOd.Single)
                                {
                                    weaponService.Shoot(weapon);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Weapon firemod is not single.Please change firemod");
                                    Console.WriteLine();                                     
                                }
                            }
                            
                            else if(key2 == '2')
                            {
                                weaponService.Information(weapon);
                                Console.WriteLine();
                            }

                            else if(key2 == '3')
                            {
                                if (weapon.fireMod == FireMOd.Multi)
                                {
                                    weaponService.Fire(weapon);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Weapon firemod is not multi.Please change firemod");
                                    Console.WriteLine();
                                }
                            }

                            else if(key2 == '4')
                            {
                                int b = weaponService.GetRemainBulletCount(weapon);
                                Console.WriteLine(b);
                                Console.WriteLine();
                            }

                            else if(key2 == '5')
                            {
                                weaponService.Reload(weapon);
                                Console.WriteLine($"Weapon's bulletnumber is {weapon.BulletNumber} ");
                                Console.WriteLine();
                            }

                            else if(key2 == '6')
                            {
                                weaponService.ChangeFireMod(weapon);
                                Console.WriteLine();
                                Console.WriteLine();
                            }

                            else if(key2 == '7')
                            {
                                Console.Write("Enter weapon new bulletcapacity : ");
                                int NewCapacity = Convert.ToInt32(Console.ReadLine());
                                weaponService.Edit(weapon, NewCapacity);
                                Console.WriteLine();
                            }

                            else if(key2 == '8')
                            {
                                extcmd = true;
                                Console.WriteLine();
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Program stopped");
                    exit = true;
                }
            }
        }
    }
}

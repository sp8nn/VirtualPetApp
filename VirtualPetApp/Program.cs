using System;
using System.IO;
using System.Text.Json;
using VirtualPetApp;

class Program
{
    static string saveFile = "pet_save.json";

    static void Main()
    {
        VirtualPet pet = LoadPet();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== Virtual Pet ===");
            Console.WriteLine();
            Console.WriteLine(pet.GetImage());
            Console.WriteLine();
            Console.WriteLine($"Name: {pet.Name}");
            Console.WriteLine($"Mood: {pet.Mood}");
            Console.WriteLine($"Growth Stage: {pet.GrowthStage}");
            Console.WriteLine($"Age: {pet.Age}");
            Console.WriteLine($"Hunger: {pet.Hunger}/100");
            Console.WriteLine($"Happiness: {pet.Happiness}/100");
            Console.WriteLine();

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Feed pet");
            Console.WriteLine("2. Play with pet");
            Console.WriteLine("3. Let pet rest");
            Console.WriteLine("4. Pass time");
            Console.WriteLine("5. Save and exit");
            Console.WriteLine();

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                pet.Feed();
            }
            else if (choice == "2")
            {
                pet.Play();
            }
            else if (choice == "3")
            {
                pet.Rest();
            }
            else if (choice == "4")
            {
                pet.PassTime();
            }
            else if (choice == "5")
            {
                SavePet(pet);
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
            }
        }
    }

    static VirtualPet LoadPet()
    {
        if (File.Exists(saveFile))
        {
            string json = File.ReadAllText(saveFile);
            VirtualPet savedPet = JsonSerializer.Deserialize<VirtualPet>(json);

            if (savedPet != null)
            {
                savedPet.LastUpdated = DateTime.Now;
                return savedPet;
            }
        }

        Console.Write("Name your pet: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
            name = "Buddy";

        return new VirtualPet(name);
    }

    static void SavePet(VirtualPet pet)
    {
        string json = JsonSerializer.Serialize(pet, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(saveFile, json);
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WildlifeRecordsSystem.DataLayer
{
    internal class FileHandler
    {
        public FileHandler()
        {
        }
        public string filePath = Path.Combine(Application.StartupPath, "animals.txt");

        public void AddAnimalMethod(string id, string name, string species, string age, string score, string status, string housingunit)
        {
            //Storing new line to animals.txt file
            string newRecord = $"{id}|{name}|{species}|{age}|{score}|{status}|{housingunit}";
            File.AppendAllText(filePath, newRecord + Environment.NewLine, Encoding.UTF8);
        }
        public void UpdateAnimalMethod(string id, string name, string species, string age, string score, string status, string housingunit)
        {
            string newAnimalline = $"{id}|{name}|{species}|{age}|{score}|{status}|{housingunit}";
            string[] animal = File.ReadAllLines(filePath, Encoding.UTF8);  //read all lines

            //Checks where the ID's match in the text file and the new changed animal values
            for (int i = 0; i < animal.Length; i++)
            {
                string[] part = animal[i].Split('|');

                if (string.Equals(part[0].Trim(), id, StringComparison.OrdinalIgnoreCase))
                {
                    animal[i] = newAnimalline;
                    break;
                }
            }
            File.WriteAllLines(filePath, animal, Encoding.UTF8);
        }
        public void DeleteAnimalMethod(string animalIdToDelete)
        {
            // Remove the record from animals.txt
            string filePath = Path.Combine(Application.StartupPath, "animals.txt");
            var lines = File.ReadAllLines(filePath, Encoding.UTF8).Where(line => !line.StartsWith(animalIdToDelete + "|", StringComparison.OrdinalIgnoreCase)).ToArray();
            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }
    }
}

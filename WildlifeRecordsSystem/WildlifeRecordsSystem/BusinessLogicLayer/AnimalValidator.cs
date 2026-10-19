
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WildlifeRecordsSystem.BusinessLogicLayer
{
    internal class AnimalValidator
    {
        // Extended method for Add, Update and View.
        // Returns the normalized ID and supports excluding the current animal when checking uniqueness during Update.
        public bool TryValidateAnimal(
            string animalId,
            string name,
            string species,
            string ageText,
            string recoveryScoreText,
            IEnumerable<string> existingIds,
            out string normalizedAnimalId,
            out string errorMessage)
        {
            normalizedAnimalId = string.Empty;
            errorMessage = string.Empty;

            // Animal ID: trim and uppercase.
            string id = (animalId ?? string.Empty).Trim().ToUpperInvariant();

            normalizedAnimalId = id;

            // ID must be WR- followed by exactly four digits.
            if (!Regex.IsMatch(id, @"^WR-\d{4}$"))
            {
                errorMessage = "Animal ID must be WR- followed by exactly four digits.";
                return false;
            }

            // ID must be unique, except for the current record on Update.
            if (existingIds != null && existingIds.Any(existingId =>
            {
                string existing = (existingId ?? string.Empty).Trim();
                return string.Equals(existing, id, StringComparison.OrdinalIgnoreCase);
            }))
            {
                errorMessage = "Animal ID already exists.";
                return false;
            }

            if (!TryValidateAnimalUpdate(name, species, ageText, recoveryScoreText, out errorMessage))
            {
                return false;
            }
            return true;
        }



        // To validate Update values

        public bool TryValidateAnimalUpdate(
            string name,
            string species,
            string ageText,
            string recoveryScoreText,
            out string errorMessage)
        {
            errorMessage = string.Empty;


            // Name: required, 1–30 characters, no pipe.
            string cleanName = (name ?? string.Empty).Trim();

            if (cleanName.Length < 1 ||
                cleanName.Length > 30 ||
                cleanName.Contains("|"))
            {
                errorMessage = "Name must be 1–30 characters and cannot contain |.";
                return false;
            }

            // Species: required, 1–30 characters, no pipe.
            string cleanSpecies = (species ?? string.Empty).Trim();

            if (cleanSpecies.Length < 1 ||
                cleanSpecies.Length > 30 ||
                cleanSpecies.Contains("|"))
            {
                errorMessage = "Species must be 1–30 characters and cannot contain |.";
                return false;
            }

            // Age: whole number from 0 to 100.
            if (!int.TryParse(
                    (ageText ?? string.Empty).Trim(),
                    out int age) ||
                age < 0 || age > 100)
            {
                errorMessage = "Age must be a whole number from 0 to 100.";
                return false;
            }

            // Recovery Score: whole number from 0 to 100.
            if (!int.TryParse((recoveryScoreText ?? string.Empty).Trim(), out int score) || score < 0 || score > 100)
            {
                errorMessage = "Recovery Score must be a whole number from 0 to 100.";
                return false;
            }

            return true;
        }

    }
}

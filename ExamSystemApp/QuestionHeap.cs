/*using System.Collections.Generic;
using System.Linq;

namespace ExamSystemApp
{
    public static class QuestionHeap
    {
        public static List<ExamQuestion> Questions = new List<ExamQuestion>
            {
                // ===================== MATH =====================
                // Easy - American
                new ExamQuestion("What is 2 + 2?", new[] { "3", "4", "5", "6" }, 1, "Easy", "Math"),
                new ExamQuestion("What is 10 / 2?", new[] { "3", "4", "5", "6" }, 2, "Easy", "Math"),
                new ExamQuestion("Which of these is even?", new[] { "3", "5", "6", "9" }, 2, "Easy", "Math"),
                new ExamQuestion("What is 3 * 3?", new[] { "6", "7", "8", "9" }, 3, "Easy", "Math"),
                new ExamQuestion("Which is greater?", new[] { "5", "3", "2", "1" }, 0, "Easy", "Math"),

                // Easy - True/False
                new ExamQuestion("2 + 2 = 4", new[] { "T", "F", "", "" }, 0, "Easy", "Math"),
                new ExamQuestion("5 is greater than 10", new[] { "T", "F", "", "" }, 1, "Easy", "Math"),
                new ExamQuestion("Zero is an even number", new[] { "T", "F", "", "" }, 0, "Easy", "Math"),
                new ExamQuestion("7 is a prime number", new[] { "T", "F", "", "" }, 0, "Easy", "Math"),
                new ExamQuestion("10 is less than 5", new[] { "T", "F", "", "" }, 1, "Easy", "Math"),

                // Easy - Sentence Completion
                new ExamQuestion("The sum of 2 and 3 is _____", new[] { "5", "6", "3", "4" }, 0, "Easy", "Math"),
                new ExamQuestion("The result of 4 - 1 is _____", new[] { "2", "3", "4", "5" }, 1, "Easy", "Math"),
                new ExamQuestion("100 is _____ than 50", new[] { "less", "equal", "greater", "none" }, 2, "Easy", "Math"),
                new ExamQuestion("10 multiplied by 0 is _____", new[] { "0", "10", "1", "100" }, 0, "Easy", "Math"),
                new ExamQuestion("The square root of 9 is _____", new[] { "2", "3", "4", "5" }, 1, "Easy", "Math"),

                // Medium - American
                new ExamQuestion("What is 12 * 3?", new[] { "36", "34", "38", "32" }, 0, "Medium", "Math"),
                new ExamQuestion("What is 100 / 4?", new[] { "20", "25", "30", "35" }, 1, "Medium", "Math"),
                new ExamQuestion("What is the square of 8?", new[] { "64", "48", "36", "72" }, 0, "Medium", "Math"),
                new ExamQuestion("Which of these is divisible by 3?", new[] { "10", "11", "12", "13" }, 2, "Medium", "Math"),
                new ExamQuestion("What is 15 - 7?", new[] { "6", "8", "10", "12" }, 1, "Medium", "Math"),

                // Medium - True/False
                new ExamQuestion("20 is divisible by 4", new[] { "T", "F", "", "" }, 0, "Medium", "Math"),
                new ExamQuestion("9 * 9 = 81", new[] { "T", "F", "", "" }, 0, "Medium", "Math"),
                new ExamQuestion("8 is greater than 16", new[] { "T", "F", "", "" }, 1, "Medium", "Math"),
                new ExamQuestion("Square root of 25 is 6", new[] { "T", "F", "", "" }, 1, "Medium", "Math"),
                new ExamQuestion("45 is odd", new[] { "T", "F", "", "" }, 0, "Medium", "Math"),

                // Medium - Sentence Completion
                new ExamQuestion("The square root of 16 is _____", new[] { "3", "4", "5", "6" }, 1, "Medium", "Math"),
                new ExamQuestion("Half of 50 is _____", new[] { "10", "20", "25", "30" }, 2, "Medium", "Math"),
                new ExamQuestion("The product of 6 and 7 is _____", new[] { "40", "42", "48", "36" }, 1, "Medium", "Math"),
                new ExamQuestion("100 minus 37 equals _____", new[] { "63", "67", "73", "57" }, 0, "Medium", "Math"),
                new ExamQuestion("The value of pi is approximately _____", new[] { "2.14", "3.14", "4.14", "5.14" }, 1, "Medium", "Math"),

                // Hard - American
                new ExamQuestion("What is the derivative of x^2?", new[] { "2x", "x", "x^2", "1" }, 0, "Hard", "Math"),
                new ExamQuestion("What is the integral of 1/x?", new[] { "ln|x|", "x", "1", "x^2" }, 0, "Hard", "Math"),
                new ExamQuestion("Solve: 2x + 3 = 7", new[] { "1", "2", "3", "4" }, 1, "Hard", "Math"),
                new ExamQuestion("Which is irrational?", new[] { "4", "16", "9", "pi" }, 3, "Hard", "Math"),
                new ExamQuestion("What is 2^5?", new[] { "16", "32", "64", "128" }, 1, "Hard", "Math"),

                // Hard - True/False
                new ExamQuestion("The derivative of a constant is 0", new[] { "T", "F", "", "" }, 0, "Hard", "Math"),
                new ExamQuestion("ln(e) = 1", new[] { "T", "F", "", "" }, 0, "Hard", "Math"),
                new ExamQuestion("pi is a rational number", new[] { "T", "F", "", "" }, 1, "Hard", "Math"),
                new ExamQuestion("0! = 1", new[] { "T", "F", "", "" }, 0, "Hard", "Math"),
                new ExamQuestion("1 is a prime number", new[] { "T", "F", "", "" }, 1, "Hard", "Math"),

                // Hard - Sentence Completion
                new ExamQuestion("The integral of 0 is _____", new[] { "0", "1", "x", "infinity" }, 2, "Hard", "Math"),
                new ExamQuestion("The square root of 121 is _____", new[] { "10", "11", "12", "13" }, 1, "Hard", "Math"),
                new ExamQuestion("2^3 equals _____", new[] { "6", "8", "10", "12" }, 1, "Hard", "Math"),
                new ExamQuestion("The limit of x→0 of sin(x)/x is _____", new[] { "0", "1", "infinity", "undefined" }, 1, "Hard", "Math"),
                new ExamQuestion("e is approximately _____", new[] { "2.71", "3.14", "1.61", "1.41" }, 0, "Hard", "Math"),


                // ===================== PHYSICS =====================
                // Easy - American
                new ExamQuestion("What force pulls objects to Earth?", new[] { "Friction", "Magnetism", "Gravity", "Air" }, 2, "Easy", "Physics"),
                new ExamQuestion("Which is a unit of force?", new[] { "Watt", "Newton", "Joule", "Pascal" }, 1, "Easy", "Physics"),
                new ExamQuestion("What is used to measure temperature?", new[] { "Thermometer", "Ruler", "Scale", "Barometer" }, 0, "Easy", "Physics"),
                new ExamQuestion("Water freezes at what temperature (°C)?", new[] { "0", "32", "100", "212" }, 0, "Easy", "Physics"),
                new ExamQuestion("Which travels faster?", new[] { "Sound", "Light", "Wind", "Car" }, 1, "Easy", "Physics"),

                // Easy - True/False
                new ExamQuestion("Gravity pulls things down", new[] { "T", "F", "", "" }, 0, "Easy", "Physics"),
                new ExamQuestion("Sound travels faster than light", new[] { "T", "F", "", "" }, 1, "Easy", "Physics"),
                new ExamQuestion("Water boils at 100°C", new[] { "T", "F", "", "" }, 0, "Easy", "Physics"),
                new ExamQuestion("Weight and mass are the same", new[] { "T", "F", "", "" }, 1, "Easy", "Physics"),
                new ExamQuestion("Air has no mass", new[] { "T", "F", "", "" }, 1, "Easy", "Physics"),

                // Easy - Sentence Completion
                new ExamQuestion("The unit of force is _____", new[] { "Joule", "Watt", "Newton", "Meter" }, 2, "Easy", "Physics"),
                new ExamQuestion("Objects fall due to _____", new[] { "gravity", "light", "sound", "heat" }, 0, "Easy", "Physics"),
                new ExamQuestion("Water boils at _____ degrees Celsius", new[] { "50", "75", "90", "100" }, 3, "Easy", "Physics"),
                new ExamQuestion("The sun gives us _____ energy", new[] { "sound", "thermal", "light", "chemical" }, 2, "Easy", "Physics"),
                new ExamQuestion("Electricity flows through a _____", new[] { "pipe", "conductor", "rope", "plastic" }, 1, "Easy", "Physics"),

                // Medium - American
                new ExamQuestion("What is the speed of light?", new[] { "300,000 m/s", "3x10^8 m/s", "150,000 m/s", "30,000 m/s" }, 1, "Medium", "Physics"),
                new ExamQuestion("What is the SI unit of energy?", new[] { "Joule", "Newton", "Watt", "Ampere" }, 0, "Medium", "Physics"),
                new ExamQuestion("Acceleration due to gravity on Earth?", new[] { "10 m/s²", "9.8 m/s²", "8.9 m/s²", "7.5 m/s²" }, 1, "Medium", "Physics"),
                new ExamQuestion("What is Ohm's law?", new[] { "V = IR", "F = ma", "E = mc²", "P = VI" }, 0, "Medium", "Physics"),
                new ExamQuestion("Which is not a vector?", new[] { "Velocity", "Force", "Displacement", "Speed" }, 3, "Medium", "Physics"),

                // Medium - True/False
                new ExamQuestion("Speed is a scalar quantity", new[] { "T", "F", "", "" }, 0, "Medium", "Physics"),
                new ExamQuestion("Acceleration and velocity are vectors", new[] { "T", "F", "", "" }, 0, "Medium", "Physics"),
                new ExamQuestion("Electricity can flow through rubber", new[] { "T", "F", "", "" }, 1, "Medium", "Physics"),
                new ExamQuestion("Work is measured in joules", new[] { "T", "F", "", "" }, 0, "Medium", "Physics"),
                new ExamQuestion("Voltage and resistance are unrelated", new[] { "T", "F", "", "" }, 1, "Medium", "Physics"),

                // Medium - Sentence Completion
                new ExamQuestion("Work = Force × _____", new[] { "velocity", "acceleration", "distance", "mass" }, 2, "Medium", "Physics"),
                new ExamQuestion("The SI unit of power is _____", new[] { "joule", "watt", "newton", "volt" }, 1, "Medium", "Physics"),
                new ExamQuestion("The resistance unit is _____", new[] { "watt", "ohm", "volt", "joule" }, 1, "Medium", "Physics"),
                new ExamQuestion("Light travels at _____ m/s in vacuum", new[] { "3x10^8", "1x10^6", "2x10^5", "9.8" }, 0, "Medium", "Physics"),
                new ExamQuestion("The force formula is F = _____", new[] { "mv", "ma", "mg", "ml" }, 1, "Medium", "Physics"),

                // Hard - American
                new ExamQuestion("E = mc² is from which theory?", new[] { "Relativity", "Quantum", "Thermo", "Optics" }, 0, "Hard", "Physics"),
                new ExamQuestion("What is Planck's constant?", new[] { "6.63e-34", "3.00e8", "1.60e-19", "9.81" }, 0, "Hard", "Physics"),
                new ExamQuestion("Photon has which mass?", new[] { "1g", "0", "9.1e-31kg", "1kg" }, 1, "Hard", "Physics"),
                new ExamQuestion("Unit of magnetic field?", new[] { "Tesla", "Joule", "Watt", "Volt" }, 0, "Hard", "Physics"),
                new ExamQuestion("Which is a lepton?", new[] { "Proton", "Neutron", "Electron", "Quark" }, 2, "Hard", "Physics"),

                // Hard - True/False
                new ExamQuestion("Massless particles exist", new[] { "T", "F", "", "" }, 0, "Hard", "Physics"),
                new ExamQuestion("Light behaves like particle & wave", new[] { "T", "F", "", "" }, 0, "Hard", "Physics"),
                new ExamQuestion("All EM waves need medium", new[] { "T", "F", "", "" }, 1, "Hard", "Physics"),
                new ExamQuestion("Entropy always increases", new[] { "T", "F", "", "" }, 0, "Hard", "Physics"),
                new ExamQuestion("Quarks are found in leptons", new[] { "T", "F", "", "" }, 1, "Hard", "Physics"),

                // Hard - Sentence Completion
                new ExamQuestion("The SI unit of charge is _____", new[] { "ohm", "volt", "ampere", "coulomb" }, 3, "Hard", "Physics"),
                new ExamQuestion("The smallest particle is the _____", new[] { "atom", "molecule", "quark", "nucleus" }, 2, "Hard", "Physics"),
                new ExamQuestion("The magnetic field unit is _____", new[] { "volt", "tesla", "joule", "watt" }, 1, "Hard", "Physics"),
                new ExamQuestion("Planck’s constant is _____", new[] { "6.63e-34", "1.6e-19", "9.8", "3.14" }, 0, "Hard", "Physics"),
                new ExamQuestion("Light speed in vacuum is _____", new[] { "3e8", "1e6", "9.8", "1e9" }, 0, "Hard", "Physics"),


                 // ===================== BIOLOGY =====================
                // Easy - American
                new ExamQuestion("What organ pumps blood?", new[] { "Liver", "Lung", "Heart", "Stomach" }, 2, "Easy", "Biology"),
                new ExamQuestion("Which is a mammal?", new[] { "Shark", "Frog", "Whale", "Lizard" }, 2, "Easy", "Biology"),
                new ExamQuestion("What do plants absorb?", new[] { "Oxygen", "Carbon Dioxide", "Nitrogen", "Hydrogen" }, 1, "Easy", "Biology"),
                new ExamQuestion("Humans have how many lungs?", new[] { "1", "2", "3", "4" }, 1, "Easy", "Biology"),
                new ExamQuestion("Which part controls thinking?", new[] { "Heart", "Liver", "Brain", "Spine" }, 2, "Easy", "Biology"),

                // Easy - True/False
                new ExamQuestion("Plants use sunlight for food", new[] { "T", "F", "", "" }, 0, "Easy", "Biology"),
                new ExamQuestion("The brain controls movement", new[] { "T", "F", "", "" }, 0, "Easy", "Biology"),
                new ExamQuestion("All living things breathe oxygen", new[] { "T", "F", "", "" }, 1, "Easy", "Biology"),
                new ExamQuestion("Bones are part of the circulatory system", new[] { "T", "F", "", "" }, 1, "Easy", "Biology"),
                new ExamQuestion("Cells are the basic unit of life", new[] { "T", "F", "", "" }, 0, "Easy", "Biology"),

                // Easy - Sentence Completion
                new ExamQuestion("The brain is in the _____", new[] { "leg", "chest", "head", "arm" }, 2, "Easy", "Biology"),
                new ExamQuestion("The organ that pumps blood is the _____", new[] { "brain", "heart", "liver", "lung" }, 1, "Easy", "Biology"),
                new ExamQuestion("Plants make food using _____", new[] { "air", "sunlight", "moonlight", "water" }, 1, "Easy", "Biology"),
                new ExamQuestion("The lungs help us _____", new[] { "see", "breathe", "hear", "eat" }, 1, "Easy", "Biology"),
                new ExamQuestion("The skeleton supports the _____", new[] { "skin", "body", "hair", "brain" }, 1, "Easy", "Biology"),

                // Medium - American
                new ExamQuestion("Which blood cells fight infection?", new[] { "Red", "White", "Platelets", "Plasma" }, 1, "Medium", "Biology"),
                new ExamQuestion("What part of the cell contains DNA?", new[] { "Nucleus", "Cytoplasm", "Membrane", "Ribosome" }, 0, "Medium", "Biology"),
                new ExamQuestion("What is the powerhouse of the cell?", new[] { "Ribosome", "Mitochondria", "Nucleus", "Vacuole" }, 1, "Medium", "Biology"),
                new ExamQuestion("Which is a vertebrate?", new[] { "Worm", "Snail", "Fish", "Jellyfish" }, 2, "Medium", "Biology"),
                new ExamQuestion("What is the main function of roots?", new[] { "Photosynthesis", "Support", "Reproduction", "Absorption" }, 3, "Medium", "Biology"),

                // Medium - True/False
                new ExamQuestion("Mitochondria provide energy to cells", new[] { "T", "F", "", "" }, 0, "Medium", "Biology"),
                new ExamQuestion("All bacteria are harmful", new[] { "T", "F", "", "" }, 1, "Medium", "Biology"),
                new ExamQuestion("DNA is found in the nucleus", new[] { "T", "F", "", "" }, 0, "Medium", "Biology"),
                new ExamQuestion("Fish are invertebrates", new[] { "T", "F", "", "" }, 1, "Medium", "Biology"),
                new ExamQuestion("Photosynthesis occurs in leaves", new[] { "T", "F", "", "" }, 0, "Medium", "Biology"),

                // Medium - Sentence Completion
                new ExamQuestion("The cell nucleus contains _____", new[] { "energy", "chlorophyll", "DNA", "membrane" }, 2, "Medium", "Biology"),
                new ExamQuestion("White blood cells help _____", new[] { "breathe", "digest", "reproduce", "fight infection" }, 3, "Medium", "Biology"),
                new ExamQuestion("Mitochondria are the _____ of the cell", new[] { "skin", "powerhouse", "brain", "blood" }, 1, "Medium", "Biology"),
                new ExamQuestion("The basic unit of life is the _____", new[] { "organ", "tissue", "cell", "system" }, 2, "Medium", "Biology"),
                new ExamQuestion("Photosynthesis occurs in _____", new[] { "roots", "leaves", "flowers", "seeds" }, 1, "Medium", "Biology"),

                // Hard - American
                new ExamQuestion("Which organ filters blood?", new[] { "Liver", "Kidney", "Heart", "Lung" }, 1, "Hard", "Biology"),
                new ExamQuestion("What is the smallest unit of life?", new[] { "Organ", "Tissue", "Cell", "System" }, 2, "Hard", "Biology"),
                new ExamQuestion("What carries oxygen in blood?", new[] { "Platelets", "Red cells", "White cells", "Plasma" }, 1, "Hard", "Biology"),
                new ExamQuestion("What stores genetic information?", new[] { "RNA", "Protein", "DNA", "Lipid" }, 2, "Hard", "Biology"),
                new ExamQuestion("Which process makes identical cells?", new[] { "Meiosis", "Fertilization", "Mitosis", "Mutation" }, 2, "Hard", "Biology"),

                // Hard - True/False
                new ExamQuestion("DNA stands for Deoxyribonucleic Acid", new[] { "T", "F", "", "" }, 0, "Hard", "Biology"),
                new ExamQuestion("Mitosis creates identical cells", new[] { "T", "F", "", "" }, 0, "Hard", "Biology"),
                new ExamQuestion("Red blood cells fight infection", new[] { "T", "F", "", "" }, 1, "Hard", "Biology"),
                new ExamQuestion("The liver pumps blood", new[] { "T", "F", "", "" }, 1, "Hard", "Biology"),
                new ExamQuestion("Genes are made of DNA", new[] { "T", "F", "", "" }, 0, "Hard", "Biology"),

                // Hard - Sentence Completion
                new ExamQuestion("The _____ filters blood in the body", new[] { "heart", "lung", "kidney", "liver" }, 2, "Hard", "Biology"),
                new ExamQuestion("DNA is stored in the _____", new[] { "cell wall", "nucleus", "ribosome", "membrane" }, 1, "Hard", "Biology"),
                new ExamQuestion("The process of cell division is called _____", new[] { "fusion", "mitosis", "mutation", "meiosis" }, 1, "Hard", "Biology"),
                new ExamQuestion("The red blood cell carries _____", new[] { "CO2", "oxygen", "glucose", "protein" }, 1, "Hard", "Biology"),
                new ExamQuestion("Genetic info is in the form of _____", new[] { "protein", "lipids", "RNA", "DNA" }, 3, "Hard", "Biology")
            };


        public static List<ExamQuestion> GetQuestionsByDifficulty(string level, int count)
        {
            return Questions.Where(q => q.Difficulty == level).Take(count).ToList();
        }
    }
}
*/
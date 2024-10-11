namespace FitnessProgramManagementSystem_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadLine();
        }

        public static void Menu()
        {
            var _FitnessProgramRepository = new FitnessProgramRepository();

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("----------------------FitnessProgram Management System: -------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("1. Add a FitnessProgram");
            Console.WriteLine("2. View All FitnessPrograms");
            Console.WriteLine("3. Update a FitnessProgram");
            Console.WriteLine("4. Delete a FitnessProgram");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose an option:");
            var UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "1":
                    _FitnessProgramRepository.CreateFitnessProgram();
                    break;
                case "2":
                    _FitnessProgramRepository.GetAllFitnessPrograms();
                    break;
                case "3":
                    _FitnessProgramRepository.UpdateFitnessProgram();
                    break;
                case "4":
                    _FitnessProgramRepository.DeleteFitnessProgram();
                    break;
                case "5":
                    Console.WriteLine("Thank You!!! Come Again!!!");
                    return;
                default:
                    Menu();
                    break;

            }
        }
    }
}

namespace ParkingSystem;


class Program
{
    static void Main(string[] args)
    {
        ParkingManager parkingManager = null;

        while (true)
        {
            string input = Console.ReadLine();
            Console.Write("$ ");
            string[] tokens = input.Split(' ');

            switch (tokens[0])
            {
                case "create_parking_lot":
                    int capacity = int.Parse(tokens[1]);
                    parkingManager = new ParkingManager(capacity);
                    Console.WriteLine($"Created a parking lot with {capacity} slots");
                    break;

                case "park":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }

                    string registrationNumber = tokens[1];
                    string color = tokens[2];
                    string type = tokens[3];
                    parkingManager.ParkVehicle(registrationNumber, color, type);
                    break;

                case "status":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    parkingManager.DisplayParkingStatus();
                    break;
                
                case "leave" :
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    int slotNumber = int.Parse(tokens[1]);
                    parkingManager.Leave(slotNumber);
                    break;
                
                case "type_of_vehicles":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    string vehicleType = tokens[1];
                    int count = parkingManager.CountVehiclesByType(vehicleType);
                    Console.WriteLine(count);
                    break;

                case "exit":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
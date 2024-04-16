namespace ParkingSystem;


class Program
{
    static void Main(string[] args)
    {
        ParkingManager parkingManager = null;

        while (true)
        {
            Console.Write("$ ");
            string input = Console.ReadLine();
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
                
                case "registration_numbers_for_vehicles_with_ood_plate":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    List<string> oddPlateRegistrationNumbers = parkingManager.GetOddNumberPlate();
                    Console.WriteLine(string.Join(", ", oddPlateRegistrationNumbers));
                    break;
                
                case "registration_numbers_for_vehicles_with_event_plate":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    List<string> eventPlateRegistrationNumbers = parkingManager.GetEventNumberPlate();
                    Console.WriteLine(string.Join(", ", eventPlateRegistrationNumbers));
                    break;

                case "registration_numbers_for_vehicles_with_colour":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    string colorToSearch = tokens[1];
                    List<string> registrationNumbersForColor = parkingManager.GetNumberPlateWithColour(colorToSearch);
                    Console.WriteLine(string.Join(", ", registrationNumbersForColor));
                    break;
                
                case "slot_numbers_for_vehicles_with_colour":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    string colorSlot = tokens[1];
                    List<int> slotNumberwithColour = parkingManager.GetSlotNumberWithColour(colorSlot);
                    Console.WriteLine(string.Join(", ", slotNumberwithColour));
                    break;
                    
                case "slot_number_for_registration_number":
                    if (parkingManager == null)
                    {
                        Console.WriteLine("Please create parking lot first");
                        break;
                    }
                    string regNumber = tokens[1];
                    int slotNumberwithRegNumber = parkingManager.GetSlotNumberWithRegistrationNumber(regNumber);
                    if (slotNumberwithRegNumber != -1)
                    {
                        Console.WriteLine(slotNumberwithRegNumber);
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }
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
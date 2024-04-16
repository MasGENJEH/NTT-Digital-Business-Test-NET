namespace ParkingSystem;

public class ParkingManager
{
    private ParkingLot parkingLot;
    private Vehicle type; 

    public ParkingManager(int capacity)
    {
        parkingLot = new ParkingLot(capacity);
    }

    public void Leave(int slotNumber)
    {
        if (slotNumber < 1 || slotNumber > parkingLot.Slots.Count)
        {
            Console.WriteLine("Invalid slot number");
            return;
        }

        ParkingSlot slot = parkingLot.Slots[slotNumber - 1];
        if (slot.IsOccupied)
        {
            slot.IsOccupied = false;
            slot.ParkedVehicle = null;
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine($"Slot number {slotNumber} is already empty");
        }
    }

    public int CountVehiclesByType(string type)
    {
        return parkingLot.Slots.Count(slot => slot.IsOccupied && slot.ParkedVehicle.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
    }

    public void DisplayParkingStatus()
    {
        Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColor");
        foreach (var slot in parkingLot.Slots)
        {
            if (slot.IsOccupied)
            {
                Console.WriteLine($"{slot.SlotNumber}\t{slot.ParkedVehicle.Type}\t{slot.ParkedVehicle.RegistrationNumber}\t{slot.ParkedVehicle.Color}");
            }
            // else
            // {
            //     Console.WriteLine($"{slot.SlotNumber}\tEmpty");
            // }
        }
    }
    public void ParkVehicle(string registrationNumber, string color, string type)
    {
        ParkingSlot? emptySlot = parkingLot.Slots.FirstOrDefault(slot => slot.IsOccupied == false);        
        if (emptySlot != null)
        {
            emptySlot.ParkedVehicle = new Vehicle { RegistrationNumber = registrationNumber, Color = color, Type = type };
            emptySlot.IsOccupied = true;
            Console.WriteLine($"Allocated slot number: {emptySlot.SlotNumber}");
        }
        else
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }
}
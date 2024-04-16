using System.Globalization;
using System.Text.RegularExpressions;

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
        Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColor");
        foreach (var slot in parkingLot.Slots)
        {
            if (slot.IsOccupied)
            {
                Console.WriteLine($"{slot.SlotNumber}\t{slot.ParkedVehicle.RegistrationNumber}\t{slot.ParkedVehicle.Type}\t{slot.ParkedVehicle.Color}");
            }
        }
    }
    
    public List<string> GetOddNumberPlate()
    {
        List<string> registrationNumbers = new List<string>();

        foreach (var slot in parkingLot.Slots)
        {
            if (slot.IsOccupied)
            {
                string registrationNumber = slot.ParkedVehicle.RegistrationNumber;
                string numberRegistration = Regex.Replace(registrationNumber, @"[^\d]", "");
                int lastDigit;
                if (int.TryParse(numberRegistration, out lastDigit) && lastDigit % 2 != 0)
                {
                    registrationNumbers.Add(registrationNumber);
                }
            }
        }

        return registrationNumbers;
    }
    
    public List<string> GetEventNumberPlate()
    {
        List<string> registrationNumbers = new List<string>();

        foreach (var slot in parkingLot.Slots)
        {
            if (slot.IsOccupied)
            {
                string registrationNumber = slot.ParkedVehicle.RegistrationNumber;
                string numberRegistration = Regex.Replace(registrationNumber, @"[^\d]", "");
                int lastDigit;
                if (int.TryParse(numberRegistration, out lastDigit) && lastDigit % 2 == 0)
                {
                    registrationNumbers.Add(registrationNumber);
                }
            }
        }

        return registrationNumbers;
    }

    public List<string> GetNumberPlateWithColour(string colour)
    {
        List<string> registrationNumbers = new List<string>();
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string camelCaseColor = textInfo.ToTitleCase(colour).Replace(" ", "");

        foreach (var slot in parkingLot.Slots)
        {
            if (slot.IsOccupied && slot.ParkedVehicle.Color.Equals(camelCaseColor))
            {
                registrationNumbers.Add(slot.ParkedVehicle.RegistrationNumber);
            }
            
        }
        return registrationNumbers;
    }
    
    public List<int> GetSlotNumberWithColour(string colour)
    {
        List<int> slotNumber = new List<int>();
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string camelCaseColor = textInfo.ToTitleCase(colour).Replace(" ", "");
        foreach (var slot in parkingLot.Slots)
        {
            if (slot.IsOccupied && slot.ParkedVehicle.Color.Equals(camelCaseColor))
            {
                slotNumber.Add(slot.SlotNumber);
            }
            
        }
        return slotNumber;
    }
    
    public int  GetSlotNumberWithRegistrationNumber(string regNumber)
    {
        foreach (var slot in parkingLot.Slots)
        {
            if (slot.IsOccupied && slot.ParkedVehicle.RegistrationNumber.Equals(regNumber))
            {
                return slot.SlotNumber;
            }
        }

        return -1;
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
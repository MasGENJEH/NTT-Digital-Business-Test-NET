namespace ParkingSystem;

public class ParkingSlot
{
    public int SlotNumber { get; set; }
    public Vehicle ParkedVehicle { get; set; }
    public bool IsOccupied { get; set; }
}
namespace ParkingSystem;

public class ParkingLot
{
    private List<ParkingSlot?> slots;

    public ParkingLot(int capacity)
    {
        slots = new List<ParkingSlot?>();
        for (int i = 1; i <= capacity; i++)
        {
            slots.Add(new ParkingSlot { SlotNumber = i, IsOccupied = false });
        }
    }

    public List<ParkingSlot?> Slots { get { return slots; } }
}
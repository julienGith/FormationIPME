// See https://aka.ms/new-console-template for more information
using Garage;

test();

void test()
{
    int refId = 0;
    refId = Calcul.CalculId();
    Vehicle vehicle = new TwoWheels("Yaris", "bon", "10500", "fullOption", "Toyota", refId);
    Garage.Garage garage = new Garage.Garage();
    garage.AddVehicle(vehicle);
    foreach (var veh in garage.Vehicles)
    {
        Console.WriteLine($"ID : {veh.IdVehicule} Nom : {veh.VehiculeName}");
    }
    garage.SaveListVehicles(garage.Vehicles);
}



Menu.Launch();




/*
BSD 3-Clause License

Copyright (c) 2020, hancyfancy
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;

internal abstract class Vehicle : IComparable<Vehicle>
{
    private String _registration;
    private Int32 _numberOfWheels;
    private static VehicleConstants _sortBy;
    protected Vehicle(String newRegistration, Int32 newNumberOfWheels)
    {
        Registration = newRegistration;
        NumberOfWheels = newNumberOfWheels;       
    }
    internal String Registration
    {
        get
        {
            return _registration;
        }
        set
        {
            _registration = value;
        }
    }
    internal Int32 NumberOfWheels
    {
        get
        {
            return _numberOfWheels;
        }
        set
        {
            _numberOfWheels = value;
        }
    }
    internal static VehicleConstants SortBy
    {
        get
        {
            return _sortBy;
        }
        set
        {
            _sortBy = value;
        }
    }
    public int CompareTo(Vehicle other)
    {
        Int32 comparison;
        if (SortBy == VehicleConstants.REGISTRATION)
        {
            comparison = Registration.CompareTo(other.Registration);
        }
        else if (SortBy == VehicleConstants.NUMBEROFWHEELS)
        {
            comparison = NumberOfWheels.CompareTo(other.NumberOfWheels);
        }
        else
        {
            comparison = 1;
        }
        return comparison;
    }
    public override String ToString()
    {
        return Registration + "; " + Convert.ToString(NumberOfWheels);
    }
}

internal class Car : Vehicle
{
    public Car(String newRegistration, Int32 newNumberOfWheels) : base(newRegistration, (newNumberOfWheels > 2) && (newNumberOfWheels < 5) ? newNumberOfWheels : 4)
    {
        
    }
}

internal class Truck : Vehicle
{
    public Truck(String newRegistration, Int32 newNumberOfWheels) : base(newRegistration, (newNumberOfWheels > 4) && (newNumberOfWheels < 17) && (newNumberOfWheels % 2 == 0) ? newNumberOfWheels : 8)
    {
        
    }
}

internal enum VehicleConstants
{
    REGISTRATION,
    NUMBEROFWHEELS
}

internal enum VehicleStoreConstants
{
    CAR,
    TRUCK
}

internal class VehicleStore<T> : DynamicUniqueStore<T> where T : Vehicle
{
    public VehicleStore() : base()
    {

    }
    public Object Get(VehicleStoreConstants vc)
    {
        if (vc == VehicleStoreConstants.CAR)
        {
            CarStore<Car> vs = new CarStore<Car>();
            for (Int32 i = 0; i < Length; i++)
            {
                if (this.Get(i) is Car)
                {
                    Car c = (Car)(Object)this.Get(i);
                    vs.Add(c);
                }
            }
            return vs;
        }
        else if (vc == VehicleStoreConstants.TRUCK)
        {
            TruckStore<Truck> vs = new TruckStore<Truck>();
            for (Int32 i = 0; i < Length; i++)
            {
                if (this.Get(i) is Truck)
                {
                    Truck t = (Truck)(Object)this.Get(i);
                    vs.Add(t);
                }
            }
            return vs;
        }
        else
        {
            return null;
        }
    }
}

internal class CarStore<T> : VehicleStore<T> where T : Car
{
    public CarStore() : base()
    {

    }
}

internal class TruckStore<T> : VehicleStore<T> where T : Truck
{
    public TruckStore() : base()
    {

    }
}

internal class VehicleSorter<T> : OneDimensionSorter<T> where T : Vehicle
{
    public VehicleSorter(IOneDimensionStorable<T> newVehicles) : base(newVehicles)
    {

    }
    public void Sort(VehicleConstants sortBy)
    {
        Vehicle.SortBy = sortBy;
        base.Sort();
    }
    public void ParallelSort(VehicleConstants sortBy)
    {
        Vehicle.SortBy = sortBy;
        base.ParallelSort();
    }
}

internal class CarSorter<T> : VehicleSorter<T> where T : Car
{
    public CarSorter(IOneDimensionStorable<T> newCars) : base(newCars)
    {
        
    }   
}

internal class TruckSorter<T> : VehicleSorter<T> where T : Truck
{
    public TruckSorter(IOneDimensionStorable<T> newTrucks) : base(newTrucks)
    {
        
    }   
}

public class StructVehicleExampleTests
{
    public static void Main()
    {
        VehicleStore<Vehicle> vehicleStore = new VehicleStore<Vehicle>();
        vehicleStore.Add(new Car("XYZ123", 4));
        vehicleStore.Add(new Truck("ABC987", 6));
        vehicleStore.Add(new Car("OOR734", 3));
        vehicleStore.Add(new Car("XYZ123", 4));
        VehicleSorter<Vehicle> vehicleSorter = new VehicleSorter<Vehicle>(vehicleStore);
        vehicleSorter.Sort(VehicleConstants.NUMBEROFWHEELS);
        Console.WriteLine(vehicleStore);

        CarStore<Car> carStoreOne = new CarStore<Car>();
        carStoreOne.Add(new Car("IWE742", 10));
        Console.WriteLine(carStoreOne);

        TruckStore<Truck> truckStoreOne = new TruckStore<Truck>();
        truckStoreOne.Add(new Truck("NSD359", 0));
        Console.WriteLine(truckStoreOne);

        CarStore<Car> carStoreTwo = (CarStore<Car>)vehicleStore.Get(VehicleStoreConstants.CAR);
        carStoreTwo.Add(new Car("IWE742", 10));
        CarSorter<Car> carSorter = new CarSorter<Car>(carStoreTwo);
        carSorter.ParallelSort(VehicleConstants.REGISTRATION);
        Console.WriteLine(carStoreTwo);

        TruckStore<Truck> truckStoreTwo = (TruckStore<Truck>)vehicleStore.Get(VehicleStoreConstants.TRUCK);
        truckStoreTwo.Add(new Truck("NSD359", 0));
        TruckSorter<Truck> truckSorter = new TruckSorter<Truck>(truckStoreTwo);
        truckSorter.Sort(VehicleConstants.NUMBEROFWHEELS);
        Console.WriteLine(truckStoreTwo);
    }
}

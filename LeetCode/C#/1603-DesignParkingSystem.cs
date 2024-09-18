/*

Approach:
- Create three variables to store the number of big, medium, and small cars.
- Create a constructor to initialize the number of big, medium, and small cars.
- Create a method to add a car to the parking lot.
- Check the car type and decrement the number of cars accordingly.
- Return true if the car is added successfully, otherwise return false.

Time complexity: O(1)
Space complexity: O(1)

*/
public class ParkingSystem {

    private int _numOfBigCars;
    private int _numOfMediumCars;
    private int _numOfSmallCars;



    public ParkingSystem(int big, int medium, int small) {
        _numOfBigCars = big;
        _numOfMediumCars = medium;
        _numOfSmallCars = small;
    }


    public bool AddCar(int carType) {

        switch(carType) {
            case 1:
                if (_numOfBigCars > 0) {
                        _numOfBigCars--;
                        return true;
                    }
                else
                    return false;
            case 2:
                if (_numOfMediumCars > 0) {
                        _numOfMediumCars--;
                        return true;
                    }
                else
                    return false;
            case 3:
                if (_numOfSmallCars > 0) {
                        _numOfSmallCars--;
                        return true;
                    }
                else
                    return false;
        }

        return false;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */
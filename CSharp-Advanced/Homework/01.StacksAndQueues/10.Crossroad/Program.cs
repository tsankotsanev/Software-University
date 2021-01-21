﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroad
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLight = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            var command = string.Empty;
            var crashCars = false;
            var crashedCar = string.Empty;
            var hitIndex = -1;
            var passedCars = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    var currGreenLight = greenLight;
                    while (cars.Any() && currGreenLight > 0)
                    {
                        var curentCar = cars.Peek();
                        var carLenght = curentCar.Length;

                        currGreenLight -= carLenght;

                        if (currGreenLight >= 0)
                        {
                            cars.Dequeue();
                            passedCars++;
                        }
                        else
                        {
                            var left = Math.Abs(currGreenLight);

                            if (left <= freeWindow)
                            {
                                cars.Dequeue();
                                passedCars++;
                            }
                            else
                            {
                                crashCars = true;
                                crashedCar = curentCar;
                                hitIndex = carLenght - left + freeWindow;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                if (crashCars)
                {
                    break;
                }
            }
            if (crashCars)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar}" +
                    $" was hit at {crashedCar[hitIndex]}.");
                return;
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
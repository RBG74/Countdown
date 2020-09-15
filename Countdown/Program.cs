using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Countdown
{
    public class Program
    {
        public static List<Reasoning> Reasonings { get; set; } = new List<Reasoning>();
        static void Main(string[] args)
        {
            var values = new List<int>{ 7, 4, 5, 8, 3, 1 };
            const int target = 299;
            Console.WriteLine("Values: " + string.Join(", ", values));
            Console.WriteLine("Target: " + target + Environment.NewLine);

            if(Resolve(target, values))
            {
                Console.WriteLine("Solved: ");
                Reasonings.Reverse();
                foreach (var reasoning in Reasonings)
                    Console.WriteLine(reasoning.Calculation);
            }
            else
                Console.WriteLine("Unsolvable :/");
        }

        public static bool Resolve(in int target, in List<int> values, int depth = -1)
        {
            if (values.Count <= 1) return false;
            depth++;

            var a = values[0];
            var newValues = new List<int>(values);
            newValues.Remove(a);

            for (int i = 0; i < newValues.Count; i++)
            {
                var b = newValues[i];
                string calculation;
                bool isOnTarget;

                var added = TryAddition(a, b, target, out isOnTarget, out calculation);
                if (isOnTarget || HandleRecursion(newValues, b, added, target, depth))
                {
                    Reasonings.Add(new Reasoning(depth, calculation));
                    return true;
                }

                var substracted = TrySubstraction(a, b, target, out isOnTarget, out calculation);
                if (isOnTarget || HandleRecursion(newValues, b, substracted, target, depth))
                {
                    Reasonings.Add(new Reasoning(depth, calculation));
                    return true;
                }

                var multiplied = TryMultiplication(a, b, target, out isOnTarget, out calculation);
                if (isOnTarget || HandleRecursion(newValues, b, multiplied, target, depth))
                {
                    Reasonings.Add(new Reasoning(depth, calculation));
                    return true;
                }

                var divided = TryDivision(a, b, target, out isOnTarget, out calculation);
                if (isOnTarget || (divided.HasValue && HandleRecursion(newValues, b, divided.Value, target, depth)))
                {
                    Reasonings.Add(new Reasoning(depth, calculation));
                    return true;
                }

            }
            if (Resolve(target, newValues, depth))
                return true;

            return false;
        }

        private static int TryAddition(int a, int b, int target, out bool IsOnTarget, out string calculation)
        {
            var added = a + b;
            IsOnTarget = added == target;
            calculation = a + " + " + b + " = " + added;
            return added;
        }

        private static int TrySubstraction(int a, int b, int target, out bool IsOnTarget, out string calculation)
        {
            var values = new List<int> {a, b};
            var max = values.Max();
            var min = values.Min();
            
            var substracted = max - min; 
            IsOnTarget = substracted == target;
            calculation = max + " - " + min + " = " + substracted;
            return substracted;
        }

        private static int TryMultiplication(int a, int b, int target, out bool IsOnTarget, out string calculation)
        {
            var multiplied = a * b; 
            IsOnTarget = multiplied == target;
            calculation = a + " * " + b + " = " + multiplied;
            return multiplied;
        }

        private static int? TryDivision(int a, int b, int target, out bool IsOnTarget, out string calculation)
        {
            if (b == 0 || a % b != 0)
            {
                IsOnTarget = false;
                calculation = null;
                return null;
            }
            var divided = a / b; 
            IsOnTarget = divided == target;
            calculation = a + " / " + b + " = " + divided;
            return divided;
        }

        private static bool HandleRecursion(List<int> values, int valueToRemove, int calculatedValue, in int target, in int depth)
        {
            var addedValues = new List<int>(values);
            addedValues.Remove(valueToRemove);
            addedValues.Insert(0, calculatedValue);
            return Resolve(target, addedValues, depth);
        }
    }

    public class Reasoning
    {
        public Reasoning(int depth, string calculation)
        {
            Depth = depth;
            Calculation = calculation;
        }

        public int Depth { get; set; }
        public string Calculation { get; set; }

        public override string ToString()
        {
            return "D=" + Depth + " | " + Calculation;
        }
    }

}

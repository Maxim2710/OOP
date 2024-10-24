using System;

namespace ExampleAppForDesignPatterns.StructuralPatterns
{
    // Подсистема A
    class SubsystemA
    {
        public string OperationA()
        {
            return "Subsystem A: Ready!\n";
        }
    }

    // Подсистема B
    class SubsystemB
    {
        public string OperationB()
        {
            return "Subsystem B: Get ready!\n";
        }
    }

    // Подсистема C
    class SubsystemC
    {
        public string OperationC()
        {
            return "Subsystem C: Go!";
        }
    }

    // Фасад
    class Facade
    {
        private readonly SubsystemA _subsystemA;
        private readonly SubsystemB _subsystemB;
        private readonly SubsystemC _subsystemC;

        public Facade()
        {
            _subsystemA = new SubsystemA();
            _subsystemB = new SubsystemB();
            _subsystemC = new SubsystemC();
        }

        public string Operation()
        {
            var result = "Facade initializes subsystems:\n";
            result += _subsystemA.OperationA();
            result += _subsystemB.OperationB();
            result += _subsystemC.OperationC();
            return result;
        }
    }
}
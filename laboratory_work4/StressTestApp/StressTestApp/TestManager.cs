using System;

namespace StressTest
{
    public static class TestManager
    {
        private static Random random = new Random();

        // Метод для генерации случайных результатов теста
        public static TestCaseResult GenerateResult()
        {
            // Генерация случайного результата (Pass или Fail)
            TestResult result = (TestResult)random.Next(0, 2);

            // Если тест провален, указываем случайную причину отказа
            string reasonForFailure = result == TestResult.Fail ? GenerateFailureReason() : string.Empty;

            return new TestCaseResult(result, reasonForFailure);
        }

        // Метод для генерации случайной причины отказа
        private static string GenerateFailureReason()
        {
            string[] reasons = { "Material fatigue", "Design flaw", "Overload", "Environmental factors", "Manufacturing defect" };
            return reasons[random.Next(reasons.Length)];
        }
    }
}

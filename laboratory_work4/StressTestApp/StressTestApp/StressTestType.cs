namespace StressTest
{
    /// <summary>
    /// Перечисление типов материалов балки
    /// </summary>
    public enum Material
    {
        StainlessSteel,
        Aluminium,
        ReinforcedConcrete,
        Composite,
        Titanium
    }

    /// <summary>
    /// Перечисление типов поперечного сечения балки
    /// </summary>
    public enum CrossSection
    {
        IBeam,
        Box,
        ZShaped,
        CShaped
    }

    /// <summary>
    /// Перечисление результатов теста
    /// </summary>
    public enum TestResult
    {
        Pass,
        Fail
    }

    // 2 часть задания (4 таска)

    // Новая структура для хранения результатов теста
    public struct TestCaseResult
    {
        public TestResult Result; // результат теста
        public string ReasonForFailure; // причина отказа, если тест не прошел

        // Конструктор для инициализации полей
        public TestCaseResult(TestResult result, string reasonForFailure)
        {
            Result = result;
            ReasonForFailure = reasonForFailure;
        }
    }
}

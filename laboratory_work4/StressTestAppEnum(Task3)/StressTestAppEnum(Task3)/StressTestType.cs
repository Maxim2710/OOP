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
}

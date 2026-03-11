using System;

namespace KinematicsTask
{
    public class KinematicsCalculator
    {
        // Константы механизма (мм) - из Таблицы 2.2
        public const double R2_BIG = 95.0;    // Большой цилиндр блока 2
        public const double R2_SMALL = 38.0;  // Малый цилиндр блока 2
        public const double R3_BIG = 96.0;    // Большой цилиндр блока 3
        public const double R3_SMALL = 73.0;  // Малый цилиндр блока 3

       
        public const double EQ_A = 108.0;   // Коэффициент при t²
        public const double EQ_B = 0.0;   // Коэффициент при t
        public const double EQ_C = 28.0;    // Свободный член

        public struct CalculationResult
        {
            // Груз 1
            public double S1;       // Путь, мм
            public double V1;       // Скорость, мм/с
            public double A1;       // Ускорение, мм/с²

            // Блок 2
            public double Omega2;   // Угловая скорость, рад/с
            public double Epsilon2; // Угловое ускорение, рад/с²

            // Точка A (блок 2)
            public double Va;       // Скорость, мм/с
            public double Ata;      // Тангенциальное ускорение, мм/с²

            // Точка B (блок 2)
            public double Vb;       // Скорость, мм/с
            public double Atb;      // Тангенциальное ускорение, мм/с²

            // Блок 3
            public double Omega3;   // Угловая скорость, рад/с
            public double Epsilon3; // Угловое ускорение, рад/с²

            // Точка M (блок 3)
            public double Vm;       // Скорость, м/с
            public double AnM;      // Нормальное ускорение, м/с²
            public double AtM;      // Тангенциальное ускорение, м/с²
            public double ATotalM;  // Полное ускорение, м/с²
        }

        public CalculationResult Calculate(double t)
        {
            CalculationResult res = new CalculationResult();

            // ========== ГРУЗ 1 (прямолинейное движение) ==========
            // Формула (2.1): S₁(t) = A·t² + B·t + C
            res.S1 = EQ_A * Math.Pow(t, 2) + EQ_B * t + EQ_C;

            // Формула (2.3): V₁(t) = dS/dt = 2·A·t + B
            res.V1 = 2 * EQ_A * t + EQ_B;

            // Формула (2.6): A₁(t) = dV/dt = 2·A
            res.A1 = 2 * EQ_A;

            // ========== БЛОК 2 ==========
           
            // Формула (2.7): V_A = V₁
            res.Va = res.V1;

            // Формула (2.8): A_tA = A₁
            res.Ata = res.A1;

            // Формула (2.9): ω₂ = V_A / R2_SMALL
            res.Omega2 = res.Va / R2_SMALL;

            // Формула (2.10): ε₂ = A_tA / R2_SMALL
            res.Epsilon2 = res.Ata / R2_SMALL;

            // ========== ТОЧКА B (большой цилиндр блока 2) ==========
            // Формула (2.11): V_B = ω₂ · R2_BIG
            res.Vb = res.Omega2 * R2_BIG;

            // Формула (2.12): A_tB = ε₂ · R2_BIG
            res.Atb = res.Epsilon2 * R2_BIG;

            // ========== БЛОК 3 ==========
          
            // Формула (2.15): ω₃ = V_B / R3_SMALL
            res.Omega3 = res.Vb / R3_SMALL;

            // Формула (2.16): ε₃ = A_tB / R3_SMALL
            res.Epsilon3 = res.Atb / R3_SMALL;

            // ========== ТОЧКА M (большой цилиндр блока 3) ==========
            // Формула (2.17): V_M = ω₃ · R3_BIG (в мм/с)
            double Vm_mm_s = res.Omega3 * R3_BIG;

            // Формула (2.18): A_tM = ε₃ · R3_BIG (в мм/с²)
            double AtM_mm_s2 = res.Epsilon3 * R3_BIG;

            // Формула (2.21): A_nM = V_M² / R3_BIG (в мм/с²)
            double AnM_mm_s2 = Math.Pow(Vm_mm_s, 2) / R3_BIG;

            // Формула (2.23): A_M = √(A_tM² + A_nM²) (в мм/с²)
            double ATotalM_mm_s2 = Math.Sqrt(Math.Pow(AtM_mm_s2, 2) + Math.Pow(AnM_mm_s2, 2));

            // Перевод в СИ (м/с, м/с²) для точки M
            res.Vm = Vm_mm_s / 1000.0;
            res.AtM = AtM_mm_s2 / 1000.0;
            res.AnM = AnM_mm_s2 / 1000.0;
            res.ATotalM = ATotalM_mm_s2 / 1000.0;

            return res;
        }
    }

}

namespace Day2_Lab
{
    // La puse internal para aplicar los ejemplos dichos en la clase
    internal static class Mathh
    {
        public static Constants constants { get; set; }

        // Método para sumar
        public static int Sum(int value1, int value2) => value1 + value2; //Single Expression

        // Método para multiplicar
        public static int Mult(int n1, int n2) => n1 * n2; // Single Expression

        // Método para multiplicar sobrecargado
        public static int Mult(int n1, int n2, int n3) => n1 * n2 * n3; // Single Expression

        // Metodo para calcular la raíz cúbica
        public static double Cbrt(double value) => Math.Cbrt(value); // Single Expression

        // Método que retorna el valor minimo
        public static int MinValue(int[] values)
        {
            Array.Sort(values);
            var firstValue = values[0];

            return firstValue;
        } // Method with body

        // Método para dividir
        public static void Divide(int x, int y, out int result) => result = x / y;
    }
}

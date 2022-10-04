using Day1_lab.BussinessLogic;
using Day1_lab.Entity;

LogicGeneric<EmployeeEntity> employee = new LogicGeneric<EmployeeEntity>();


Console.Write("Employees Entity \n" +
    "1: Agregar Empleado. \n" +
    "2: Eliminar Empleado. \n" +
    "3: Editar Empleado. \n" +
    "4. Ver Empleados. \n \n" +
    "Elige una opción númerica: ");

int option = int.Parse(Console.ReadLine());

switch (option)
{
    case 1:
        break;
    case 2:
        employee.Read();
        break;
    case 3:
        break;
    case 4:
        break;
    default:
        Console.WriteLine("Fuera de rango");
        break;
}
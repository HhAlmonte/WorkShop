using Day1_lab.Entity;
using Day1_lab.ENUMs;
using Day1_Lab.BussinessLogic;

var employeeService = new EmployeeLogic();
bool active = true;

while (active)
{
    switch (Menu())
    {
        case 1:
            GetEmployees();
            break;
        case 2:
            GetEmployee();
            break;
        case 3:
            CreateEmployee();
            break;
        case 4:
            UpdateEmployee();
            break;
        case 5:
            DeleteEmployee();
            break;
        case 6:
            Reset();
            break;
        default:
            Console.WriteLine("Fuera de rango o valor ingresado no permitido");
            break;
    }
}

int Menu()
{
    Console.WriteLine("1. Listar Personas");
    Console.WriteLine("2. Buscar Persona por Id");
    Console.WriteLine("3. Crear Persona");
    Console.WriteLine("4. Actualizar Persona");
    Console.WriteLine("5. Eliminar Persona");
    Console.WriteLine("6. Limpiar consola");
    Console.WriteLine("7. Salir");

    Console.Write("Seleccione una opción: ");
    var option = int.Parse(Console.ReadLine());

    if (option <= 0 && option >= 7)
    {
        Console.WriteLine("Fuera de rango");
    }

    return option;
}
void GetEmployees()
{
    employeeService.Get().ForEach(x =>
    {
        if(x != null)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Información del empleado {x.Name}");
            Console.WriteLine($"Identificador: {x.Id}");
            Console.WriteLine($"Nombre completo: {x.FullName}");
            Console.WriteLine($"Puesto de trabajo: {x.Cargo}");
            Console.WriteLine($"Cargo: {x.Gender}");
            Console.WriteLine($"Cantidad de hijos: {x.CHijos}");
            Console.WriteLine($"Fecha de ingreso: {x.Created}");
            Console.WriteLine("---------------------------------------");
        }

        Console.WriteLine("No hay data para mostrar");
    });
}
void GetEmployee()
{
    Console.Write("Ingrese el ID del empleado a buscar: ");
    var id = Convert.ToInt32(Console.ReadLine());
    var employee = employeeService?.Get(id);

    if (employee != null)
    {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"Identificador: {employee.Id}");
        Console.WriteLine($"Información del empleado {employee.Name}");
        Console.WriteLine($"Nombre completo: {employee.FullName}");
        Console.WriteLine($"Puesto de trabajo: {employee.Cargo}");
        Console.WriteLine($"Cargo: {employee.Gender}");
        Console.WriteLine($"Cantidad de hijos: {employee.CHijos}");
        Console.WriteLine($"Fecha de ingreso: {employee.Created}");
        Console.WriteLine("---------------------------------------");
    }

    Console.WriteLine("Empleado no encontrado");
}
void DeleteEmployee()
{
    Console.Write("Ingrese el ID del empleado a eliminar: ");
    var id = Convert.ToInt32(Console.ReadLine());

    try
    {
        employeeService?.Delete(id);
        Console.WriteLine("empleado eliminado");
    }
    catch (Exception)
    {
        Console.WriteLine("Hubo un error eliminando el empleado. Intente nuevamente.");
        throw;
    }
}
void CreateEmployee()
{
    Console.Write($"Nombre: ");
    var name = Console.ReadLine();
    Console.Write($"Apellido: ");
    var lastName = Console.ReadLine();
    Console.Write($"Puesto de trabajo: ");
    var cargo = Console.ReadLine();
    Console.Write($"Cantidad de hijos: ");
    var cHijos = int.Parse(Console.ReadLine());
    Console.Write($"Sexo: ");
    var gender = Console.ReadLine();

    var employeeEntity = new EmployeeEntity(
        name,
        lastName,
        gender == "M" ? SexEnum.MASCULINO : SexEnum.FEMENINO,
        cargo,
        cHijos
        );

    try
    {
        employeeService.Create(employeeEntity);
        Console.WriteLine("Empleado creado");
    }
    catch (Exception)
    {
        Console.WriteLine("Error al crear empleado");
        throw;
    }
}
void UpdateEmployee()
{
    Console.Write("Ingrese el Identificador de la persona: ");
    var id = Convert.ToInt32(Console.ReadLine());

    Console.Write("-----------------------------------------");

    Console.WriteLine("Ingrese los datos de la persona");

    Console.Write($"Nombre: ");
    var name = Console.ReadLine();
    Console.Write($"Apellido: ");
    var lastName = Console.ReadLine();
    Console.Write($"Puesto de trabajo: ");
    var cargo = Console.ReadLine();
    Console.Write($"Cantidad de hijos: ");
    var cHijos = int.Parse(Console.ReadLine());
    Console.Write($"Sexo: ");
    var gender = Console.ReadLine();

    var employeeEntity = new EmployeeEntity(
        name,
        lastName,
        gender == "M" ? SexEnum.MASCULINO : SexEnum.FEMENINO,
        cargo,
        cHijos
        );

    try
    {
        employeeService.Modify(employeeEntity);
        Console.WriteLine("Empleado creado");
    }
    catch (Exception)
    {
        Console.WriteLine("Error al actualizar empleado");
        throw;
    }
}
void Reset()
{
    Console.Clear();
}
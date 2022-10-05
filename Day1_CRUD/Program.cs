using Day1_CRUD.Entities;
using Day1_CRUD.ENUMs;
using Day1_CRUD.Services;

var personService = new PersonService();
bool active = true;
while (active)
{
    switch (Menu())
    {
        case 1:
            GetAllPerson();
            break;
        case 2:
            GetPersonById();
            break;
        case 3:
            CreatePerson();
            break;
        case 4:
            UpdatePerson();
            break;
        case 5:
            DeletePerson();
            break;
        case 6:
            Reset();
            break;
        case 7:
            active = false;
            break;
        default:
            Console.WriteLine("Fuera de rango");
            break;
    }
    Console.Beep();

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

        if(option <= 0 && option >= 7){
            Console.WriteLine("Fuera de rango");
        }

        return option;
    }
    void GetAllPerson()
    {
        personService.Get().ForEach(x =>
        {
            if (x != null)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Nombre: {x.Name} \nGenero: {x.Gender} \nCumpleaños: {x.BithDate}");
                Console.WriteLine("--------------------------------");
            }
            Console.WriteLine("No hay data para mostrar. Intenta creado una persona");
        });
    }
    void GetPersonById()
    {
        Console.Write("Ingrese el ID de la persona a buscar: ");
        var id = Convert.ToInt32(Console.ReadLine());
        var person = personService?.GetById(id);

        if (person != null)
        {
            Console.WriteLine("Persona identificada: \n" +
                $"Id: {person.Id} \n" +
                $"Nombre: {person.Name} \n" +
                $"Genero: {person.Gender} \n" +
                $"Cumpleaños: {person.BithDate}");
        }

        Console.WriteLine("Persona no encontrada");
    }
    void DeletePerson()
    {
        Console.Write("Ingrese el ID de la persona a eliminar: ");
        var id = Convert.ToInt32(Console.ReadLine());

        try
        {
            personService?.Delete(id);
            Console.WriteLine("Persona eliminada");
        }
        catch (Exception)
        {
            Console.WriteLine("Hubo un error eliminando la persona. Intente nuevamente.");
            throw;
        }
    }
    void CreatePerson()
    {
        Console.Write("Ingrese el nombre, genero y fecha de cumpleaños separado por coma: ");
        var input = Console.ReadLine();
        var data = input?.Split(",");

        var person = new Person
        {
            Name = data[0],
            Gender = data[1] == "M" ? Sex.MASCULINO : Sex.FEMENINO,
            BithDate = Convert.ToDateTime(data[2])
        };

        try
        {
            personService?.Create(person);
            Console.WriteLine("Persona creada");
        }
        catch (Exception)
        {
            Console.WriteLine("Error al crear la persona");
            throw;
        }
    }
    void UpdatePerson()
    {
        Console.Write("Ingrese el Identificador de la persona: ");
        var id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el nuevo nombre, genero y fecha de cumpleaños separado por coma: ");
        var input = Console.ReadLine();
        var data = input?.Split(",");

        var person = new Person
        {
            Id = id,
            Name = data[0],
            Gender = data[1] == "M" ? Sex.MASCULINO : Sex.FEMENINO,
            BithDate = Convert.ToDateTime(data[2])
        };

        try
        {
            personService?.Update(person);
            Console.WriteLine("Persona actualizada");
        }
        catch (Exception)
        {
            Console.WriteLine("Error al crear la persona");
            throw;
        }
    }
    void Reset()
    {
        Console.Clear();
    }
}
class GestorReserva
{
    //lista para almacenar reservas
    private List<Reserva> reservas = new List<Reserva>();

    //creación de reserva de un equipo y rango de fecha
    public Reserva CrearReserva(string ID, Cliente cliente, Equipo equipo, DateTime Desde, DateTime Hasta)
    {
        var lista = new List<Equipo> { equipo };
        var r = new Reserva(ID, cliente, lista, Desde, Hasta);
        reservas.Add(r);
        return r;
    }

    //creación de reserva con lista de equipo que calcular fecha con cantidad de dias
    public Reserva CrearReserva(string ID, Cliente cliente, List<Equipo> equipo, int dias)
    {
        DateTime Desde = DateTime.Today;
        DateTime Hasta = Desde.AddDays(dias);

        var r = new Reserva(ID, cliente, equipo, Desde, Hasta);
        reservas.Add(r);
        return r;
    }

    //creación de reserva de un equipo que calcula fecha con cantidad de días
    public Reserva CrearReserva(string ID, Cliente cliente, Equipo equipo, int dias)
    {
        DateTime Desde = DateTime.Today;
        DateTime Hasta = Desde.AddDays(dias);

        var lista = new List<Equipo> { equipo };
        var r = new Reserva(ID, cliente, lista, Desde, Hasta);
        reservas.Add(r);
        return r;
    }

    //metodo para demostrar información de todas las reservas
    public void Reporte()
    {
        Console.WriteLine("====== REPORTE DE RESERVAS======");

        foreach (var r in reservas)
        {
            Console.WriteLine($"ID: {r.ID}");
            Console.WriteLine($"Cliente: {r.Cliente.Nombre}");
            Console.WriteLine($"Rango: {r.Desde.ToShortDateString()} - {r.Hasta.ToShortDateString()}");
            Console.WriteLine($"Estado: {r.Estado}");
            Console.WriteLine($"Monto final: {r.Monto}");

            Console.WriteLine("Equipos:");
            foreach (var eq in r.Equipo)
            {
                Console.Write($" -");
                eq.Detalle();
            }

            if (r.Penalidad > 0)
                Console.WriteLine($"Penalidad: {r.Penalidad}");
            Console.WriteLine("--------------------------------");
        }
    }
}
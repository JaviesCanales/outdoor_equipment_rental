using System;
internal class Program
{
    static void Main(string[] args)
    {
        //Creación de cliente y equipos
        Cliente cliente1 = new Cliente("00994485", "Javies", "7876465434");
        Bicicleta bicicleta1 = new Bicicleta("341", "BMX", 30, true, true);
        Kayak kayak1 = new Kayak("678", "Lifetime Recruit", 20, 2, true);
        TiendaCampana tienda1 = new TiendaCampana("789", "KAZOO", 15, 3, true);

        //creación gestor de reserva
        GestorReserva gestor = new GestorReserva();

        //lista de equipos
        List<Equipo> equipos = new List<Equipo>{ bicicleta1, kayak1, tienda1 };

        //creación diferentes tipos de tarifas
        TarifaEquipo tarifa = new TarifaEquipo();
        TarifaEquipo tarifaF = new TarifaFinDeSemana();
        TarifaEquipo tarifaA = new TarifaTemporadaAlta();

        //creacion de pago
        ComprobantePago pago = new ComprobantePago();

        //creacion de reservas con diferentes sobrecargas
        Reserva r1 = gestor.CrearReserva(
            cliente1.ID,
            cliente1,
            bicicleta1,
            DateTime.Today,
            DateTime.Today.AddDays(3)
        );

        Reserva r2 = gestor.CrearReserva(
            cliente1.ID,
            cliente1,
            equipos,
            2
        );

        Reserva r3 = gestor.CrearReserva(
            cliente1.ID,
            cliente1,
            kayak1,
            5
        );

        //calculos de monto de las reservas utilizando diferente tarifas
        r1.CalcularMonto(tarifa, false, 0);
        r2.CalcularMonto(tarifaF, true, 0);
        r3.CalcularMonto(tarifaA, true, 13.45);
        
        //uso de metodos de estados
        r1.Confirmar();
        r1.Entregar();
        r1.Devolver(new List<Equipo> { bicicleta1 }, false, 1);
        r1.Cerrar();

        r2.Confirmar();
        r2.Entregar();
        r2.Devolver(new List<Equipo> { kayak1 }, true, 0);

        r3.Confirmar();
        r3.Cancelar();
        
        //pago simple
        bool pagado = r1.Pago.Pagar(r1.Monto);
        if (pagado)
        {
            Console.WriteLine("Pago de r1 pagado exitosamente.");
        }
        else
        {
            Console.WriteLine("Error al pagar.");
        }

        //pago tarjeta
        bool pagado2 = r2.Pago.Pagar(r2.Monto, null);
        if (pagado2)
        {
            Console.WriteLine("Pago de r2 pagado exitosamente.");
        }
        else
        {
            Console.WriteLine("Error al pagar.");
        }
        
        //pago efectivo
        bool pagado3 = r3.Pago.Pagar(r3.Monto, 200.95);
        if (pagado3)
        {
            Console.WriteLine($"Pago de r3 pagado exitosamente. Cambio: {r3.Pago.Cambio}");
        }
        else
        {
            Console.WriteLine("Error al pagar.");
        }
        //mostrar reportes
        gestor.Reporte();
    }
}


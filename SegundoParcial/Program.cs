// See https://aka.ms/new-console-template for more information
Console.WriteLine("Gestión De Inventario.");
Console.WriteLine();

Console.WriteLine("Ingrese datos del Producto Electrónico ");
Console.Write("Nombre: ");
string nombreE = Console.ReadLine();
Console.Write("Código: ");
string codigoE = Console.ReadLine();
Console.Write("Precio: ");
decimal precioE = decimal.Parse(Console.ReadLine());
Console.Write("Cantidad: ");
int cantidadE = int.Parse(Console.ReadLine());
Console.Write("Marca: ");
string marca = Console.ReadLine();
Console.Write("Modelo: ");
string modelo = Console.ReadLine();
Console.Write("Garantía (meses): ");
int garantia = int.Parse(Console.ReadLine());

var productoElectronico = new ProductoElectronico(nombreE, codigoE, precioE, cantidadE, marca, modelo, garantia);

Console.WriteLine("Ingrese datos del Producto de Alimento ");
Console.Write("Nombre: ");
string nombreA = Console.ReadLine();
Console.Write("Código: ");
string codigoA = Console.ReadLine();
Console.Write("Precio: ");
decimal precioA = decimal.Parse(Console.ReadLine());
Console.Write("Cantidad: ");
int cantidadA = int.Parse(Console.ReadLine());
Console.Write("Fecha de vencimiento (yyyy-MM-dd): ");
DateTime fechaVencimiento = DateTime.Parse(Console.ReadLine());

var productoAlimento = new ProductoAlimento(nombreA, codigoA, precioA, cantidadA, fechaVencimiento);

Console.WriteLine();

Console.WriteLine("Producto Electrónico:");
productoElectronico.MostrarProducto();
Console.WriteLine($"Impuesto: {productoElectronico.CalcularImpuesto():C}");

Console.WriteLine();
Console.WriteLine("Producto de Alimento:");
productoAlimento.MostrarProducto();
Console.WriteLine($"Impuesto: {productoAlimento.CalcularImpuesto():C}");


class Producto
{
    private string nombre;
    private string codigo;
    private decimal precio;
    private int cantidad;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Codigo { get => codigo; set => codigo = value; }
    public decimal Precio { get => precio; set => precio = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }

    public Producto(string nombre, string codigo, decimal precio, int cantidad)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.precio = precio;
        this.cantidad = cantidad;
    }

    public virtual decimal CalcularImpuesto()
    {
        return 0m;
    }

    public virtual void MostrarProducto()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Precio: {Precio:C}");
        Console.WriteLine($"Cantidad: {Cantidad}");
    }
}

class ProductoElectronico : Producto
{

    private string marca;
    private string modelo;
    private int garantiaMeses;

    public string Marca { get => marca; set => marca = value; }
    public string Modelo { get => modelo; set => modelo = value; }
    public int GarantiaMeses { get => garantiaMeses; set => garantiaMeses = value; }

    public ProductoElectronico(string nombre, string codigo, decimal precio, int cantidad, string marca, string modelo, int garantiaMeses)
        : base(nombre, codigo, precio, cantidad)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.garantiaMeses = garantiaMeses;
    }

    public override decimal CalcularImpuesto()
    {

        return Precio * 0.18m;
    }

    public override void MostrarProducto()
    {

        base.MostrarProducto();
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Garantía (meses): {GarantiaMeses}");
    }
}


class ProductoAlimento : Producto
{


    private DateTime fechaVencimiento;

    public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }

    public ProductoAlimento(string nombre, string codigo, decimal precio, int cantidad, DateTime fechaVencimiento)
        : base(nombre, codigo, precio, cantidad)
    {
        this.fechaVencimiento = fechaVencimiento;
    }

    public override decimal CalcularImpuesto()
    {
        // Impuesto 8%
        return Precio * 0.08m;
    }

    public override void MostrarProducto()
    {
        base.MostrarProducto();
        Console.WriteLine($"Fecha de vencimiento: {FechaVencimiento:yyyy-MM-dd}");
    }
}

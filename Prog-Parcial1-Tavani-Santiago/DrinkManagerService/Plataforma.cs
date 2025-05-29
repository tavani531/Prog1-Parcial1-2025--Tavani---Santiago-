namespace DrinkManagerService
{
    public class Plataforma
    {
        private List<Ventas> ListasVentas { get; set; } = new();
        private List<Bebidas> ListasBebidas { get; set; } = new();
        public double CalcularPrecioFinal(Bebidas bebida)
        { 
            double precioFinal = bebida.PrecioBase;
            if (bebida is BebidasConAlcohol bebidaAlcohol)
            {
                if (bebidaAlcohol.PorcentajeAlcohol > 30)
                {
                    precioFinal = precioFinal + (precioFinal * 0.1);
                }
                if (bebidaAlcohol.TipoEnvase == Enums.tipoEnvase.Vidrio)
                {
                    precioFinal = precioFinal + (precioFinal * 0.05);
                }
            }
            else if (bebida is BebidasSinAlcohol bebidaSinAlcohol)
            {
                if (bebidaSinAlcohol.AptoDiabeticos == true)
                {
                    precioFinal = precioFinal + (precioFinal * 0.15);
                }
                if (bebidaSinAlcohol.Sabor == Enums.SaborBebidaSinAlcohol.Cola || bebidaSinAlcohol.Sabor == Enums.SaborBebidaSinAlcohol.Naranja)
                {
                    precioFinal = precioFinal + (precioFinal * 0.03);
                }
            }
            else if (bebida is BebidasEnergizantes bebidaEnergizante)
            {
                if (bebidaEnergizante.NivelAzucar == Enums.NivelAzucarEnergizante.Medio)
                {
                    precioFinal = precioFinal + (precioFinal * 0.05);
                }
                else
                {
                    precioFinal = precioFinal + (precioFinal * 0.02);
                }
            }
            else
            {
                precioFinal = bebida.PrecioBase;
            }
            return precioFinal;
        }
        public string Descripcion(Bebidas bebida)
        {
            string descrpcion;
            if (bebida is BebidasConAlcohol bebidaAlcohol)
            {
                descrpcion = $"La {bebida.Nombre} es una bebida de la marca {bebida.Marca}, con un volumen de {bebida.Volumen}, su graduacion alcoholica es de {bebidaAlcohol.PorcentajeAlcohol}%, su tipo es: {bebidaAlcohol.TipoBebida} y tiene un precio de: {CalcularPrecioFinal}";
            }
            else if (bebida is BebidasSinAlcohol bebidaSinAlcohol)
            {
                descrpcion = $"La {bebida.Nombre} es una bebida de la marca {bebida.Marca}, con un volumen de {bebida.Volumen} y tiene un precio de: {CalcularPrecioFinal}";
            }
            else if (bebida is BebidasEnergizantes bebidaEnergizante)
            {
                descrpcion = $"La {bebida.Nombre} es una bebida de la marca {bebida.Marca}, con un volumen de {bebida.Volumen} y tiene un precio de: {CalcularPrecioFinal}";
            }
            else
            {
                descrpcion = "Bebida inexistente";
            }
            return descrpcion;
        }
        public bool CargarBebida(Bebidas bebida)
        {
            if (bebida == null)
            {
                return false;
            }
            if (bebida.Nombre == null  || bebida.Marca == null)
            {
                return false;
            }

            if (bebida is BebidasConAlcohol bebidaAlcohol)
            {
                if (bebidaAlcohol.PorcentajeAlcohol <= 0 || bebidaAlcohol.TipoBebida == null)
                {
                    return false;
                }
            }
            else if (bebida is BebidasSinAlcohol bebidaSinAlcohol)
            {
                if (bebidaSinAlcohol.Sabor == null)
                {
                    return false;
                }
            }
            else if (bebida is BebidasEnergizantes bebidaEnergizante)
            {
                if (bebidaEnergizante.NivelAzucar == null)
                {
                    return false;
                }
            }
            ListasBebidas.Add(bebida);
            return true;
        }
        
        int codRegistroVenta = 1;
        public string RegistrarVentas(int codProducto, int cantComprada)
        {
            var bebida = ListasBebidas.FirstOrDefault(p => p.Codigo == codProducto);

            if(bebida == null)
            {
                return "Venta no realizada: Producto inexistente";
            }
            if (cantComprada > 5)
            {
                return "Venta no realizada: La cantidad es mayor a 5 unidades";
            }
            double montoFinal = CalcularPrecioFinal(bebida);
            Ventas venta = new Ventas
            {
                Codigo = codRegistroVenta,
                ProductoVendido=bebida.Nombre,
                FechaOperacion=DateTime.Now,
                Hora=DateTime.Now.Hour,
                Cantidad=cantComprada,
                MontoFinal=montoFinal
            };
            ListasVentas.Add(venta);
            codRegistroVenta++;
            return "Venta realizada correctamente.";
        }
        public List<string> ListarDescripcionesProductos()
        {
            List<string> descripciones = new List<string>();
            foreach (var bebida in ListasBebidas)
            {
                descripciones.Add(Descripcion(bebida));
            }
            return descripciones;
        }
        public Bebidas ProductoMasEconomico(List<int> codigos)
        {
            Bebidas productoMasBarato = null;
            double precioMinimo = 1000000000;

            foreach (int codigo in codigos)
            {
                var bebida = ListasBebidas.FirstOrDefault(b => b.Codigo == codigo);
                if (bebida != null)
                {
                    double precio = CalcularPrecioFinal(bebida);
                    if (precio < precioMinimo)
                    {
                        precioMinimo = precio;
                        productoMasBarato = bebida;
                    }
                }
            }

            return productoMasBarato;
        }
        public List<Bebidas> BuscarProductosPorNombre(string valor)
        {
            List<Bebidas> coincidencias = new List<Bebidas>();
            if (valor == null)
            {
                return coincidencias;
            }
            string valorBusqueda = valor.ToLower();

            foreach (var bebida in ListasBebidas)
            {
                if (bebida.Nombre != null && bebida.Nombre.ToLower().Contains(valorBusqueda))
                {
                    coincidencias.Add(bebida);
                }
            }
            return coincidencias;
        }
    }
}

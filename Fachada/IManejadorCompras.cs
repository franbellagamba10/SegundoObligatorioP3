using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fachada
{
    public interface IManejadorCompras
    {
        public IEnumerable<Compra> BuscarComprasPorTipoPlanta(int id);
        public bool DarDeAlta(Compra compraDatos);
        public IEnumerable<Compra> ObtenerTodasLasCompras();
    }
}
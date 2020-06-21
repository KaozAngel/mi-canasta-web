﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class TiendaDto
    {
        public int TiendaId { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Horario { get; set; }
        public List<UsuarioTiendaDto> UsuarioTiendas { get; set; }
        public List<StockDto> Stocks { get; set; }
        public List<HistorialDto> Historiales { get; set; }
    }

    public class TiendaCreateDto
    {
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Horario { get; set; }

        public class TiendaUpdateDto
        {
            public string Descripcion { get; set; }
            public string Direccion { get; set; }
            public string Latitud { get; set; }
            public string Longitud { get; set; }
            public string Horario { get; set; }
            public List<UsuarioTiendaDto> UsuarioTiendas { get; set; }
            public List<StockDto> Stocks { get; set; }
        }
    }
}
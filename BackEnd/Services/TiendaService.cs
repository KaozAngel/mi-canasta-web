﻿using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
﻿using MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MiCanasta.MiCanasta.Services
{
    public interface TiendaService
    {
        TiendaDto getById(int IdTienda);
        TiendaUsuarioDto PostUsuarioInTienda(int idTienda, string dni);
        public TiendaLimiteDto GetLimiteTienda(int idTienda);

        List<StockDto> GetStocksById(int IdTienda);
        StockDto UpdateStock(int IdTienda, int IdProducto, StockUpdateDto StockUpdateDto);

        public List<ListarUsuarioTiendaDto> GetByTiendaId(int id);
        List<TiendaDataDto>GetTiendas();
        TiendaDetallesDto GetTiendaDetalles(int IdTienda);

        TiendaUpdateDto UpdateTienda(int IdTienda, string Dni, TiendaUpdateDto TiendaUpdateDto);
    }
}

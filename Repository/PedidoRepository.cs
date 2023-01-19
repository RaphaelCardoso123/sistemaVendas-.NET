using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Models;
using SistemaVendas.Dto;
using Microsoft.EntityFrameworkCore;


namespace SistemaVendas.Repository
{
    public class PedidoRepository
    {
        private readonly VendasContext _context; 
        public PedidoRepository(VendasContext context)
        {
            _context = context;
        }


        public Pedido Cadastrar(Pedido pedido)
          {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges(); 
            return pedido;
          }


        public Pedido ObterPorId(int id)                                
          {
            var pedido = _context.Pedidos.Include(x => x.Vendedor)
                                         .Include(x => x.Cliente)
                                         .FirstOrDefault(x => x.Id == id);
            return pedido;
          }


          public Pedido AtualizarPedido(Pedido pedido)
                                                              
          {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges(); 

            return pedido;
          }


          public void DeletarPedido(Pedido pedido)
          {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
          }


          public List<ObterPedidoDTO> ObterPorVendedorId(int id)
          {
            var pedidos = _context.Pedidos.Where(x => x.VendedorId == id)
                                          .Select(x => new ObterPedidoDTO(x))
                                          .ToList();

            return pedidos;
        }


        public List<ObterPedidoDTO> ObterPorClienteId(int id)
        {
            var pedidos = _context.Pedidos.Where(x => x.ClienteId == id)
                                          .Select(x => new ObterPedidoDTO(x))
                                          .ToList();

            return pedidos;
        }

    }
}
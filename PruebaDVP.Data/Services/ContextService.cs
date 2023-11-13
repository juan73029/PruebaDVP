using System;
using Microsoft.EntityFrameworkCore;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services.Interfaces;

namespace PruebaDVP.Data.Services
{
    public class ContextService<T> : IContextService<T> where T : class
    {
        private readonly PruebaDoubleVpartnersContext _context;
        public ContextService(PruebaDoubleVpartnersContext context)
        {
            _context = context;
        }


        public async Task<List<T>> Get()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<T?> Get(int id)
        {
            try
            {
                T? element = await _context.Set<T>().FindAsync(id);
                return element;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<T> Add(T element)
        {
            try
            {
                _context.Set<T>().Add(element);
                await _context.SaveChangesAsync();
                return element;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> Update(int id, T element)
        {
            try
            {
                T oldElement = await _context.Set<T>().FindAsync(id) ?? throw new Exception("Element not found");
                _context.Set<T>().Entry(oldElement).CurrentValues.SetValues(element);
                await _context.SaveChangesAsync();
                return element;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                T element = await _context.Set<T>().FindAsync(id) ?? throw new Exception("Element not found");
                _context.Set<T>().Remove(element);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


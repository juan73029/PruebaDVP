using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaDVP.Core.Services.Interfaces;
using PruebaDVP.Data.Services.Interfaces;

namespace PruebaDVP.Core.Services
{
    public class Service<T, DTO> : IService<T, DTO> where T : class
                                                  where DTO : class
    {
        private readonly IContextService<T> _context;
        private readonly IMapper _mapper;
        public Service(IContextService<T> context, IMapper mapper)
        {


            _context = context;
            _mapper = mapper;
        }

        public async Task<DTO> Add(DTO element)
        {
            try
            {

                T newElement = await _context.Add(_mapper.Map<T>(element));
                return _mapper.Map<DTO>(newElement);
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
                DTO? element = await Get(id) ?? throw new Exception("Element not found");
                await _context.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DTO>> Get()
        {
            try
            {
                return _mapper.Map<List<DTO>>(await _context.Get());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO?> Get(int id)
        {
            try
            {
                return _mapper.Map<DTO>(await _context.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO> Update(DTO element, int id)
        {
            try
            {

                DTO? oldElement = await Get(id) ?? throw new Exception("Element not found");
                await _context.Update(id, _mapper.Map<T>(element));
                return element;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


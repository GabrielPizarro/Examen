﻿using BD;
using Entity;
//using Entity.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITitulosService
    {
        Task<DBEntity> Create(TitulosEntity entity );
        Task<DBEntity> Delete(TitulosEntity entity );
        Task<IEnumerable<TitulosEntity>> Get();
        Task<TitulosEntity> GetById(TitulosEntity entity );
        Task<DBEntity> Update(TitulosEntity entity );
    }

    public class TitulosService : ITitulosService
    {
        private readonly IDataAccess sql;

        public TitulosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<TitulosEntity>> Get()
        {

            try
            {
                var result = sql.QueryAsync<TitulosEntity>("TitulosObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public async Task<TitulosEntity> GetById(TitulosEntity entity)
        {

            try
            {
                var result = sql.QueryFirstAsync<TitulosEntity>("TitulosObtener", new
                {
                    entity.Id_Titulo
                }
                );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Create(TitulosEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("TitulosInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado
                }
                );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<DBEntity> Update(TitulosEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("TitulosActualizar", new
                {
                    entity.Id_Titulo,
                    entity.Descripcion,
                    entity.Estado
                }
                );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<DBEntity> Delete(TitulosEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("TitulosEliminar", new
                {
                    entity.Id_Titulo
                }
                );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
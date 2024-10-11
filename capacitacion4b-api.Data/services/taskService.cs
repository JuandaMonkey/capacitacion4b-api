using capacitacion4b_api.Data.interfaces;
using capacitacion4b_api.DTOs.task;
using capacitacion4b_api.DTOs.user;
using capacitacion4b_api.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capacitacion4b_api.Data.services
{
    public class taskService : iTaskService
    {

        private postgresqlConection _postgresqlConection;
        public taskService(postgresqlConection postgresqlConection) => _postgresqlConection = postgresqlConection;

        private NpgsqlConnection GetConnection() => new NpgsqlConnection(_postgresqlConection._connection);

        #region taskCreate
        public async Task<taskModel> create(createTaskDto createTaskDto)
        {

            string sqlQuery = "select * from f_taskCreate (" +
                "p_tarea := @tarea," +
                "p_descripcion := @descripcion," +
                "p_fk_idUsuario := @idUsuario);";

            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                taskModel? user = await database.QueryFirstOrDefaultAsync<taskModel>(sqlQuery, new
                {

                    tarea = createTaskDto.tarea,
                    descripcion = createTaskDto.descripcion,
                    idUsuario = createTaskDto.idUsuario

                });

                /* cierra conexión*/
                await database.CloseAsync();

                return user;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

    }
}

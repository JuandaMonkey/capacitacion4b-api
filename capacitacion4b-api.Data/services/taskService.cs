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

        #region findAllTask

        public async Task<IEnumerable<taskModel>> FindAll()
        {

            string sqlQuery = "select * from v_tareas";

            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                IEnumerable<taskModel> allTask = await database.QueryAsync<taskModel>(sqlQuery);

                /* cierra conexión*/
                await database.CloseAsync();

                return allTask;

            }
            catch (Exception e)
            {
                return null;
            }

        }

        #endregion

        #region findOneTask

        public async Task<taskModel> FindOne(int idTarea)
        {
            string sqlQuery = "select * from v_tareas where idTarea := @idTarea";

            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                taskModel? task = await database.QueryFirstOrDefaultAsync<taskModel>(sqlQuery, new { idTarea });

                /* cierra conexión*/
                await database.CloseAsync();

                return task;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        #endregion

        #region taskCreate
        public async Task<taskModel?> Create(createTaskDto createTaskDto)
        {

            string sqlQuery = "select * from f_createTask (" +
                "p_tarea := @tarea," +
                "p_descripcion := @descripcion," +
                "p_fk_idUsuario := @idUsuario);";

            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                taskModel? task = await database.QueryFirstOrDefaultAsync<taskModel>(sqlQuery, param: new
                {

                    tarea = createTaskDto.tarea,
                    descripcion = createTaskDto.descripcion,
                    idUsuario = createTaskDto.idUsuario

                });

                /* cierra conexión*/
                await database.CloseAsync();

                return task;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

        #region taskUpdate

        public async Task<taskModel?> Update(int idTarea, updateTaskDto updateTaskDto)
        {
            /* query de function */
            string sqlQuery = "select * from f_updateTask (" +
                "p_idTarea := @idTarea" +
                "p_tarea := @tarea," +
                "p_descripcion := @descripcion);";

            /* usamos la conexión */
            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                taskModel? task = await database.QueryFirstOrDefaultAsync<taskModel>(sqlQuery,
                param: new
                {

                    /* parametros */
                    idTarea = idTarea,
                    tarea = updateTaskDto.tarea,
                    descripcion = updateTaskDto.descripcion

                }
                );

                /* cierra conexión*/
                await database.CloseAsync();

                return task;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region taskRemove

        public async Task<taskModel> Remove(int idTarea)
        {
            string sqlQuery = "select * from f_removeTask ( p_idTarea := @idTarea );";

            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                taskModel? task = await database.QueryFirstOrDefaultAsync<taskModel>(sqlQuery, param: new 
                {

                    idTarea 

                });

                /* cierra conexión*/
                await database.CloseAsync();

                return task;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        #endregion

        #region taskToggleStatus

        public async Task<taskModel> ToggleStatus(int idTarea)
        {

            string sqlQuery = "select * from f_task_toggleStatus ( p_idTarea := @idTarea );";

            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                taskModel? task = await database.QueryFirstOrDefaultAsync<taskModel>(sqlQuery, param: new
                {

                    idTarea

                });

                /* cierra conexión*/
                await database.CloseAsync();

                return task;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        #endregion

    }

}

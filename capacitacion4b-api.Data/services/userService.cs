using capacitacion4b_api.Data.interfaces;
using capacitacion4b_api.DTOs.user;
using capacitacion4b_api.Models;
using Dapper;
using Npgsql;

namespace capacitacion4b_api.Data.services
{
    public class userService : iUserService
    {

        private postgresqlConection _postgresqlConection;
        public userService(postgresqlConection postgresqlConection) => _postgresqlConection = postgresqlConection;

        private NpgsqlConnection GetConnection() => new NpgsqlConnection(_postgresqlConection._connection);

        public async Task<userModel> create(createUserDto createUserDto)
        {

            string sqlQuery = "select * from f_userCreate (" +
                "p_nombresUsuario := @nombres," +
                "p_usuarioUsuario := @usuario," +
                "p_contrasenaUsuario := @contrasena);";

            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                userModel? user = await database.QueryFirstOrDefaultAsync<userModel>(sqlQuery, new
                {

                    nombres = createUserDto.nombres,
                    usuario = createUserDto.usuario,
                    contrasena = createUserDto.contrasena

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

        public async Task<IEnumerable<userModel>> findAll()
        {

            /* cadena query*/
            string sqlQuery = "select * from v_usuarios";
            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                IEnumerable<userModel> users = await database.QueryAsync<userModel>(sqlQuery);

                /* cierra conexión*/
                await database.CloseAsync();

                return users;
            }
            catch (Exception e)
            {
                return [];
            }

        }

        public async Task<userModel> findOne(int idUsuario)
        {
            string sqlQuery = "select * from v_usuarios where idUsuario = @idUsuario;";
            using NpgsqlConnection database = GetConnection();

            try
            {

                /* abre conexión */
                await database.OpenAsync();

                /* ejecuta el query */
                userModel? user = await database.QueryFirstOrDefaultAsync<userModel>(sqlQuery, new { idUsuario });

                /* cierra conexión*/
                await database.CloseAsync();

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<userModel> update(createUserDto createUserDto)
        {

            throw new NotImplementedException();

        }

        public Task<userModel> remove(createUserDto createUserDto)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using System.Data.SqlClient;
namespace Controlador.Pacientes
{
   public class PacienteDAO
    {
        ClsDatos clsDatos = null;
        PacienteDTO pacienteDTO = null;
        DataTable listaDatos = null;

        public PacienteDAO(PacienteDTO pacienteDTO)
        {
            this.pacienteDTO = pacienteDTO;
        }


        public DataTable ListarPaciente()
        {
            listaDatos = new DataTable();

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = null;

                if (this.pacienteDTO == null)
                {

                    parametros = new SqlParameter[5];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@id";
                    parametros[0].SqlDbType = SqlDbType.Int;
                    parametros[0].SqlValue = pacienteDTO.getId();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@Nombre";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = pacienteDTO.getNombre();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@Apellido";
                    parametros[2].SqlDbType = SqlDbType.VarChar;
                    parametros[2].Size = 50;
                    parametros[2].SqlValue = pacienteDTO.getApellido();

                    parametros[3] = new SqlParameter();
                    parametros[3].ParameterName = "@FechaNacimiento";
                    parametros[3].SqlDbType = SqlDbType.DateTime;
                    parametros[3].SqlValue = pacienteDTO.getFechaNacimiento();

                    parametros[4] = new SqlParameter();
                    parametros[4].ParameterName = "@Sexo";
                    parametros[4].SqlDbType = SqlDbType.VarChar;
                    parametros[4].Size = 50;
                    parametros[1].SqlValue = pacienteDTO.getSexo();

                }
                else
                {

                    parametros = null;
                }

                listaDatos = clsDatos.RetornarTabla(parametros, "spConsultaPaises");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return listaDatos;
        }
    }


}

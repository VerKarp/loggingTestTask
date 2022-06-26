using System;
using System.Data;
using System.Data.SqlClient;

namespace SimpleLogger.TargetLogs
{
    public class DbLogger : LoggerBase
    {
        private readonly string connectionString = @"Data Source=VERA;Database=LogTest;Trusted_Connection=True;";

        public override void Log(LogMessage logMessage)
        {
            using (SqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new("AddLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter parameter = new();
                        parameter.ParameterName = "@logLevel";
                        parameter.SqlDbType = SqlDbType.NVarChar;
                        parameter.Value = logMessage.Level;
                        command.Parameters.Add(parameter);

                        parameter = new();
                        parameter.ParameterName = "@time";
                        parameter.SqlDbType = SqlDbType.DateTime;
                        parameter.Value = logMessage.Time;
                        command.Parameters.Add(parameter);

                        parameter = new();
                        parameter.ParameterName = "@message";
                        parameter.SqlDbType = SqlDbType.NVarChar;
                        parameter.Value = logMessage.Message;
                        command.Parameters.Add(parameter);

                        parameter = new();
                        parameter.ParameterName = "@callingMethod";
                        parameter.SqlDbType = SqlDbType.NVarChar;
                        parameter.Value = logMessage.Method;
                        command.Parameters.Add(parameter);

                        parameter = new();
                        parameter.ParameterName = "@callingClass";
                        parameter.SqlDbType = SqlDbType.NVarChar;
                        parameter.Value = logMessage.Class;
                        command.Parameters.Add(parameter);

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}